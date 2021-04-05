using FlightoUs.Bll;
using FlightoUs.Model.Data;
using FlightoUs.Model.Enums;
using FlightoUs.Model.Services;
using FlightoUs.Models.Filters;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
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
        public ServiceResponse SaveUser(UserModel user)
        {
            try
            {
                bool IsAdmin = User.IsInRole(UserRoleType.Admin.ToString());
                bool IsManager = User.IsInRole(UserRoleType.Manager.ToString());
                bool IsUser = User.IsInRole(UserRoleType.User.ToString());
                string typeofUserLogin = "";
                if (IsAdmin)
                {
                    typeofUserLogin = "Admin";
                }
                if (IsManager)
                {
                    typeofUserLogin = "Manager";
                }
                if (IsUser)
                {
                    typeofUserLogin = "User";
                }
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
                    GenderType gender = (GenderType)Enum.Parse(typeof(GenderType), user.GenderTypename);
                    UserRoleType usertyp = (UserRoleType)Enum.Parse(typeof(UserRoleType), user.UserTypeName);
                    dbUser.UserType = Convert.ToInt32(usertyp);
                    dbUser.GenderType = Convert.ToInt32(gender);



                    int UserId = bllUser.Insert(dbUser);
                    result.IsSucceeded = true;
                    result.TotalCount = UserId;
                    result.Message = "/" + typeofUserLogin + "/UserIndex";

                }
                else
                {
                    User dbUser = bllUser.GetByPK(user.Id);

                    dbUser.FirstName = user.FirstName;
                    dbUser.LastName = user.LastName;
                    dbUser.UserName = user.UserName;
                    dbUser.Email = user.Email;
                    dbUser.Password = user.Password;
                    dbUser.Telephone = user.Telephone;
                    dbUser.CNIC = user.CNIC;
                    dbUser.CreatedDate = DateTime.Now;
                    GenderType gender= (GenderType)Enum.Parse(typeof(GenderType), user.GenderTypename);
                    UserRoleType usertyp = (UserRoleType)Enum.Parse(typeof(UserRoleType), user.UserTypeName);
                    dbUser.UserType = Convert.ToInt32(usertyp);
                    dbUser.GenderType = Convert.ToInt32(gender);


                    bllUser.Update(dbUser);
                    result.IsSucceeded = true;
                    result.Message = "/"+ typeofUserLogin + "/UserIndex";
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
        [HttpPost]
        public ServiceResponse Logout(UserSearchFilter type)
        {
            HttpContext.SignOutAsync(type.Keyword);
            result.Message = "/Home/Login";
            return result;
        }
    }
}



/*
BllUser bllUser = new BllUser();
private ServiceResponse result = new ServiceResponse { IsSucceeded = true };

*/
