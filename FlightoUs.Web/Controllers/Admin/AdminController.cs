using Microsoft.AspNetCore.Mvc;
using FlightoUs.Bll;
using FlightoUs.Model.Data;
using Microsoft.AspNetCore.Authorization;
using System;

namespace FlightoUs.Web.Controllers.Admin
{
    [Authorize(Roles = "Admin", AuthenticationSchemes = "Admin")]
    public class AdminController : Controller
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

        public IActionResult AddEditLead(int id=0)
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
        public IActionResult AddEditUser(int id=0,string Code="", string Type="")
        {
            if (Code == "BadFileExtenstion")
            {
                ViewData["Message"] = "You are only allowed to upload Image type Files.";
                ViewData["Type"] = Type;
            }
            else if (Code == "FileSuccess")
            {
                ViewData["Message"] = "File has been successfully uploaded.";
                ViewData["Type"] = Type;
            }
            BllUser blluser = new BllUser();
            if (blluser.GetByPK(id) == null)
            {
                User dbuser = new User();
                ViewBag.data = dbuser;
                ViewBag.title = "Add User";
                ViewBag.IsAdd = false;

            }
            else
            {
                ViewBag.data = blluser.GetByPK(id);
                ViewBag.title = "Edit User";
                ViewBag.IsAdd = false;

            }
            return View("Views/CRM/Admin/Users/AddEditUser.cshtml");
        }

        public IActionResult AddEditRemarks(int LeadId)
        {
            ViewBag.Leadid = LeadId;
            Remarks remarks = new Remarks();
            ViewBag.remarks = remarks;
            return View("Views/CRM/Admin/Remarks/AddEditRemarks.cshtml");
        }
        public IActionResult MakeRecipt(int LeadId)
        {
            ViewBag.Leadid = LeadId;

            BllLead bllLead = new BllLead();
            ViewBag.data = bllLead.GetByPK(LeadId);
            Recipt recipt = new Recipt();


            recipt.CreatedDate = DateTime.Now;
            ViewBag.recipt = recipt;

            return View("Views/CRM/Admin/Recipt/MakeRecipt.cshtml");
        }
        public IActionResult ReciptIndex()
        {
            return View("Views/CRM/Admin/Recipt/Index.cshtml");
        }
        public IActionResult ReciptView(int id)
        {
            BllRecipt bllRecipt = new BllRecipt();
            var recipt =bllRecipt.GetByPK(id);
            ViewBag.recipt = recipt;
            ViewBag.Leadid = recipt.Lead_Id;

            BllLead bllLead = new BllLead();
            ViewBag.data = bllLead.GetByPK(recipt.Lead_Id);
            return View("Views/CRM/Admin/Recipt/ReciptPrintMode.cshtml");
        }
        public IActionResult MakeSalePost(int LeadId)
        {
            ViewBag.Leadid = LeadId;

            BllLead bllLead = new BllLead();
            ViewBag.data = bllLead.GetByPK(LeadId);
            SalePost salePost = new SalePost();


            salePost.CreatedDate = DateTime.Now;
            ViewBag.salePost = salePost;

            return View("Views/CRM/Admin/SalePost/AddEditSalePost.cshtml");
        }
        public IActionResult SalePostIndex()
        {
            return View("Views/CRM/Admin/SalePost/Index.cshtml");
        }
        public IActionResult ShowSale(int id)
        {
            BllSalePost bllSalePost = new BllSalePost();
            ViewBag.salepost= bllSalePost.GetByPK(id);
            return View("Views/CRM/Admin/SalePost/ShowSale.cshtml");
        }

        public IActionResult CashBookIndex()
        {
            return View("Views/CRM/Admin/CashBook/Index.cshtml");
        }
        public IActionResult AddEditCashBook(int id)
        {
            BllCashBook bllCashBook = new BllCashBook();
            if (bllCashBook.GetByPK(id) == null)
            {
                CashBook dbCashBook = new CashBook();
                ViewBag.cashBook = dbCashBook;
                ViewBag.title = "Add Cash Book";
            }
            else
            {
                ViewBag.cashBook = bllCashBook.GetByPK(id);
                ViewBag.title = "Edit Cash Book";
            }
            return View("Views/CRM/Admin/CashBook/AddEditCashBook.cshtml");
        }
        public IActionResult AddRefundRequest(int SaleId)
        {
            ViewBag.SaleId = SaleId;

            BllSalePost bllSalePost = new BllSalePost();
            ViewBag.SalePostdata = bllSalePost.GetByPK(SaleId);
            Refund Refund = new Refund();


            Refund.CreatedDate = DateTime.Now;
            ViewBag.refund = Refund;

            return View("Views/CRM/Admin/Refunds/AddEditRefund.cshtml");
        }
        public IActionResult RefundIndex()
        {
            return View("Views/CRM/Admin/Refunds/Index.cshtml");
        }
        public IActionResult ApproveRecipt(int Id)
        {
            ViewBag.ReciptId = Id;

            BllRecipt bllRecipt = new BllRecipt();
            ViewBag.ReciptData = bllRecipt.GetByPK(Id);
            return View("Views/CRM/Admin/Recipt/ApproveRecipt.cshtml");
        }
    }
}
