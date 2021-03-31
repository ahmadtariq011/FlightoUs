using FlightoUs.Model.Data;
using FlightoUs.Model.Filter;
using System;
using System.Collections.Generic;
using FlightoUs.Dal;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlightoUs.Bll
{
    public class BllRemarks
    {
         DalRemarks dalRemarks = new DalRemarks();
        public Remarks GetByPK(int Id)
        {
            return dalRemarks.GetByPK(Id);
        }

   
        public int Insert(Remarks remarks)
        {
            return dalRemarks.Insert(remarks);
        }

        /// <summary>
        /// This function updates User
        /// </summary>
        /// <param name="user"></param>
        public void Update(Remarks remarks)
        {
            dalRemarks.Update(remarks);
        }
        public List<Remarks> GetAllLeads()
        {
            return dalRemarks.GetAllLeads();
        }

        /// <summary>
        /// This function deletes User by its Primary Key 
        /// and returns True in case of Success
        /// </summary>
        /// <param name="Id"></param>
        /// <returns>True/False</returns>
        public Boolean Delete(int Id)
        {
            return dalRemarks.Delete(Id);
        }

        /// <summary>
        /// This function performs search query after applying different filters
        /// This function also does sorting and pagination as per the parameters of filter object
        /// </summary>
        /// <param name="filters"></param>
        /// <returns>IEnumerable<dynamic></returns>
        public List<Remarks> Search(LeadSearchFilter filters)
        {
            return dalRemarks.Search(filters);
        }

        /// <summary>
        /// This function executes count query after applying different filters
        /// </summary>
        /// <param name="filters"></param>
        /// <returns>Count of searched recored as integer value</returns>
        public int GetSearchCount(LeadSearchFilter filters)
        {
            return dalRemarks.GetSearchCount(filters);
        }
    }
}
