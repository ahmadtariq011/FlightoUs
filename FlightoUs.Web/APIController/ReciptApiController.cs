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
    public class ReciptApiController : Controller
    {
        ServiceResponse result = new ServiceResponse();
        BllRecipt bllRecipt = new BllRecipt();
        BllUser bllUser = new BllUser();
        [HttpPost]
        public ServiceResponse MakeRecipt(ReciptModel recipt)
        {
            try
            {
                if (recipt.Id == 0)
                {
                    Recipt dbRecipt = new Recipt();
                    dbRecipt.FirstServiceTitle = recipt.FirstServiceTitle;
                    dbRecipt.FirstServicePrice = recipt.FirstServicePrice;
                    dbRecipt.SecondServiceTitle = recipt.SecondServiceTitle;
                    dbRecipt.SecondServicePrice = recipt.SecondServicePrice;
                    dbRecipt.ThirdServiceTitle = recipt.ThirdServiceTitle;
                    dbRecipt.ThirdServicePrice = recipt.ThirdServicePrice;
                    dbRecipt.Lead_Id = recipt.Lead_Id;
                    dbRecipt.Remarks = recipt.Remarks;
                    dbRecipt.AmountPaid = recipt.AmountPaid;
                    dbRecipt.TotalAmount = recipt.TotalAmount;
                    dbRecipt.Balance = recipt.Balance;
                    dbRecipt.CreatedBy = recipt.CreatedBy;
                    dbRecipt.CreatedDate = DateTime.Now;
                    User user=bllUser.GetByPK(recipt.CreatedBy);
                    
                    dbRecipt.ReciptStatus = (int)ReciptStatus.Pending;
                    if (user.UserType== (int) UserRoleType.Admin)
                    {
                        dbRecipt.ReciptStatus = (int)ReciptStatus.Approved;
                    }

                    int ReciptId = bllRecipt.Insert(dbRecipt);
                    Recipt ReciptUpdated= bllRecipt.GetByPK(ReciptId);
                    ReciptUpdated.ReciptNo = ReciptId.ToString();

                    bllRecipt.Update(ReciptUpdated);
                    result.IsSucceeded = true;
                    result.TotalCount = ReciptId;
                    result.Message = recipt.UserTypeLogin+ "/AddEditLead/" + recipt.Lead_Id;
                }
            }
            catch (Exception e)
            {
                result.IsSucceeded = false;
                result.Message = e.Message + "<br>" + e.StackTrace;
            }
            return result;
        }


        [HttpPost]
        public ServiceResponse GetReciptsWithCount(ReciptSearchFilter filter)
        {
            try
            {
                var user=bllUser.GetByPK(filter.UserId);
                if(user.UserType == (int)UserRoleType.Admin)
                {
                    result.Message = bllRecipt.SearchAdmin(filter);
                    result.TotalCount = bllRecipt.GetSearchCountAdmin(filter);

                }
                else
                {
                    result.Message = bllRecipt.Search(filter);
                    result.TotalCount = bllRecipt.GetSearchCount(filter);
                }
                result.IsSucceeded = true;
            }
            catch (Exception ex)
            {
                result.IsSucceeded = false;
                result.Message = ex.Message + "</br>" + ex.StackTrace;
                throw;
            }
            return result;
        }
        [HttpPost]
        public ServiceResponse DeleteRecipt(int Id)
        {
            try
            {

                bllRecipt.Delete(Id);
                result.IsSucceeded = true;
                result.Message = "Recipt Deleted Successfully";
            }

            catch (Exception e)
            {
                result.IsSucceeded = false;
                result.Message = e.Message + " </br> " + e.StackTrace;
            }
            return result;
        }



    }
}
