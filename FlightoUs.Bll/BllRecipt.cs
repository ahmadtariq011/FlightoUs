using FlightoUs.Dal;
using FlightoUs.Model.Data;
using FlightoUs.Model.Filter;
using FlightoUs.Model.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlightoUs.Bll
{
    public class BllRecipt
    {
        DalRecipt dalRecipt = new DalRecipt();
        /// <summary>
        /// This function get User object by Primary Key
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        public Recipt GetByPK(int Id)
        {
            return dalRecipt.GetByPK(Id);
        }

        /// <summary>
        /// This function inserts a new record of User
        /// </summary>
        /// <param name="user"></param>
        /// <returns>returns Primary Key of new record</returns>
        public int Insert(Recipt recipt)
        {
            return dalRecipt.Insert(recipt);
        }
        //public Ticket GetTicketByLead(int leadid)
        //{
        //    return dalRecipt.get(leadid);
        //}
        /// <summary>
        /// This function updates User
        /// </summary>
        /// <param name="user"></param>
        public void Update(Recipt recipt)
        {
            dalRecipt.Update(recipt);
        }

        /// <summary>
        /// This function returns all records of User
        /// </summary>
        /// <returns>List of User</returns>
        public List<Recipt> GetAllRecipts()
        {
            return dalRecipt.GetAllRecipts();
        }

        /// <summary>
        /// This function deletes User by its Primary Key 
        /// and returns True in case of Success
        /// </summary>
        /// <param name="Id"></param>
        /// <returns>True/False</returns>
        public Boolean Delete(int Id)
        {
            return dalRecipt.Delete(Id);
        }

        /// <summary>
        /// This function performs search query after applying different filters
        /// This function also does sorting and pagination as per the parameters of filter object
        /// </summary>
        /// <param name="filters"></param>
        /// <returns>IEnumerable<dynamic></returns>
        public List<ReciptDbModel> Search(ReciptSearchFilter filters)
        {
            return dalRecipt.Search(filters);
        }
        public List<ReciptDbModel> SearchAdmin(ReciptSearchFilter filters)
        {
            return dalRecipt.SearchAdmin(filters);
        }
        /// <summary>
        /// This function executes count query after applying different filters
        /// </summary>
        /// <param name="filters"></param>
        /// <returns>Count of searched recored as integer value</returns>
        public int GetSearchCount(ReciptSearchFilter filters)
        {
            return dalRecipt.GetSearchCount(filters);
        }
        public int GetSearchCountAdmin(ReciptSearchFilter filters)
        {
            return dalRecipt.GetSearchCountAdmin(filters);
        }
    }
}
