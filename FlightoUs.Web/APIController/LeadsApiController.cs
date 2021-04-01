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
using Microsoft.AspNetCore.Http;
using System.Security.Claims;

namespace FlightoUs.Web.APIController
{
    [Produces("application/json")]
    [Route("api/[controller]/[action]")]
    public class LeadsApiController : Controller
    {
        BllLead bllLead = new BllLead();
        ServiceResponse result = new ServiceResponse();
        [HttpPost]
        public ServiceResponse GetLeadsWithCount(LeadSearchFilter filter)
        {
            bool IsAdmin = User.IsInRole(UserRoleType.Admin.ToString());
            bool IsManager = User.IsInRole(UserRoleType.Manager.ToString());
            bool IsUser = User.IsInRole(UserRoleType.User.ToString());

            try
            {

                filter.User_Id = Convert.ToInt32(User.Identity.Name);
                result.Message = bllLead.Search(filter);
                result.IsSucceeded = true;
                result.TotalCount = bllLead.GetSearchCount(filter);
            }
            catch (Exception ex)
            {
                result.IsSucceeded = false;
                result.Message = ex.Message + "<br>" +ex.StackTrace;
            }
            return result;

        }


        [HttpPost]
        public ServiceResponse GetLeads(LeadSearchFilter filter)
        {
            try
            {
                result.Message = bllLead.Search(filter);
            }
            catch (Exception ex)
            {
                result.IsSucceeded = false;
                result.Message = ex.Message + "<br>" + ex.StackTrace;
            }
            return result;
        }

        [HttpPost]
        public ServiceResponse SaveLeads(LeadModel lead)
        {
            try
            {
                if (lead.Id == 0)
                {
                    Lead dbLead = new Lead();
                    dbLead.FirstName = lead.FirstName;
                    dbLead.LastName = lead.LastName;
                    dbLead.UserName = lead.UserName;
                    dbLead.CNIC = lead.CNIC;
                    dbLead.Email = lead.Email;
                    dbLead.Address = lead.Address;
                    dbLead.Telephone = lead.Telephone;
                    dbLead.CreatedDate = DateTime.Now;
                    dbLead.AssignDate = DateTime.Now;
                    dbLead.CreatedBy = lead.CreatedBy;
                    dbLead.AssignToUser = lead.AssignToUser;

                    LeadType type = (LeadType)Enum.Parse(typeof(LeadType), lead.LeadTypeName);
                    LeadTypeDemand demand = (LeadTypeDemand)Enum.Parse(typeof(LeadTypeDemand), lead.LeadTypeDemandName);
                    LeadStatus status = (LeadStatus)Enum.Parse(typeof(LeadStatus), lead.LeadStatusName);

                    dbLead.LeadType = Convert.ToInt32(type);
                    dbLead.LeadTypeDemand = Convert.ToInt32(demand);
                    dbLead.LeadStatus = Convert.ToInt32(status);



                    int LeadId = bllLead.Insert(dbLead);
                    result.IsSucceeded = true;
                    result.TotalCount = LeadId;
                }
                else
                {
                    Lead dbLead = bllLead.GetByPK(lead.Id);

                    if(dbLead.AssignToUser!=lead.AssignToUser)
                    {
                        dbLead.AssignToUser = lead.AssignToUser; 
                        dbLead.AssignDate = DateTime.Now;
                    }

                    dbLead.FirstName = lead.FirstName;
                    dbLead.LastName = lead.LastName;

                    dbLead.CNIC = lead.CNIC;
                    dbLead.Email = lead.Email;
                    dbLead.Address = lead.Address;
                    dbLead.Telephone = lead.Telephone;

                    LeadType type = (LeadType)Enum.Parse(typeof(LeadType), lead.LeadTypeName);
                    LeadTypeDemand demand = (LeadTypeDemand)Enum.Parse(typeof(LeadTypeDemand), lead.LeadTypeDemandName);
                    LeadStatus status = (LeadStatus)Enum.Parse(typeof(LeadStatus), lead.LeadStatusName);

                    dbLead.LeadType = Convert.ToInt32(type);
                    dbLead.LeadTypeDemand = Convert.ToInt32(demand);
                    dbLead.LeadStatus = Convert.ToInt32(status);


                    bllLead.Update(dbLead);
                    result.IsSucceeded = true;
                   
                }
                bool IsAdmin = User.IsInRole(UserRoleType.Admin.ToString());
                bool IsManager = User.IsInRole(UserRoleType.Manager.ToString());
                bool IsUser = User.IsInRole(UserRoleType.User.ToString());
                if(IsAdmin)
                {
                    result.Message = "/Admin/UserIndex";
                }
                else if(IsManager)
                {
                    result.Message = "/Manager/UserIndex";
                }
                else if(IsUser)
                {
                    result.Message = "/User/UserIndex";
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
        public ServiceResponse DeleteLeads(int Id)
        {
            try
            {

                bllLead.DeleteLeads(Id);
                result.IsSucceeded = true;
                result.Message = "User Deleted Successfully";
            }

            catch (Exception e)
            {
                result.IsSucceeded = false;
                result.Message = e.Message + " </br> " + e.StackTrace;
            }
            return result;
        }

        [HttpPost]
        public ServiceResponse GetAllLeads()
        {
            try
            {
                result.Message = bllLead.GetAllLeads();
            }
            catch (Exception ex)
            {
                result.IsSucceeded = false;
                result.Message = ex.Message + "<br>" + ex.StackTrace;
            }
            return result;
        }

        [HttpPost]

        public ServiceResponse GetByEmail(string email)
        {
            try
            {
                result.Message = bllLead.GetByEmailLeads(email);
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
