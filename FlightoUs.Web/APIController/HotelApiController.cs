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
    public class HotelApiController : Controller
    {
        BllHotel bllHotel = new BllHotel();
        ServiceResponse result = new ServiceResponse();

        [HttpPost]
        public ServiceResponse SaveHotel(Hotel hotel)
        {
            try
            {
                if (hotel.Id == 0)
                {
                    Hotel dbHotel = new Hotel();

                    dbHotel.City = hotel.City;
                    dbHotel.Country = hotel.Country;
                    dbHotel.CreatedDate = DateTime.Now;
                    dbHotel.Lead_Id = hotel.Lead_Id;
                    dbHotel.Name = hotel.Name;
                    dbHotel.NetValue = hotel.NetValue;
                    dbHotel.PSF = hotel.PSF;
                    dbHotel.TotalValue = hotel.TotalValue;
                    dbHotel.User_Id = hotel.User_Id;

                    int LeadId = bllHotel.Insert(dbHotel);
                    result.IsSucceeded = true;
                    result.TotalCount = LeadId;
                }
                else
                {
                    Hotel dbHotel = bllHotel.GetByPK(hotel.Id);

                    dbHotel.City = hotel.City;
                    dbHotel.Country = hotel.Country;
                    dbHotel.Name = hotel.Name;
                    dbHotel.NetValue = hotel.NetValue;
                    dbHotel.PSF = hotel.PSF;
                    dbHotel.TotalValue = hotel.TotalValue;

                    bllHotel.Update(dbHotel);
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
