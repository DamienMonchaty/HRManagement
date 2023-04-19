using HRManagement.Web.Dto;
using HRManagement.Web.Extensions;
using HRManagement.Web.Helpers;
using HRManagement.Web.Models;
using HRManagement.Web.Repository;
using HRManagement.Web.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Security.Cryptography;
using System.Threading.Tasks;

namespace HRManagement.Web.Controllers
{
    [Route("Account")]
    public class AccountController : Controller
    {
        private readonly IEmailService _emailService;
        private readonly UserManager<User> _userManager;
        private readonly SignInManager<User> _signInManager;
        private readonly IUserRepository _userRepository;
        private readonly IRepository<Address> _addressRepository;
        private readonly RoleManager<IdentityRole> _roleManager;

        public AccountController(
            UserManager<User> userManager,
            SignInManager<User> signInManager, 
            IEmailService emailService,
            IUserRepository userRepository,
            IRepository<Address> addressRepository,
            RoleManager<IdentityRole> roleManager
            )
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _emailService = emailService;
            _userRepository = userRepository;
            _addressRepository = addressRepository;
            _roleManager = roleManager;
        }

        [HttpGet]
        [AllowAnonymous]
        [Route("Login")]
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        [AllowAnonymous]
        [Route("Login")]
        public async Task<IActionResult> Login(LoginViewModel user)
        {

            var token = TempData["token"];
            var email = user.Email ?? TempData["email"];
            //var u = await _userRepository.findByEmail(email.ToString());
            //if(u != null && ModelState.IsValid)
            //{
                var us = await _userManager.FindByEmailAsync(email.ToString());
                if (us.EmailConfirmed == false)
                {
                    var rst = await _userManager.ConfirmEmailAsync(us, token.ToString());
                    var result = await _signInManager.PasswordSignInAsync(user.Email, user.Password, user.RememberMe, false);
                    if (rst.Succeeded && result.Succeeded)
                    {
                        return RedirectToAction(nameof(ConfirmEmail), "Account", new { token, email }, Request.Scheme).WithSuccess("Félicitations", "Votre incription a bien étéprise en compte !");
                    }
                }
                else if (us.EmailConfirmed == true)
                {
                    var result2 = await _signInManager.PasswordSignInAsync(user.Email, user.Password, user.RememberMe, false);
                    if (result2.Succeeded)
                    {
                        return RedirectToAction("Index", "Dashboard").WithSuccess("Félicitations", "Vous êtes connecté !");
                    }
                }
                else
                {
                    return View(user).WithDanger("Erreur rencontré", "Username et/ou mot de passe incorrects");
                }



            return null;
        }

        [Authorize(Roles = "Administrator")]
        [HttpGet]
        [Route("Register")]
        public IActionResult Register()
        {
            var rolesList = _roleManager.Roles?.ToList();
            this.ViewData["roles"] = rolesList
                .Select(c => new SelectListItem() { Text = c.Name })
                .ToList();
            return View();
        }

        [Authorize(Roles = "Administrator")]
        [Route("Register")]
        [HttpPost]
        public async Task<IActionResult> Register(RegisterViewModel model)
        {
            if (ModelState.IsValid)
            {
                var user = new User
                {
                    UserName = model.Email,
                    Email = model.Email,
                    BrutSalary = model.BrutSalary,
                    NetSalary = model.NetSalary,
                    PositionEnum = model.Position
                };

                var genPassword = GeneratePassword(12, 4);

                var result = await _userManager.CreateAsync(user, "Test1234!");

                if (result.Succeeded)
                {
                    await _userManager.AddToRoleAsync(user, model.Role);

                    var token = await _userManager.GenerateEmailConfirmationTokenAsync(user);
                    var confirmationLink = Url.Action(nameof(ConfirmEmail), "Account", new { token, email = user.Email }, Request.Scheme);
                    TempData["token"] = token;
                    TempData["email"] = user.Email;
                    string str = await ViewToStringRenderer.RenderViewToStringAsync(HttpContext.RequestServices, $"~/Views/Emails/EmailRegisterTemplate.cshtml", new Email { Message = confirmationLink, Password = "Test1234!" });
                    var message = new Message(new string[] { user.Email }, "Confirmation email link", str, null);
                    //var message = new Message(new string[] { user.Email }, "Confirmation email link", confirmationLink + "\n" + "Votre mot de passe (à modifier) ->" + "Test1234!", null);
                    await _emailService.SendEmailAsync(message);
                    return RedirectToAction("Index", "Dashboard").WithSuccess("Félicitations", "Vous êtes connecté !");
                }
                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError("", error.Description);
                }
                ModelState.AddModelError(string.Empty, "Invalid Login Attempt");
            }
            return View(model).WithDanger("Erreur rencontré", "Une erreur est survenue");
        }

        //[Authorize]
        [HttpGet]
        [Route("Edit/{id}")]
        public async Task<IActionResult> Edit(string id)
        {
            var u = await _userRepository.GetById(id);
            EditViewModel model = new EditViewModel
            {
                Id = u.Id,
                Email = u.Email,
                BrutSalary = u.BrutSalary,
                NetSalary = u.NetSalary,
                PositionEnum = u.PositionEnum.ToString()
            };
            return View(model);
        }

        //[Authorize]
        [Route("Edit/{id}")]
        [HttpPost]
        public async Task<IActionResult> Edit(EditViewModel model)
        {
            Debug.WriteLine("MODEL ->" + model);
            var hasher = new PasswordHasher<User>();
            if (ModelState.IsValid)
            {
                var u = await  _userRepository.GetById(model.Id);

                Address a = new Address
                {
                    Street1 = model.Address.Street1,
                    Street2 = model.Address.Street2,
                    Street3 = model.Address.Street3,
                    ZipCode = model.Address.ZipCode,
                    City = model.Address.City,
                };

                var addressSaved = await _addressRepository.Add(a);

                u.PasswordHash = hasher.HashPassword(u, model.Password);
                u.NatCardNumber = model.NatCardNumber;
                u.SecCardNumber = model.SecCardNumber;
                u.FirstName = model.FirstName;
                u.LastName = model.LastName;
                u.BirthDate = model.BirthDate;
                u.BirthPlace = model.BirthPlace;
                u.BirthCountry = model.BirthCountry;
                u.AddressId = addressSaved.Id;

                foreach (var s in model.Schools)
                {
                    School schoolToSave = new School
                    {
                        Libelle = s.Libelle,
                        StartDate = s.StartDate,
                        EndDate = s.EndDate
                    };
                    u.Schools.Add(schoolToSave);
                }

                foreach (var d in model.Diplomas)
                {
                    Diploma diplomaToSave = new Diploma
                    {
                        Libelle = d.Libelle,
                        StartDate = d.StartDate,
                        EndDate = d.EndDate
                    };
                    u.Diplomas.Add(diplomaToSave);
                }

                var result = await _userRepository.Update(u);

                if (result != null)
                {
                    return RedirectToAction("Index", "Dashboard").WithSuccess("Félicitations", "Mise à jour effectuée !");
                }
            }
            return View(model).WithDanger("Erreur rencontré", "Une erreur est survenue");
        }

        [Authorize]
        [HttpGet]
        [Route("ConfirmEmail")]
        public async Task<IActionResult> ConfirmEmail([FromQuery] string token, [FromQuery] string email)
        {
            var user = await _userManager.FindByEmailAsync(email);
            if (user == null)
            {
                return View("Error");
            }
            return View(user).WithSuccess("Félicitations", "Email confirmé avec succès !");
        }

        [HttpGet]
        [Route("SuccessRegistration")]
        public IActionResult SuccessRegistration()
        {          
            return View();
        }

        [HttpGet]
        [Route("Error")]
        public IActionResult Error()
        {
            return View();
        }

        [HttpGet]
        [Route("AccessDenied")]
        public IActionResult AccessDenied()
        {
            return View().WithWarning("Attention !", "Chemin non accessible !");
        }

        [Authorize]
        [HttpGet]
        [Route("Logout")]
        public async Task<IActionResult> Logout()
        {
            await _signInManager.SignOutAsync();
            return RedirectToAction("Login").WithInfo("Déconnection", "Vous avez été déconnecté !");
        }

        private static string GeneratePassword(int length, int numberOfNonAlphanumericCharacters)
        {
            const string allowedChars = "abcdefghijkmnopqrstuvwxyzABCDEFGHJKLMNOPQRSTUVWXYZ0123456789";
            const string nonAlphanumericChars = "!@#$%^&*()_-+=[{]};:<>|./?";
            var randNum = new byte[4];
            using (var rng = new RNGCryptoServiceProvider())
            {
                rng.GetBytes(randNum);
                var randomSeed = BitConverter.ToInt32(randNum, 0);
                var random = new Random(randomSeed);
                var chars = new char[length];
                var allowedCharCount = allowedChars.Length;
                var nonAlphanumericCharCount = nonAlphanumericChars.Length;
                var numNonAlphanumericCharsAdded = 0;
                for (var i = 0; i < length; i++)
                {
                    if (numNonAlphanumericCharsAdded < numberOfNonAlphanumericCharacters && i < length - 1)
                    {
                        chars[i] = nonAlphanumericChars[random.Next(nonAlphanumericCharCount)];
                        numNonAlphanumericCharsAdded++;
                    }
                    else
                    {
                        chars[i] = allowedChars[random.Next(allowedCharCount)];
                    }
                }
                return new string(chars);
            }
        }
        
        private Task<User> GetCurrentUserAsync() => _userManager.GetUserAsync(HttpContext.User);

    }
}
