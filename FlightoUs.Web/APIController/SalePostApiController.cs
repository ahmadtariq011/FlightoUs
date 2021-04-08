using FlightoUs.Bll;
using FlightoUs.Bll.Helpers;
using FlightoUs.Model.Data;
using FlightoUs.Model.Enums;
using FlightoUs.Model.Filter;
using FlightoUs.Model.Services;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FlightoUs.Web.APIController
{
    [Produces("application/json")]
    [Route("api/[controller]/[action]")]
    public class SalePostApiController : Controller
    {
        BllSalePost bllSalePost = new BllSalePost();
        BllLead bllLead = new BllLead();
        BllUser bllUser = new BllUser();

        ServiceResponse result = new ServiceResponse();

        [HttpPost]
        public ServiceResponse GetSalePostsWithCount(SalePostSearchFilter filter)
        {
            try
            {
                //FlightoUs.Model.Data.User dbUser = bllUser.GetByPK(Convert.ToInt32(User.Identity.Name));
                //filter.UserType = dbUser.UserType;
                result.Message = bllSalePost.Search(filter);
                result.IsSucceeded = true;
                result.TotalCount = bllSalePost.GetSearchCount(filter);
            }
            catch (Exception ex)
            {
                result.IsSucceeded = false;
                result.Message = ex.Message + "<br>" + ex.StackTrace;
            }
            return result;

        }

        [HttpPost]
        public ServiceResponse SaleTicket(SalePostModel salePost)
        {
            try
            {
                if (salePost.Id == 0)
                {
                    TripType tript = (TripType)Enum.Parse(typeof(TripType), salePost.TripTypename);
                    SalePostType salet = (SalePostType)Enum.Parse(typeof(SalePostType), salePost.SaleTypename);
                    SalePost dbSalePost = new SalePost();
                    dbSalePost.Adults = salePost.Adults;
                    dbSalePost.ArrivalDate = salePost.ArrivalDate;
                    dbSalePost.Children = salePost.Children;
                    dbSalePost.City = salePost.City;
                    dbSalePost.Country = salePost.Country;
                    dbSalePost.CreatedDate = DateTime.Now;
                    dbSalePost.DepartureDate = salePost.DepartureDate;
                    dbSalePost.From = salePost.From;
                    dbSalePost.Lead_Id = salePost.Lead_Id;
                    dbSalePost.Name = salePost.Name;
                    dbSalePost.NetValue = salePost.NetValue;
                    dbSalePost.PNR = salePost.PNR;
                    dbSalePost.PSF = salePost.PSF;
                    dbSalePost.Sector = salePost.Sector;
                    dbSalePost.To = salePost.To;
                    dbSalePost.TotalValue = salePost.TotalValue;
                    dbSalePost.User_Id = salePost.User_Id;
                    dbSalePost.TripType = Convert.ToInt32(tript);
                    dbSalePost.SalePostType = Convert.ToInt32(salet);

                    int LeadId = bllSalePost.Insert(dbSalePost);
                    result.IsSucceeded = true;
                    result.TotalCount = LeadId;
                    result.Message = "Sale Post About Ticket is added";
                }

                //var userin=bllUser.GetByPK(salePost.User_Id);
                //var usertt = userin.UserType;
                //string usertype = EnumHelper.GetEnumByValue<UserRoleType>(usertt.ToString()).ToString();
                ////if (usertype=="Admin")
                ////{
                ////    result.Message = "/Admin/UserIndex";
                ////}
                ////else if (usertype == "Manager")
                ////{
                ////    result.Message = "/Manager/UserIndex";
                ////}
                ////else if (usertype == "User")
                ////{
                ////    result.Message = "/User/UserIndex";
                ////}

            }
            catch (Exception e)
            {
                result.IsSucceeded = false;
                result.Message = e.Message + "<br>" + e.StackTrace;
            }
            return result;
        }

        [HttpPost]
        public ServiceResponse SaleHotel(SalePostModel salePost)
        {
            try
            {
                if (salePost.Id == 0)
                {
                    SalePostType salet = (SalePostType)Enum.Parse(typeof(SalePostType), salePost.SaleTypename);
                    SalePost dbSalePost = new SalePost();
                    dbSalePost.City = salePost.City;
                    dbSalePost.Country = salePost.Country;
                    dbSalePost.CreatedDate = DateTime.Now;
                    dbSalePost.Lead_Id = salePost.Lead_Id;
                    dbSalePost.Name = salePost.Name;
                    dbSalePost.NetValue = salePost.NetValue;
                    dbSalePost.PSF = salePost.PSF;
                    dbSalePost.TotalValue = salePost.TotalValue;
                    dbSalePost.User_Id = salePost.User_Id;
                    dbSalePost.SalePostType = Convert.ToInt32(salet);

                    int LeadId = bllSalePost.Insert(dbSalePost);
                    result.IsSucceeded = true;
                    result.TotalCount = LeadId;
                    result.Message = "Sale Post About Hotel is added";

                }
                //var userin = bllUser.GetByPK(salePost.User_Id);
                //var usertt = userin.UserType;
                //string usertype = EnumHelper.GetEnumByValue<UserRoleType>(usertt.ToString()).ToString();
                //if (usertype == "Admin")
                //{
                //    result.Message = "/Admin/UserIndex";
                //}
                //else if (usertype == "Manager")
                //{
                //    result.Message = "/Manager/UserIndex";
                //}
                //else if (usertype == "User")
                //{
                //    result.Message = "/User/UserIndex";
                //}

            }
            catch (Exception e)
            {
                result.IsSucceeded = false;
                result.Message = e.Message + "<br>" + e.StackTrace;
            }
            return result;
        }

        [HttpPost]
        public ServiceResponse SaleOther(SalePostModel salePost)
        {
            try
            {
                if (salePost.Id == 0)
                {
                    SalePostType salet = (SalePostType)Enum.Parse(typeof(SalePostType), salePost.SaleTypename);
                    SalePost dbSalePost = new SalePost();
                    dbSalePost.City = salePost.City;
                    dbSalePost.Country = salePost.Country;
                    dbSalePost.CreatedDate = DateTime.Now;
                    dbSalePost.Lead_Id = salePost.Lead_Id;
                    dbSalePost.Name = salePost.Name;
                    dbSalePost.NetValue = salePost.NetValue;
                    dbSalePost.PSF = salePost.PSF;
                    dbSalePost.TotalValue = salePost.TotalValue;
                    dbSalePost.User_Id = salePost.User_Id;
                    dbSalePost.SalePostType = Convert.ToInt32(salet);

                    int LeadId = bllSalePost.Insert(dbSalePost);
                    result.IsSucceeded = true;
                    result.TotalCount = LeadId;
                    result.Message = "Other Sale Post is added";

                }
                //var userin = bllUser.GetByPK(salePost.User_Id);
                //var usertt = userin.UserType;
                //string usertype = EnumHelper.GetEnumByValue<UserRoleType>(usertt.ToString()).ToString();
                //if (usertype == "Admin")
                //{
                //    result.Message = "/Admin/UserIndex";
                //}
                //else if (usertype == "Manager")
                //{
                //    result.Message = "/Manager/UserIndex";
                //}
                //else if (usertype == "User")
                //{
                //    result.Message = "/User/UserIndex";
                //}

            }
            catch (Exception e)
            {
                result.IsSucceeded = false;
                result.Message = e.Message + "<br>" + e.StackTrace;
            }
            return result;
        }

    }
}
