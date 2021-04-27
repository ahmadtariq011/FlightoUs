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
    public class BllCashBook
    {

        DalCashBook dalCashBook = new DalCashBook();
        public CashBook GetByPK(int Id)
        {
            return dalCashBook.GetByPK(Id);
        }
        public int Insert(CashBook cashBook)
        {
            return dalCashBook.Insert(cashBook);
        }
        public void Update(CashBook cashBook)
        {
            dalCashBook.Update(cashBook);
        }
        public Boolean Delete(int Id)
        {
            return dalCashBook.Delete(Id);
        }

        public List<CashBookModel> Search(CashBookSearchFilter filters)
        {
            return dalCashBook.Search(filters);
        }
        public int GetSearchCount(CashBookSearchFilter filters)
        {
            return dalCashBook.GetSearchCount(filters);
        }

    }
}
