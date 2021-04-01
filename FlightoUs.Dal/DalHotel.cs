using FlightoUs.Model.Data;
using FlightoUs.Model.Filter;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Text;
using System.Threading.Tasks;

namespace FlightoUs.Dal
{
    public class DalHotel
    {
        /// <summary>
        /// This function get User object by Primary Key
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        public Hotel GetByPK(int Id)
        {
            using (var entities = new ApplicationDbContext())
            {
                return entities.Hotels.FirstOrDefault(p => p.Id == Id);
            }
        }

        /// <summary>
        /// This function inserts a new record of User
        /// </summary>
        /// <param name="user"></param>
        /// <returns>returns Primary Key of new record</returns>
        public int Insert(Hotel hotel)
        {
            using (var entities = new ApplicationDbContext())
            {
                entities.Hotels.Add(hotel);
                entities.SaveChanges();
                return hotel.Id;
            }
        }
        public Hotel GetHotelByLead(int leadid)
        {
            using (var entities = new ApplicationDbContext())
            {
                return entities.Hotels.FirstOrDefault(p => p.Lead_Id == leadid);
            }
        }
        /// <summary>
        /// This function updates User
        /// </summary>
        /// <param name="user"></param>
        public void Update(Hotel hotel)
        {
            using (var entities = new ApplicationDbContext())
            {

                entities.SaveChanges();
            }
        }



        /// <summary>
        /// This function returns all records of User
        /// </summary>
        /// <returns>List of User</returns>
        public List<Hotel> GetAllHotels()
        {
            using (var entities = new ApplicationDbContext())
            {
                try
                {
                    return entities.Hotels.ToList();
                }
                catch (Exception ex)
                {
                    // Log Exception
                    throw ex;
                }
            }
        }

        /// <summary>
        /// This function deletes User by its Primary Key 
        /// and returns True in case of Success
        /// </summary>
        /// <param name="Id"></param>
        /// <returns>True/False</returns>
        public Boolean Delete(int Id)
        {
            using (var entities = new ApplicationDbContext())
            {
                Hotel dbHotel = entities.Hotels.SingleOrDefault(p => p.Id == Id);

                if (dbHotel == null)
                    return false;

                entities.Hotels.Remove(dbHotel);

                entities.SaveChanges();
            }
            return true;
        }

        /// <summary>
        /// This function performs search query after applying different filters
        /// This function also does sorting and pagination as per the parameters of filter object
        /// </summary>
        /// <param name="filters"></param>
        /// <returns>IEnumerable<dynamic></returns>
        public List<Hotel> Search(HotelSearchFilter filters)
        {
            int skip = (filters.PageIndex - 1) * filters.PageSize;

            using (var entities = new ApplicationDbContext())
            {
                var query = from hotel in entities.Hotels
                            select hotel;

               



                if (string.IsNullOrEmpty(filters.Sort))
                {
                    filters.Sort = "Id Desc";
                }

                return query.OrderBy(filters.Sort).Skip(skip).Take(filters.PageSize).ToList();
            }
        }

        /// <summary>
        /// This function executes count query after applying different filters
        /// </summary>
        /// <param name="filters"></param>
        /// <returns>Count of searched recored as integer value</returns>
        public int GetSearchCount(HotelSearchFilter filters)
        {
            using (var entities = new ApplicationDbContext())
            {
                var query = from hotel in entities.Hotels
                                //where user.UserType == filters.UserType
                            select hotel;



                return query.Count();
            }
        }
    }
}
