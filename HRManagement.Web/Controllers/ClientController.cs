using HRManagement.Web.Dto;
using HRManagement.Web.Extensions;
using HRManagement.Web.Models;
using HRManagement.Web.Repository;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HRManagement.Web.Controllers
{
    [Authorize]
    [Route("Client")]
    public class ClientController : Controller
    {
        private readonly IRepository<Client> _clientRepository;

        public ClientController(
            IRepository<Client> clientRepository
            )
        {
            _clientRepository = clientRepository;
        }

        [HttpGet]
        [Route("GetAllClients")]
        public IActionResult GetAllClients(int? page = 1)
        {
            var clients = _clientRepository.GetAll(page);
            return PartialView(@"~/Views/Shared/_Clients.cshtml", clients);
        }

        [HttpGet]
        [Route("Add")]
        public IActionResult Add()
        {
            return View();
        }

        [HttpPost]
        [Route("Add")]
        public async Task<IActionResult> Add(ClientViewModel model)
        {
            if (ModelState.IsValid)
            {
                Client c = new Client
                {
                    Name = model.Name,
                    Description = model.Description
                };

                await _clientRepository.Add(c);
                return RedirectToAction("Index", "Dashboard").WithSuccess("Félicitations", "Ajout effectué !");
            }
            return View(model).WithDanger("Erreur rencontré", "Une erreur est survenue");
        }

        [HttpGet]
        [Route("Edit/{id?}")]
        public async Task<IActionResult> Edit(string id)
        {
            var client = await _clientRepository.GetById(id);
            // ALERT SI NULL
            if (client == null)
            {
                return View().WithDanger("Erreur rencontré", "Une erreur est survenue");
            }
            ClientViewModel model = new ClientViewModel
            {
                Id = client.Id,
                Name = client.Name,
                Description = client.Description
            };
            return View(model);
        }

        [HttpPost]
        [Route("Edit/{id?}")]
        public async Task<IActionResult> Edit(string id, ClientViewModel model)
        {
            if (ModelState.IsValid)
            {
                var client = await _clientRepository.GetById(id);

                client.Name = model.Name;
                client.Description = model.Description;

                await _clientRepository.Update(client);
                return RedirectToAction("Index", "Dashboard").WithSuccess("Félicitations", "Mise à jour effectuée !");
            }
            return View(model).WithDanger("Erreur rencontré", "Une erreur est survenue");
        }

        [HttpGet, ActionName("Delete")]
        [Route("Delete/{id?}")]
        public async Task<IActionResult> Delete(string id)
        {
            var client = await _clientRepository.GetById(id);
            // ALERT SI NULL
            if (client == null)
            {
                return View().WithDanger("Erreur rencontré", "Une erreur est survenue");
            }
            await _clientRepository.Delete(client);
            return RedirectToAction("Index", "Dashboard").WithSuccess("Félicitations", "Suppression effectuée !");
        }
    }
}
