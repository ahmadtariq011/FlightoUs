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
        public ServiceResponse GetUsersWithCount(LeadSearchFilter filter)
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
        public ServiceResponse GetUsers(LeadSearchFilter filter)
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
            Lead dbLead = new Lead();
            if (lead.Id == 0)
            {
                dbLead.FirstName = lead.FirstName;
                dbLead.LastName = lead.LastName;
                dbLead.Telephone = lead.Telephone;

                int LeadId = bllLead.Insert(dbLead);
                result.IsSucceeded = true;
                result.TotalCount = LeadId;
                result.Message = "Lead is Created Successfully";
            }
            else
            {

            }
            return result;
        }
    }
}
