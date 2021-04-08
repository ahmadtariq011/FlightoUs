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
using Microsoft.AspNetCore.Hosting;


namespace FlightoUs.Web.APIController
{
    [Produces("application/json")]
    [Route("api/[controller]/[action]")]
    public class LeadsApiController : Controller
    {
        BllLead bllLead = new BllLead();
        BllUser bllUser = new BllUser();
        ServiceResponse result = new ServiceResponse();
        [HttpPost]
        public ServiceResponse GetLeadsWithCount(LeadSearchFilter filter)
        {
            try
            {

                var userlog=bllUser.GetByPK(filter.UserType);
                filter.User_Id = filter.UserType;
                filter.UserType=userlog.UserType;
                //FlightoUs.Model.Data.User dbUser = bllUser.GetByPK(Convert.ToInt32(User.Identity.Name));
                //filter.UserType = dbUser.UserType;
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
        public ServiceResponse SaveFreeText(LeadModel lead)
        {
            try
            {
                Lead dbLead = bllLead.GetByPK(lead.Id);
                dbLead.FreeText = lead.FreeText;
                bllLead.AddFreetext(dbLead);
                result.IsSucceeded = true;
                result.Message = "Free text is Added Successfully";
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
                    //int useridid=Convert.ToInt32(User.Identity.Name); 
                    Lead dbLead = new Lead();
                    dbLead.FirstName = lead.FirstName;
                    dbLead.UserName = lead.UserName;
                    dbLead.Email = lead.Email;
                    dbLead.Address = lead.Address;
                    dbLead.Telephone = lead.Telephone;
                    dbLead.CreatedDate = DateTime.Now;
                    dbLead.AssignDate = DateTime.Now;
                    dbLead.CreatedBy = lead.CreatedBy;
                    dbLead.AssignToUser = lead.AssignToUser;
                    dbLead.ContactCustomer = lead.ContactCustomer;
                    ClassOfTravel classt = (ClassOfTravel)Enum.Parse(typeof(ClassOfTravel), lead.LeadTypeName);
                    TripType triptype = (TripType)Enum.Parse(typeof(TripType), lead.LeadTypeName);
                    CustomerType customer = (CustomerType)Enum.Parse(typeof(CustomerType), lead.LeadTypeName);

                    LeadType type = (LeadType)Enum.Parse(typeof(LeadType), lead.LeadTypeName);
                    LeadStatus status = (LeadStatus)Enum.Parse(typeof(LeadStatus), lead.LeadStatusName);

                    dbLead.ClassOfTravel = Convert.ToInt32(classt);
                    dbLead.TripTyepLead = Convert.ToInt32(triptype);
                    dbLead.CustomerType = Convert.ToInt32(customer);
                    dbLead.LeadType = Convert.ToInt32(type);
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
                    dbLead.ContactCustomer = lead.ContactCustomer;
                    dbLead.FirstName = lead.FirstName;
                    dbLead.LastName = lead.LastName;
                    dbLead.LeadTitle = lead.LeadTitle;
                    dbLead.Email = lead.Email;
                    dbLead.Address = lead.Address;
                    dbLead.Telephone = lead.Telephone;

                    ClassOfTravel classt = (ClassOfTravel)Enum.Parse(typeof(ClassOfTravel), lead.ClassOfTravelName);
                    TripType triptype = (TripType)Enum.Parse(typeof(TripType), lead.TripTypeName);
                    CustomerType customer = (CustomerType)Enum.Parse(typeof(CustomerType), lead.CustomeTypeName);

                    LeadType type = (LeadType)Enum.Parse(typeof(LeadType), lead.LeadTypeName);
                    LeadStatus status = (LeadStatus)Enum.Parse(typeof(LeadStatus), lead.LeadStatusName);

                    dbLead.ClassOfTravel = Convert.ToInt32(classt);
                    dbLead.TripTyepLead = Convert.ToInt32(triptype);
                    dbLead.CustomerType = Convert.ToInt32(customer);
                    dbLead.LeadType = Convert.ToInt32(type);
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

        [HttpPost]

        public ServiceResponse ChangeStatus(LeadModel lead)
        {
            try
            {
                if(lead.Id!=0)
                {
                    Lead dbLead = bllLead.GetByPK(lead.Id);

                    LeadStatus status = (LeadStatus)Enum.Parse(typeof(LeadStatus), lead.LeadStatusName);
                    dbLead.LeadStatus = Convert.ToInt32(status);

                    bllLead.ChangeStatus(dbLead);
                    result.IsSucceeded = true;
                    result.Message = "Status is updated to " + lead.LeadStatusName;
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
