using FlightoUs.Bll;
using FlightoUs.Model.Data;
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
    public class LeadsApiController : Controller
    {
        BllLead bllLead = new BllLead();
        ServiceResponse result = new ServiceResponse();
        [HttpPost]
        public ServiceResponse GetLeadsWithCount(LeadSearchFilter filter)
        {
            try
            {
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
        public ServiceResponse SaveLeads(Lead lead)
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

                    dbLead.LeadType = lead.LeadType;
                    dbLead.LeadTypeDemand = lead.LeadTypeDemand;
                    dbLead.LeadStatus = lead.LeadStatus;

                    dbLead.AssignToUser = lead.AssignToUser;



                    int LeadId = bllLead.Insert(dbLead);
                    result.IsSucceeded = true;
                    result.TotalCount = LeadId;
                    result.Message = "Lead is Created Successfully";
                }
                else
                {
                    Lead dbLead = bllLead.GetByPK(lead.Id);

                    dbLead.FirstName = lead.FirstName;
                    dbLead.LastName = lead.LastName;

                    dbLead.CNIC = lead.CNIC;
                    dbLead.Email = lead.Email;
                    dbLead.Address = lead.Address;
                    dbLead.Telephone = lead.Telephone;

                    dbLead.LeadType = lead.LeadType;
                    dbLead.LeadTypeDemand = lead.LeadTypeDemand;
                    dbLead.LeadStatus = lead.LeadStatus;


                    bllLead.Update(dbLead);
                    result.IsSucceeded = true;

                }
            }
            catch(Exception e)
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
