using FlightoUs.Model.Data;
using FlightoUs.Model.Filter;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Linq.Dynamic.Core;

using System.Threading.Tasks;
using FlightoUs.Model.Services;
using FlightoUs.Model.Enums;

namespace FlightoUs.Dal
{
    public class DalCashBook
    {

        /// <summary>
        /// This function get User object by Primary Key
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        public CashBook GetByPK(int Id)
        {
            using (var entities = new ApplicationDbContext())
            {
                return entities.CashBooks.FirstOrDefault(p => p.Id == Id);
            }
        }


        /// <summary>
        /// This function inserts a new record of User
        /// </summary>
        /// <param name="user"></param>
        /// <returns>returns Primary Key of new record</returns>
        public int Insert(CashBook cashBook)
        {
            using (var entities = new ApplicationDbContext())
            {
                entities.CashBooks.Add(cashBook);
                entities.SaveChanges();
                return cashBook.Id;
            }
        }
        public void Update(CashBook cashBook)
        {
            using (var entities = new ApplicationDbContext())
            {
                //Lead dbLead = entities.Leads.SingleOrDefault(p => p.Id == lead.Id);
                //dbLead.FirstName = lead.FirstName;
                //dbLead.LastName = lead.LastName;
                //dbLead.Email = lead.Email;
                //dbLead.Telephone = lead.Telephone;
                //dbLead.Address = lead.Address;
                //dbLead.AssignToUser = lead.AssignToUser;
                //dbLead.AssignDate = lead.AssignDate;
                //dbLead.LeadType = lead.LeadType;
                //dbLead.LeadStatus = lead.LeadStatus;
                //dbLead.LeadTitle = lead.LeadTitle;
                //dbLead.ContactCustomer = lead.ContactCustomer;
                //dbLead.ClassOfTravel = lead.ClassOfTravel;
                //dbLead.TripTyepLead = lead.TripTyepLead;
                //dbLead.CustomerType = lead.CustomerType;
                entities.SaveChanges();
            }
        }



        /// <summary>
        /// This function returns all records of User
        /// </summary>
        /// <returns>List of User</returns>
        //public List<Lead> GetAllSalesByUser(SalePostSearchFilter filter)
        //{
        //    using (var entities = new ApplicationDbContext())
        //    {
        //        try
        //        {
        //            return entities.Leads.where()ToList();
        //        }
        //        catch (Exception ex)
        //        {
        //            // Log Exception
        //            throw ex;
        //        }
        //    }
        //}

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
                CashBook dbcashBook = entities.CashBooks.SingleOrDefault(p => p.Id == Id);

                if (dbcashBook == null)
                    return false;

                entities.CashBooks.Remove(dbcashBook);

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
        public List<CashBookModel> Search(CashBookSearchFilter filters)
        {
            int skip = (filters.PageIndex - 1) * filters.PageSize;

            using (var entities = new ApplicationDbContext())
            {
                var query = from CashBooks in entities.CashBooks
                            select new CashBookModel {

                                Id = CashBooks.Id,
                                Name = CashBooks.Name,
                                Amount = CashBooks.Amount,
                                Remarks = CashBooks.Remarks,
                                PaymentMode = CashBooks.PaymentMode,
                                CreatedDate = CashBooks.CreatedDate
                            };

                //if (filters.UserType != 1)
                //{
                //    if (filters.User_Id.HasValue && filters.User_Id != -1)
                //    {
                //        query = query.Where(p => p.AssignToUser == filters.User_Id);
                //    }
                //}


                if (string.IsNullOrEmpty(filters.Sort))
                {
                    filters.Sort = "Id Desc";
                }

                var lst = query.OrderBy(filters.Sort).Skip(skip).Take(filters.PageSize).ToList();

                foreach (var cashes in lst)
                {
                    cashes.ToBeUsedStr = string.Format("{0:MM/dd/yyyy}", cashes.CreatedDate);
                    cashes.PaymentModeStr = System.Enum.Parse(typeof(PaymentMode), cashes.PaymentMode.ToString()).ToString();

                }
                return lst;
            }
        }

        /// <summary>
        /// This function executes count query after applying different filters
        /// </summary>
        /// <param name="filters"></param>
        /// <returns>Count of searched recored as integer value</returns>
        public int GetSearchCount(CashBookSearchFilter filters)
        {
            using (var entities = new ApplicationDbContext())
            {
                var query = from CashBooks in entities.CashBooks
                                //where user.UserType == filters.UserType
                            select CashBooks;


                return query.Count();
            }
        }
    }
}
