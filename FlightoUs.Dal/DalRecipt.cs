using FlightoUs.Model.Data;
using FlightoUs.Model.Filter;
using System;

using System.Collections.Generic;
using System.Linq.Dynamic.Core;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FlightoUs.Model.Services;

namespace FlightoUs.Dal
{
    public class DalRecipt
    {
        /// <summary>
        /// This function get User object by Primary Key
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        public Recipt GetByPK(int Id)
        {
            using (var entities = new ApplicationDbContext())
            {
                return entities.Recipts.FirstOrDefault(p => p.Id == Id);
            }
        }

        /// <summary>
        /// This function inserts a new record of User
        /// </summary>
        /// <param name="user"></param>
        /// <returns>returns Primary Key of new record</returns>
        public int Insert(Recipt recipt)
        {
            using (var entities = new ApplicationDbContext())
            {
                entities.Recipts.Add(recipt);
                entities.SaveChanges();
                return recipt.Id;
            }
        }
        //public Recipt GetReciptByLeadIdAndReciptNo(int leadIdReciptNo)
        //{
        //    using (var entities = new ApplicationDbContext())
        //    {
        //        return entities.Recipts.FirstOrDefault(p => p.Lead_Id == leadIdReciptNo);
        //    }
        //}

        /// <summary>
        /// This function updates User
        /// </summary>
        /// <param name="user"></param>
        public void Update(Recipt recipt)
        {
            using (var entities = new ApplicationDbContext())
            {
                Recipt dbRecipt = entities.Recipts.SingleOrDefault(p => p.Id == recipt.Id);
                dbRecipt.ReciptNo = recipt.ReciptNo;
                entities.SaveChanges();
            }
        }



        /// <summary>
        /// This function returns all records of User
        /// </summary>
        /// <returns>List of User</returns>
        public List<Recipt> GetAllRecipts()
        {
            using (var entities = new ApplicationDbContext())
            {
                try
                {
                    return entities.Recipts.ToList();
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
                Recipt dbRecipt = entities.Recipts.SingleOrDefault(p => p.Id == Id);

                if (dbRecipt == null)
                    return false;

                entities.Recipts.Remove(dbRecipt);

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
        
        public List<ReciptDbModel> Search(ReciptSearchFilter filters)
        {
            int skip = (filters.PageIndex - 1) * filters.PageSize;
           
            using (var entities = new ApplicationDbContext())
            {
                var query = from Recipt in entities.Recipts
                            where Recipt.CreatedBy==filters.UserId
                            select new ReciptDbModel{ 
                                Id=Recipt.Id,
                                ReciptNo=Recipt.ReciptNo,
                                LeadTitle=Recipt.Lead.LeadTitle,
                                CreatedDate=Recipt.CreatedDate,
                                ContactNumber=Recipt.Lead.Telephone,
                                CreatedByStr=Recipt.User.FirstName
                            };

           

                if (string.IsNullOrEmpty(filters.Sort))
                {
                    filters.Sort = "Id Desc";
                }

                var lst= query.OrderBy(filters.Sort).Skip(skip).Take(filters.PageSize).ToList();
                foreach (var Recipt in lst)
                {
                    Recipt.CreatedDateStr = string.Format("{0:MM/dd/yyyy}", Recipt.CreatedDate);
                }
                return lst;
            }
        }
        public List<ReciptDbModel> SearchAdmin(ReciptSearchFilter filters)
        {
            int skip = (filters.PageIndex - 1) * filters.PageSize;

            using (var entities = new ApplicationDbContext())
            {
                var query = from Recipt in entities.Recipts
                            select new ReciptDbModel
                            {
                                Id = Recipt.Id,
                                ReciptNo = Recipt.ReciptNo,
                                LeadTitle = Recipt.Lead.LeadTitle,
                                CreatedDate = Recipt.CreatedDate,
                                ContactNumber = Recipt.Lead.Telephone,
                                CreatedByStr = Recipt.User.FirstName
                            };



                if (string.IsNullOrEmpty(filters.Sort))
                {
                    filters.Sort = "Id Desc";
                }

                var lst = query.OrderBy(filters.Sort).Skip(skip).Take(filters.PageSize).ToList();
                foreach (var Recipt in lst)
                {
                    Recipt.CreatedDateStr = string.Format("{0:MM/dd/yyyy}", Recipt.CreatedDate);
                }
                return lst;
            }
        }
        /// <summary>
        /// This function executes count query after applying different filters
        /// </summary>
        /// <param name="filters"></param>
        /// <returns>Count of searched recored as integer value</returns>
        public int GetSearchCount(ReciptSearchFilter filters)
        {
            using (var entities = new ApplicationDbContext())
            {
                var query = from Recipt in entities.Recipts
                            where Recipt.CreatedBy == filters.UserId
                            select Recipt;

                return query.Count();
            }
        }
        public int GetSearchCountAdmin(ReciptSearchFilter filters)
        {
            using (var entities = new ApplicationDbContext())
            {
                var query = from Recipt in entities.Recipts
                            select Recipt;

                return query.Count();
            }
        }
    }
}
