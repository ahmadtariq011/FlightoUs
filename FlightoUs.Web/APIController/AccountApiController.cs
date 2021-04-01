using FlightoUs.Bll;
using FlightoUs.Model.Data;
using FlightoUs.Model.Enums;
using FlightoUs.Model.Services;
using FlightoUs.Web.Helpers;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
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
        [Route("AdminLogin")]
        public async Task<ServiceResponse> AdminLogin([FromForm] LoginModel model)
        {
            try
            {
                User dbUser = bllUser.AdminLogin(model.UserName, model.Password);
                if (dbUser == null)
                {
                    result.IsSucceeded = false;
                    result.Message = "Invalid Login Information";
                    return result;
                }

                result.Message = "/Home/Dashboard";

                var claims = new List<Claim>
                    {
                        new Claim(ClaimTypes.GivenName, dbUser.FirstName),
                        new Claim(ClaimTypes.Name, dbUser.Id.ToString()),
                        new Claim(ClaimTypes.Role, UserRoleType.User.ToString()),
                    };

                ClaimsIdentity userIdentity = new ClaimsIdentity(claims, "login");
                ClaimsPrincipal principal = new ClaimsPrincipal(userIdentity);

                await HttpContext.SignInAsync("AdminAuth", principal);
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
