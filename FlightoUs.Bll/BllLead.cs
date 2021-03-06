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
    public class BllLead
    {
        DalLeads dalLead = new DalLeads();
        public Lead GetByPK(int Id)
        {
            return dalLead.GetByPK(Id);
        }

        public Lead GetByEmailLeads(string email)
        {
            return dalLead.GetByEmailLeads(email);
        }

        public Lead GetByPhoneNoLeads(string email)
        {
            return dalLead.GetByPhoneNoLeads(email);
        }
        public Lead GetByUsernameLeads(string username)
        {
            return dalLead.GetByUsernameLeads(username);
        }

        public void ChangeStatus(Lead lead)
        {
            dalLead.ChangeStatus(lead);
        }
            public int Insert(Lead lead)
        {
            return dalLead.Insert(lead);
        }
        public void AddFreetext(Lead lead)
        {
            dalLead.AddFreeText(lead);
        }
        /// <summary>
        /// This function updates User
        /// </summary>
        /// <param name="user"></param>
        public void Update(Lead lead)
        {
            dalLead.Update(lead);
        }
        public List<Lead> GetAllLeads()
        {
            return dalLead.GetAllLeads();
        }

        /// <summary>
        /// This function deletes User by its Primary Key 
        /// and returns True in case of Success
        /// </summary>
        /// <param name="Id"></param>
        /// <returns>True/False</returns>
        public Boolean DeleteLeads(int Id)
        {
            return dalLead.Delete(Id);
        }

        /// <summary>
        /// This function performs search query after applying different filters
        /// This function also does sorting and pagination as per the parameters of filter object
        /// </summary>
        /// <param name="filters"></param>
        /// <returns>IEnumerable<dynamic></returns>
        public List<LeadModel> Search(LeadSearchFilter filters)
        {
            return dalLead.Search(filters);
        }
        /// <summary>
        /// This function executes count query after applying different filters
        /// </summary>
        /// <param name="filters"></param>
        /// <returns>Count of searched recored as integer value</returns>
        public int GetSearchCount(LeadSearchFilter filters)
        {
            return dalLead.GetSearchCount(filters);
        }

        public int GetSearchCountAdmin(LeadSearchFilter filters)
        {
            return dalLead.GetSearchCountAdmin(filters);
        }
    }
}
