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
    public class BllTicket
    {
        DalTickets dalTicket = new DalTickets();
        /// <summary>
        /// This function get User object by Primary Key
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        public Ticket GetByPK(int Id)
        {
            return dalTicket.GetByPK(Id);
        }

        /// <summary>
        /// This function inserts a new record of User
        /// </summary>
        /// <param name="user"></param>
        /// <returns>returns Primary Key of new record</returns>
        public int Insert(Ticket ticket)
        {
            return dalTicket.Insert(ticket);
        }
        public Ticket GetTicketByLead(int leadid)
        {
            return dalTicket.GetTicketByLead(leadid);
        }
        /// <summary>
        /// This function updates User
        /// </summary>
        /// <param name="user"></param>
        public void Update(Ticket ticket)
        {
            dalTicket.Update(ticket);
        }

        /// <summary>
        /// This function returns all records of User
        /// </summary>
        /// <returns>List of User</returns>
        public List<Ticket> GetAllTickets()
        {
            return dalTicket.GetAllTickets();
        }

        /// <summary>
        /// This function deletes User by its Primary Key 
        /// and returns True in case of Success
        /// </summary>
        /// <param name="Id"></param>
        /// <returns>True/False</returns>
        public Boolean Delete(int Id)
        {
            return dalTicket.Delete(Id);
        }

        /// <summary>
        /// This function performs search query after applying different filters
        /// This function also does sorting and pagination as per the parameters of filter object
        /// </summary>
        /// <param name="filters"></param>
        /// <returns>IEnumerable<dynamic></returns>
        public List<Ticket> Search(TicketSearchFilter filters)
        {
            return dalTicket.Search(filters);
        }

        /// <summary>
        /// This function executes count query after applying different filters
        /// </summary>
        /// <param name="filters"></param>
        /// <returns>Count of searched recored as integer value</returns>
        public int GetSearchCount(TicketSearchFilter filters)
        {
            return dalTicket.GetSearchCount(filters);
        }
    }
}
