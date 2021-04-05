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
    public class DalTickets
    {

        /// <summary>
        /// This function get User object by Primary Key
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        public Ticket GetByPK(int Id)
        {
            using (var entities = new ApplicationDbContext())
            {
                return entities.Tickets.FirstOrDefault(p => p.Id == Id);
            }
        }

        /// <summary>
        /// This function inserts a new record of User
        /// </summary>
        /// <param name="user"></param>
        /// <returns>returns Primary Key of new record</returns>
        public int Insert(Ticket ticket)
        {
            using (var entities = new ApplicationDbContext())
            {
                entities.Tickets.Add(ticket);
                entities.SaveChanges();
                return ticket.Id;
            }
        }
        public Ticket GetTicketByLead(int leadid)
        {
            using (var entities = new ApplicationDbContext())
            {
                return entities.Tickets.FirstOrDefault(p => p.Lead_Id == leadid);
            }
        }

        /// <summary>
        /// This function updates User
        /// </summary>
        /// <param name="user"></param>
        public void Update(Ticket ticket)
        {
            using (var entities = new ApplicationDbContext())
            {
                Ticket dbTicket = entities.Tickets.SingleOrDefault(p => p.Id == ticket.Id);

                dbTicket.From = ticket.From;
                dbTicket.To = ticket.To;
                dbTicket.ArrivalDate = ticket.ArrivalDate;
                dbTicket.DepartureDate = ticket.DepartureDate;
                dbTicket.NetValue = ticket.NetValue;
                dbTicket.PSF = ticket.PSF;
                dbTicket.TotalValue = ticket.TotalValue;
                dbTicket.TripType = ticket.TripType;
                entities.SaveChanges();
            }
        }



        /// <summary>
        /// This function returns all records of User
        /// </summary>
        /// <returns>List of User</returns>
        public List<Ticket> GetAllTickets()
        {
            using (var entities = new ApplicationDbContext())
            {
                try
                {
                    return entities.Tickets.ToList();
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
                Ticket dbTicket = entities.Tickets.SingleOrDefault(p => p.Id == Id);

                if (dbTicket == null)
                    return false;

                entities.Tickets.Remove(dbTicket);

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
        public List<Ticket> Search(TicketSearchFilter filters)
        {
            int skip = (filters.PageIndex - 1) * filters.PageSize;

            using (var entities = new ApplicationDbContext())
            {
                var query = from ticket in entities.Tickets
                            select ticket;

                if (!string.IsNullOrEmpty(filters.From))
                {
                    query = query.Where(p => p.From.Contains(filters.From));
                }

                if (!string.IsNullOrEmpty(filters.To))
                {
                    query = query.Where(p => p.To.Contains(filters.To));
                }



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
        public int GetSearchCount(TicketSearchFilter filters)
        {
            using (var entities = new ApplicationDbContext())
            {
                var query = from ticket in entities.Tickets
                                //where user.UserType == filters.UserType
                            select ticket;


                if (!string.IsNullOrEmpty(filters.From))
                {
                    query = query.Where(p => p.From.Contains(filters.From));
                }

                if (!string.IsNullOrEmpty(filters.To))
                {
                    query = query.Where(p => p.To.Contains(filters.To));
                }




                return query.Count();
            }
        }
    }
}
