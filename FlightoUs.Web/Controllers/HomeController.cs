using FlightoUs.Bll;
using FlightoUs.Model.Data;
using FlightoUs.Web.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace FlightoUs.Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }
        public IActionResult Login()
        {
            return View("Views/CRM/Admin/Login.cshtml");
        }
        public IActionResult Dashboard()
        {
            return View("Views/CRM/Admin/Dashboard/Index.cshtml");
        }
        public IActionResult UserIndex()
        {
            return View("Views/CRM/Admin/Users/Index.cshtml");
        }
        public IActionResult LeadsIndex()
        {
            return View("Views/CRM/Admin/Leads/Index.cshtml");
        }

        public IActionResult AddEditLead(int id)
        {
            BllLead blllead = new BllLead();
            if (blllead.GetByPK(id) == null)
            {
                Lead dblead = new Lead();
                ViewBag.data = dblead;
                ViewBag.title = "Add Lead";
            }
            else
            {
                ViewBag.data = blllead.GetByPK(id);
                ViewBag.title = "Edit Lead";
            }

            BllUser bllUser = new BllUser();
            ViewBag.UsersList = bllUser.GetAllUsers();

            return View("Views/CRM/Admin/Leads/AddEditLead.cshtml");
        }

        public IActionResult AddEditUser(int id)
        {
            BllUser blluser = new BllUser();
            if(blluser.GetByPK(id)==null)
            {
                User dbuser = new User();
                ViewBag.data = dbuser;
                ViewBag.title = "Add User";
            }
            else
            {
                ViewBag.data = blluser.GetByPK(id);
                ViewBag.title = "Edit User";
            }
            return View("Views/CRM/Admin/Users/AddEditUser.cshtml");
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier});
        }
    }
}
