using FlightoUs.Model.Data;
using FlightoUs.Model.Filter;
using FlightoUs.Models.Filters;
using System;
using System.Collections.Generic;
using System.Linq.Dynamic.Core;

using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlightoUs.Dal
{
    public class DalLeads
    {
        /// <summary>
        /// This function get User object by Primary Key
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        public Lead GetByPK(int Id)
        {
            using (var entities = new ApplicationDbContext())
            {
                return entities.Leads.FirstOrDefault(p => p.Id == Id);
            }
        }

        public Lead GetByEmailLeads(string email)
        {
            using (var entities = new ApplicationDbContext())
            {
                return entities.Leads.FirstOrDefault(p => p.Email == email);
            }
        }
        public Lead GetByUsernameLeads(string username)
        {
            using (var entities = new ApplicationDbContext())
            {
                return entities.Leads.FirstOrDefault(p => p.UserName == username);
            }
        }


        /// <summary>
        /// This function inserts a new record of User
        /// </summary>
        /// <param name="user"></param>
        /// <returns>returns Primary Key of new record</returns>
        public int Insert(Lead lead)
        {
            using (var entities = new ApplicationDbContext())
            {
                entities.Leads.Add(lead);
                entities.SaveChanges();
                return lead.Id;
            }
        }

        /// <summary>
        /// This function updates User
        /// </summary>
        /// <param name="user"></param>
        public void Update(Lead lead)
        {
            using (var entities = new ApplicationDbContext())
            {
                Lead dbLead = entities.Leads.SingleOrDefault(p => p.Id == lead.Id);
                dbLead.FirstName = lead.FirstName;
                dbLead.LastName = lead.LastName;
                dbLead.Email = lead.Email;
                dbLead.Telephone = lead.Telephone;
                dbLead.CNIC = lead.CNIC;
                dbLead.Address = lead.Address;
                dbLead.AssignToUser = lead.AssignToUser;
                dbLead.AssignDate = lead.AssignDate;
                dbLead.LeadType = lead.LeadType;
                dbLead.LeadTypeDemand = lead.LeadTypeDemand;
                dbLead.LeadStatus = lead.LeadStatus;
                entities.SaveChanges();
            }
        }


        
        /// <summary>
        /// This function returns all records of User
        /// </summary>
        /// <returns>List of User</returns>
        public List<Lead> GetAllLeads()
        {
            using (var entities = new ApplicationDbContext())
            {
                try
                {
                    return entities.Leads.ToList();
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
                Lead dbLead = entities.Leads.SingleOrDefault(p => p.Id == Id);

                if (dbLead == null)
                    return false;

                entities.Leads.Remove(dbLead);

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
        public List<Lead> Search(LeadSearchFilter filters)
        {
            int skip = (filters.PageIndex - 1) * filters.PageSize;

            using (var entities = new ApplicationDbContext())
            {
                var query = from lead in entities.Leads
                            select lead;

                if (!string.IsNullOrEmpty(filters.UserName))
                {
                    query = query.Where(p => p.UserName.Contains(filters.UserName));
                }

                if (!string.IsNullOrEmpty(filters.Email))
                {
                    query = query.Where(p => p.Email.Contains(filters.Email));
                }
                //if (filters.User_Id.HasValue && filters.User_Id != -1)
                //{
                //    query = query.Where(p => p.AssignToUser == filters.User_Id);
                //}


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
        public int GetSearchCount(LeadSearchFilter filters)
        {
            using (var entities = new ApplicationDbContext())
            {
                var query = from Lead in entities.Leads
                                //where user.UserType == filters.UserType
                            select Lead;


                if (!string.IsNullOrEmpty(filters.UserName))
                {
                    query = query.Where(p => p.UserName.Contains(filters.UserName));
                }

                if (!string.IsNullOrEmpty(filters.Email))
                {
                    query = query.Where(p => p.Email.Contains(filters.Email));
                }




                return query.Count();
            }
        }

    }
}
