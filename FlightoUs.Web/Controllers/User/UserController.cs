using Microsoft.AspNetCore.Mvc;
using FlightoUs.Bll;
using FlightoUs.Model.Data;
using Microsoft.AspNetCore.Authorization;

namespace FlightoUs.Web.Controllers.UserC
{
    [Authorize(Roles = "User", AuthenticationSchemes = "User")]
    public class UserController : Controller
    {
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
            BllRemarks bllRemarks = new BllRemarks();
            if (blllead.GetByPK(id) == null)
            {
                Lead dblead = new Lead();
                ViewBag.data = dblead;
                ViewBag.title = "Add Lead";
                ViewBag.IsAdd = false;

            }
            else
            {
                ViewBag.data = blllead.GetByPK(id);
                ViewBag.title = "Edit Lead";
                ViewBag.IsAdd = true;
            }

            BllUser bllUser = new BllUser();
            ViewBag.UsersList = bllUser.GetAllUsers();

            return View("Views/CRM/Admin/Leads/AddEditLead.cshtml");
        }

        public IActionResult AddEditUser(int id)
        {
            BllUser blluser = new BllUser();
            if (blluser.GetByPK(id) == null)
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

        public IActionResult AddEditRemarks()
        {
            Remarks remarks = new Remarks();
            ViewBag.remarks = remarks;
            return View("Views/CRM/Admin/Remarks/AddRemarks.cshtml");
        }
    }
}
