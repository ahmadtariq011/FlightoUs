using FlightoUs.Bll;
using FlightoUs.Model.Data;
using FlightoUs.Model.Enums;
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
    public class TicketApiController : Controller
    {
        BllTicket bllTicket = new BllTicket();
        ServiceResponse result = new ServiceResponse();

        [HttpPost]
        public ServiceResponse SaveTicket(TicketModel ticket)
        {
            try
            {
                if (ticket.Id == 0)
                {
                    Ticket dbTicket = new Ticket();

                    dbTicket.From = ticket.From;
                    dbTicket.To = ticket.To;
                    dbTicket.ArrivalDate = ticket.ArrivalDate;
                    dbTicket.CreatedDate = DateTime.Now;
                    dbTicket.DepartureDate = ticket.DepartureDate;
                    dbTicket.Lead_Id = ticket.Lead_Id;
                    dbTicket.NetValue = ticket.NetValue;
                    dbTicket.PSF = ticket.PSF;
                    dbTicket.TotalValue = ticket.TotalValue;
                    dbTicket.User_Id = ticket.User_Id;

                    TripType type = (TripType)Enum.Parse(typeof(TripType), ticket.TripTypeName);
                    dbTicket.TripType = Convert.ToInt32(type);

                    int LeadId = bllTicket.Insert(dbTicket);
                    result.IsSucceeded = true;
                    result.TotalCount = LeadId;
                }
                else
                {
                    Ticket dbTicket = bllTicket.GetByPK(ticket.Id);

                    dbTicket.From = ticket.From;
                    dbTicket.To = ticket.To;
                    dbTicket.ArrivalDate = ticket.ArrivalDate;
                    dbTicket.DepartureDate = ticket.DepartureDate;
                    dbTicket.NetValue = ticket.NetValue;
                    dbTicket.PSF = ticket.PSF;
                    dbTicket.TotalValue = ticket.TotalValue;

                    TripType type = (TripType)Enum.Parse(typeof(TripType), ticket.TripTypeName);
                    dbTicket.TripType = Convert.ToInt32(type);

                    bllTicket.Update(dbTicket);
                    result.IsSucceeded = true;

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
