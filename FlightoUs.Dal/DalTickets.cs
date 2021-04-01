using FlightoUs.Model.Data;
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

        //public User AdminLogin(string userId, string password)
        //{
        //    using (var entities = new ApplicationDbContext())
        //    {
        //        int adminUserType = Convert.ToByte(UserRoleType.Admin);
        //        return entities.Users.FirstOrDefault(p => p.UserId == userId && p.Password == password && p.UserType == adminUserType);
        //    }
        //}
        //public User Login(string email, string password)
        //{
        //    using (var entities = new ApplicationDbContext())
        //    {
        //        int userType = Convert.ToByte(UserRoleType.User);
        //        return entities.Users.FirstOrDefault(p => p.Email == email && p.Password == password && p.UserType == userType);
        //    }
        //}
        public Ticket GetByToTickets(string to)
        {
            using (var entities = new ApplicationDbContext())
            {
                return entities.Tickets.FirstOrDefault(p => p.To == to);
            }
        }
        public Ticket GetByFromTickets(string from)
        {
            using (var entities = new ApplicationDbContext())
            {
                return entities.Tickets.FirstOrDefault(p => p.From == from);
            }
        }

        //public int GetTotalUsers()
        //{
        //    using (var entities = new ApplicationDbContext())
        //    {
        //        int type = Convert.ToInt32(UserRoleType.User);
        //        return entities.Users.Count(p => p.UserType == type);
        //    }
        //}


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

        /// <summary>
        /// This function updates User
        /// </summary>
        /// <param name="user"></param>
        public void Update(Ticket ticket)
        {
            using (var entities = new ApplicationDbContext())
            {

                entities.SaveChanges();
            }
        }


        //public List<User> GetUsers()
        //{
        //    using (var entities = new ApplicationDbContext())
        //    {
        //        try
        //        {
        //            int type = Convert.ToInt32(UserRoleType.User);
        //            return entities.Users.Where(p => p.UserType == type).ToList();
        //        }
        //        catch (Exception ex)
        //        {
        //            // Log Exception
        //            throw ex;
        //        }
        //    }
        //}

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
        //public List<Ticket> Search(TicketSearchFilter filters)
        //{
        //    int skip = (filters.PageIndex - 1) * filters.PageSize;

        //    using (var entities = new ApplicationDbContext())
        //    {
        //        var query = from ticket in entities.Tickets
        //                    select ticket;

        //        if (!string.IsNullOrEmpty(filters.From))
        //        {
        //            query = query.Where(p => p.From.Contains(filters.From));
        //        }

        //        if (!string.IsNullOrEmpty(filters.To))
        //        {
        //            query = query.Where(p => p.To.Contains(filters.To));
        //        }



        //        if (string.IsNullOrEmpty(filters.Sort))
        //        {
        //            filters.Sort = "Id Desc";
        //        }

        //        return query.OrderBy(filters.Sort).Skip(skip).Take(filters.PageSize).ToList();
        //    }
        //}

        ///// <summary>
        ///// This function executes count query after applying different filters
        ///// </summary>
        ///// <param name="filters"></param>
        ///// <returns>Count of searched recored as integer value</returns>
        //public int GetSearchCount(TicketsSearchFilter filters)
        //{
        //    using (var entities = new ApplicationDbContext())
        //    {
        //        var query = from ticket in entities.Tickets
        //                        //where user.UserType == filters.UserType
        //                    select ticket;


        //        if (!string.IsNullOrEmpty(filters.From))
        //        {
        //            query = query.Where(p => p.From.Contains(filters.From));
        //        }

        //        if (!string.IsNullOrEmpty(filters.To))
        //        {
        //            query = query.Where(p => p.To.Contains(filters.To));
        //        }




        //        return query.Count();
        //    }
        //}
    }
}
