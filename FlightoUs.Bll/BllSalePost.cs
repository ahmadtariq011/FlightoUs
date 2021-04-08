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
    public class BllSalePost
    {
        DalSalePost dalSalePost = new DalSalePost();
        public SalePost GetByPK(int Id)
        {
            return dalSalePost.GetByPK(Id);
        }
        public int Insert(SalePost salePost)
        {
            return dalSalePost.Insert(salePost);
        }
        public void Update(SalePost salePost)
        {
            dalSalePost.Update(salePost);
        }
        public Boolean Delete(int Id)
        {
            return dalSalePost.Delete(Id);
        }

        public List<SalePostModel> Search(SalePostSearchFilter filters)
        {
            return dalSalePost.Search(filters);
        }
        public int GetSearchCount(SalePostSearchFilter filters)
        {
            return dalSalePost.GetSearchCount(filters);
        }
    }
}
