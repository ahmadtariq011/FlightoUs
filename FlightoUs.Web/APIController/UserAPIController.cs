using FlightoUs.Bll;
using FlightoUs.Model.Data;
using FlightoUs.Model.Services;
using FlightoUs.Models.Filters;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FlightoUs.Web.APIController
{
    [Produces("application/json")]
    [Route("api/[controller]/[action]")]
    public class UserAPIController : Controller
    {

        BllUser bllUser = new BllUser();

        ServiceResponse result = new ServiceResponse();

        [HttpPost]
        public ServiceResponse SaveUser(User user)
        {
            try
            {
                if (bllUser.GetByPK(user.Id) == null)
                {
                    User dbUser = new User();
                    dbUser.FirstName = user.FirstName;
                    dbUser.LastName = user.LastName;
                    dbUser.UserName = user.UserName;
                    dbUser.Email = user.Email;
                    dbUser.Password = user.Password;
                    dbUser.Telephone = user.Telephone;
                    dbUser.CNIC = user.CNIC;
                    dbUser.CreatedDate= DateTime.Now;
                    dbUser.UserType = user.UserType;
                    dbUser.GenderType = user.GenderType;


                    int UserId = bllUser.Insert(dbUser);
                    result.IsSucceeded = true;
                    result.TotalCount = UserId;
                }
                else
                {
                    User dbUser = bllUser.GetByPK(user.Id);

                    dbUser.FirstName = user.FirstName;
                    dbUser.LastName = user.LastName;
                    dbUser.Password = user.Password;
                    dbUser.Telephone = user.Telephone;
                    dbUser.CNIC = user.CNIC;
                    dbUser.UserType = user.UserType;
                    dbUser.GenderType = user.GenderType;


                    bllUser.Update(dbUser);
                    result.IsSucceeded = true;
                }
            }
            catch (Exception ex)
            {

                result.IsSucceeded = false;
                result.Message = ex.Message+"<br>"+ex.StackTrace;
            }
            return result;
        }

        [HttpPost]
        public ServiceResponse DeleteUser (int Id)
        {
            try
            {

                bllUser.DeleteUser(Id);
                result.IsSucceeded = true;
                result.Message = "User Deleted Successfully";
            }

            catch(Exception e)
            {
                result.IsSucceeded = false;
                result.Message = e.Message + " </br> " + e.StackTrace;
            }
            return result;
        }
        
        [HttpPost]
        public ServiceResponse GetAllUsers()
        {
            try
            {
                result.Message = bllUser.GetAllUsers();
            }
            catch (Exception ex)
            {
                result.IsSucceeded = false;
                result.Message = ex.Message + "<br>" + ex.StackTrace;
            }
            return result;
        }

        [HttpPost]

        public ServiceResponse GetByEmail(string email)
        {
            try
            {
                result.Message = bllUser.GetByEmail(email);
            }
            catch(Exception e)
            {
                result.IsSucceeded = false;
                result.Message = e.Message + "<br>" + e.StackTrace;
            }
            return result;
        }


        [HttpPost]
        public ServiceResponse GetUsersWithCount(UserSearchFilter filter)
        {
            try
            {
                var lst = bllUser.Search(filter);
                result.Message = lst;
                result.TotalCount = bllUser.GetSearchCount(filter);
            }
            catch (Exception ex)
            {
                result.IsSucceeded = false;
                result.Message = ex.Message + "<br>" + ex.StackTrace;
            }
            return result;
        }

        [HttpPost]
        public ServiceResponse GetUsers(UserSearchFilter filter)
        {
            try
            {
                result.Message = bllUser.Search(filter);
            }
            catch (Exception ex)
            {
                result.IsSucceeded = false;
                result.Message = ex.Message + "<br>" + ex.StackTrace;
            }
            return result;
        }

    }
}



/*
BllUser bllUser = new BllUser();
private ServiceResponse result = new ServiceResponse { IsSucceeded = true };

*/
