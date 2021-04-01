using FlightoUs.Dal;
using FlightoUs.Model.Data;
using FlightoUs.Model.Filter;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlightoUs.Bll
{
    public class BllHotel
    {
        DalHotel dalHotel = new DalHotel();
        /// <summary>
        /// This function get User object by Primary Key
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        public Hotel GetByPK(int Id)
        {
            return dalHotel.GetByPK(Id);
        }

        /// <summary>
        /// This function inserts a new record of User
        /// </summary>
        /// <param name="user"></param>
        /// <returns>returns Primary Key of new record</returns>
        public int Insert(Hotel hotel)
        {
            return dalHotel.Insert(hotel);
        }
        public Hotel GetHotelByLead(int leadid)
        {
            return dalHotel.GetHotelByLead(leadid);
        }
        /// <summary>
        /// This function updates User
        /// </summary>
        /// <param name="user"></param>
        public void Update(Hotel hotel)
        {
            dalHotel.Update(hotel);
        }

        /// <summary>
        /// This function returns all records of User
        /// </summary>
        /// <returns>List of User</returns>
        public List<Hotel> GetAllHotels()
        {
            return dalHotel.GetAllHotels();
        }

        /// <summary>
        /// This function deletes User by its Primary Key 
        /// and returns True in case of Success
        /// </summary>
        /// <param name="Id"></param>
        /// <returns>True/False</returns>
        public Boolean Delete(int Id)
        {
            return dalHotel.Delete(Id);
        }

        /// <summary>
        /// This function performs search query after applying different filters
        /// This function also does sorting and pagination as per the parameters of filter object
        /// </summary>
        /// <param name="filters"></param>
        /// <returns>IEnumerable<dynamic></returns>
        public List<Hotel> Search(HotelSearchFilter filters)
        {
            return dalHotel.Search(filters);
        }

        /// <summary>
        /// This function executes count query after applying different filters
        /// </summary>
        /// <param name="filters"></param>
        /// <returns>Count of searched recored as integer value</returns>
        public int GetSearchCount(HotelSearchFilter filters)
        {
            return dalHotel.GetSearchCount(filters);
        }
    }
}
