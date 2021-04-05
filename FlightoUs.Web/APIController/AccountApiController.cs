using FlightoUs.Bll;
using FlightoUs.Model.Data;
using FlightoUs.Model.Enums;
using FlightoUs.Model.Services;
using FlightoUs.Web.Helpers;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace FlightoUs.Web.APIController
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountApiController : Controller
    {
        BllUser bllUser = new BllUser();
        ServiceResponse result = new ServiceResponse();


        [HttpPost]
        [Route("Login")]
        public async Task<ServiceResponse> Login([FromForm] LoginModel model)
        {
            string role = string.Empty; Int64 id = 0;
            try
            {
                User dbUser = bllUser.Login(model.UserName, model.Password);
                if (dbUser == null)
                {
                    result.IsSucceeded = false;
                    result.Message = "Invalid Login Information";
                    return result;
                }
                string message = "";
                id = dbUser.Id;

                if (dbUser.UserType == Convert.ToByte(UserRoleType.Admin)) { message = "/Admin/Dashboard"; role = "Admin"; }
                else if (dbUser.UserType == Convert.ToByte(UserRoleType.Manager)) { message = "/Manager/Dashboard"; role = "Manager"; }
                else if (dbUser.UserType == Convert.ToByte(UserRoleType.User)) { message = "/User/Dashboard"; role = "User"; }
                int user=Convert.ToInt32(User.Identity.Name);
                var claims = new List<Claim>
                    {
                        new Claim(ClaimTypes.GivenName, dbUser.FirstName),
                        new Claim(ClaimTypes.Name, id.ToString()),
                        new Claim(ClaimTypes.Role, role),
                    };
                int user1 = Convert.ToInt32(User.Identity.Name);

                ClaimsIdentity userIdentity = new ClaimsIdentity(claims, "login");

                ClaimsPrincipal principal = new ClaimsPrincipal(userIdentity);
                int user2 = Convert.ToInt32(User.Identity.Name);

                await HttpContext.SignInAsync(role, principal);
                int user3 = Convert.ToInt32(User.Identity.Name);

                result.Message = message;
                result.IsSucceeded = true;
            }
            catch (Exception ex)
            {
                //await LogHelper.LogError(ex, HttpContext, User);
                result.IsSucceeded = false;
                result.Message = ex.Message + "<br>" + ex.StackTrace;
            }

            return result;
        }

    }
}
