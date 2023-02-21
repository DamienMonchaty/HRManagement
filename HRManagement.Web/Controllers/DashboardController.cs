using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HRManagement.Web.Controllers
{
    [Route("Dashboard")]
    public class DashboardController : Controller
    {
        [Authorize(Roles = "Administrator")]
        [HttpGet]
        [Route("Index")]
        public IActionResult Index()
        {
            //var email = (string)TempData["email"];
            //TempData.Remove("email");
            return View();
        }
    }
}
