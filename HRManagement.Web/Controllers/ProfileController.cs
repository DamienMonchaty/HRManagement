using HRManagement.Web.Dto;
using HRManagement.Web.Models;
using HRManagement.Web.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HRManagement.Web.Controllers
{
    [Route("Profile")]
    public class ProfileController : Controller
    {
        private readonly UserManager<User> _userManager;

        public ProfileController(UserManager<User> userManager)
        {
            _userManager = userManager;
        }

        [Authorize(Roles = "Visitor, Administrator")]
        [HttpGet]
        [Route("Index")]
        public async Task<IActionResult> Index()
        {
            var user = await GetCurrentUserAsync();
            if (user == null)
            {
                ViewBag.ErrorMessage = $"User with Id = {user.Id} cannot be found";
                return View("NotFound");
            }         

            return View(user);
        }

        private Task<User> GetCurrentUserAsync() => _userManager.GetUserAsync(HttpContext.User);

    }
}
