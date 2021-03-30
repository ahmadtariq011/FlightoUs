using FlightoUs.Bll;
using FlightoUs.Model.Data;
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
