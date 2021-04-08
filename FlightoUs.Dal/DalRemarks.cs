using FlightoUs.Model.Data;
using FlightoUs.Model.Filter;
using FlightoUs.Model.Services;
using System;
using System.Collections.Generic;
using System.Linq;

using System.Linq.Dynamic.Core;
using System.Text;
using System.Threading.Tasks;

namespace FlightoUs.Dal
{
    public class DalRemarks
    {

        /// <summary>
        /// This function get User object by Primary Key
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        public Remarks GetByPK(int Id)
        {
            using (var entities = new ApplicationDbContext())
            {
                return entities.Remarks.FirstOrDefault(p => p.Id == Id);
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
        // public Remarks GetByEmailLeads(string email)
        //{
        //  using (var entities = new ApplicationDbContext())
        //{
        //        return entities.Remarks.FirstOrDefault(p => p.Email == email);
        // }
        // }
        //  public Lead GetByUsernameLeads(string username)
        // {
        //   using (var entities = new ApplicationDbContext())
        //     {
        //        return entities.Leads.FirstOrDefault(p => p.UserName == username);
        //    }
        // }

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
        public int Insert(Remarks remarks)
        {
            using (var entities = new ApplicationDbContext())
            {
                entities.Remarks.Add(remarks);
                entities.SaveChanges();
                return remarks.Id;
            }
        }

        /// <summary>
        /// This function updates User
        /// </summary>
        /// <param name="user"></param>
        public void Update(Remarks remarks)
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
        public Remarks GetRemarkByLead(int leadid)
        {
            using (var entities = new ApplicationDbContext())
            {
                return entities.Remarks.FirstOrDefault(p => p.Lead_Id == leadid);
            }
        }

        /// <summary>
        /// This function returns all records of User
        /// </summary>
        /// <returns>List of User</returns>
        public List<Remarks> GetAllRemarks()
        {
            using (var entities = new ApplicationDbContext())
            {
                try
                {
                    return entities.Remarks.ToList();
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
                Remarks dbRemarks = entities.Remarks.SingleOrDefault(p => p.Id == Id);

                if (dbRemarks == null)
                    return false;

                entities.Remarks.Remove(dbRemarks);

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

        public List<RemarksModel> Search(RemarksSearchFilter filters)
        {
            int skip = (filters.PageIndex - 1) * filters.PageSize;

            using (var entities = new ApplicationDbContext())
            {
                var query = from remarks in entities.Remarks
                                //where user.UserType == filters.UserType
                            select new RemarksModel { 
                                Id=remarks.Id,
                                ContactDate=remarks.ContactDate,
                                CreatedDate=remarks.CreatedDate,
                                Details=remarks.Details
                            };

                if (string.IsNullOrEmpty(filters.Sort))
                {
                    filters.Sort = "Id Desc";
                }
                var lst= query.ToList();
                foreach (var remark in lst)
                {
                    remark.CreatedDateStr = string.Format("{0:MM/dd/yyyy}", remark.CreatedDate);
                    remark.ContactDateStr = string.Format("{0:MM/dd/yyyy}", remark.ContactDate);
                }
                return lst;
            }
        }
        public int GetSearchCount(RemarksSearchFilter filter)
        {
            using (var entities = new ApplicationDbContext())
            {
                var query = from remarks in entities.Remarks
                            where remarks.Lead_Id==filter.LeadId
                            select remarks;
                return query.Count();
            }
        }

        /// <summary>
        /// This function executes count query after applying different filters
        /// </summary>
        /// <param name="filters"></param>
        /// <returns>Count of searched recored as integer value</returns>

    }
}
