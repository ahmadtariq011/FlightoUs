using FlightoUs.Bll;
using FlightoUs.Model.Data;
using FlightoUs.Model.Enums;
using FlightoUs.Model.Filter;
using FlightoUs.Model.Services;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FlightoUs.Web.APIController
{
    [Produces("application/json")]
    [Route("api/[controller]/[action]")]
    public class CashBookApiController : Controller
    {
        BllCashBook bllCashBook = new BllCashBook();
        BllLead bllLead = new BllLead();
        BllUser bllUser = new BllUser();

        ServiceResponse result = new ServiceResponse();

        [HttpPost]
        public ServiceResponse GetCashBooksWithCount(CashBookSearchFilter filter)
        {
            try
            {
                //FlightoUs.Model.Data.User dbUser = bllUser.GetByPK(Convert.ToInt32(User.Identity.Name));
                //filter.UserType = dbUser.UserType;
                result.Message = bllCashBook.Search(filter);
                result.IsSucceeded = true;
                result.TotalCount = bllCashBook.GetSearchCount(filter);
            }
            catch (Exception ex)
            {
                result.IsSucceeded = false;
                result.Message = ex.Message + "<br>" + ex.StackTrace;
            }
            return result;

        }

        [HttpPost]
        public ServiceResponse AddCashBook(CashBookModel cashBook)
        {
            try
            {
                if (cashBook.Id == 0)
                {
                    CashBook dbCashBook = new CashBook();
                    PaymentMode tript = (PaymentMode)Enum.Parse(typeof(PaymentMode), cashBook.PaymentModeStr);
                    dbCashBook.Amount = cashBook.Amount;
                    dbCashBook.CreatedDate = DateTime.Now;
                    dbCashBook.Name = cashBook.Name;
                    dbCashBook.PaymentMode = Convert.ToInt32(tript); 
                    dbCashBook.Remarks = cashBook.Remarks;

                    int CashBookId = bllCashBook.Insert(dbCashBook);
                    result.IsSucceeded = true;
                    result.TotalCount = CashBookId;
                    result.Message = "CashBook is Created Successfully";
                }

            }
            catch (Exception e)
            {
                result.IsSucceeded = false;
                result.Message = e.Message + "<br>" + e.StackTrace;
            }
            return result;
        }

    }
}
