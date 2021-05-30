using FlightoUs.Bll;
using FlightoUs.Bll.Helpers;
using FlightoUs.Model.Data;
using FlightoUs.Model.Enums;
using FlightoUs.Model.Services;
using FlightoUs.Models.Filters;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace FlightoUs.Web.APIController
{
    [Produces("application/json")]
    [Route("api/[controller]/[action]")]
    public class UserAPIController : Controller
    {

        private IWebHostEnvironment _environment;

        public UserAPIController(IWebHostEnvironment environment)
        {
            _environment = environment;
        }
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
                    if(bllUser.GetByUserName(user.UserName)!=null)
                    {
                        result.IsSucceeded = false;
                        result.Message = "UserName is already exists.";
                        return result;
                    }
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
                    dbUser.UserStatus = Convert.ToByte(UserStatus.Active);


                    int UserId = bllUser.Insert(dbUser);
                    result.IsSucceeded = true;
                    result.TotalCount = UserId;
                    result.Message = "User is Successfully Created";

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
                    result.Message = "User is Successfully Updated";
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
        public ServiceResponse ChangeStatus(UserModel user)
        {
            try
            {
                if (user.Id != 0)
                {
                    User dbUser = bllUser.GetByPK(user.Id);

                    UserStatus status = (UserStatus)Enum.Parse(typeof(UserStatus), user.UserStatusStr);
                    dbUser.UserStatus = Convert.ToInt32(status);

                    bllUser.ChangeUserStatus(dbUser);
                    result.IsSucceeded = true;
                    result.Message = "Status is updated to " + user.UserStatusStr;
                }
            }
            catch (Exception e)
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

        [HttpPost]
        public async Task<ActionResult> UploadPicAdmin(ICollection<IFormFile> files)
        {
            int CategoryId = Convert.ToInt32(Request.Form["hfProductId"]);
            User user=bllUser.GetByPK(CategoryId);
            int LoginUserid = Convert.ToInt32(Request.Form["hfLogId"]);
            User logUser = bllUser.GetByPK(LoginUserid);
            string typeofuser = EnumHelper.GetEnumByValue<UserRoleType>(logUser.UserType.ToString()).ToString();

            if (files.Count == 0)
            {
                //return Redirect("~/"+typeofuser+ "/AddEditUser/" + CategoryId + "/MissingFile/failure");
                return RedirectToAction("AddEditUser", typeofuser, new { id = CategoryId, Code = "MissingFile", Type = "failure" });
            }

            var file = files.FirstOrDefault();

            string fileExtentsion = System.IO.Path.GetExtension(file.FileName).ToLower();
            if (fileExtentsion != ".png" && fileExtentsion != ".jpg" && fileExtentsion != ".jpeg" && fileExtentsion != ".gif")
            {
                //return Redirect("~/"+typeofuser+"/AddEditUser/"+CategoryId +"/BadFileExtenstion/failure");
                return RedirectToAction("AddEditUser", typeofuser, new { id = CategoryId, Code= "BadFileExtenstion", Type= "failure" });
            }
            var uploads = Path.Combine(_environment.WebRootPath, "images/User/ProfileImage/" + CategoryId);

            if (!Directory.Exists(uploads))
            {
                Directory.CreateDirectory(uploads);
            }

            if (file.Length > 0)
            {
                using (var fileStream = new FileStream(Path.Combine(uploads, file.FileName), FileMode.Create))
                {
                    await file.CopyToAsync(fileStream);
                }
            }

            user.Picture = file.FileName;
            bllUser.Update(user);

            //return Redirect("~/"+typeofuser+"/AddEditUser/"+CategoryId+"/FileSuccess/success");
            return RedirectToAction("AddEditUser", typeofuser, new { id = CategoryId, Code = "FileSuccess", Type = "success" });

        }


        [HttpPost]
        public ServiceResponse GetUserImage(User filter)
        {
            try
            {
                User user = new User();
                user = bllUser.GetByPK(filter.Id);
                if (user == null)
                {
                    return result;
                }
                if (user.Picture != null)
                {
                    result.TotalCount = 1;
                }
                result.Message = user;
                result.IsSucceeded = true;
            }
            catch (Exception ex)
            {
                result.IsSucceeded = false;
                result.Message = ex.Message;
            }
            return result;
        }

        [HttpPost]
        public ServiceResponse DeletePicture(User model)
        {
            try
            {
                User UserImage = bllUser.GetByPK(model.Id);
                var directoryPath = Path.Combine(_environment.WebRootPath, "images/User/ProfileImage/" + UserImage.Id + "/" + UserImage.Picture);
                if (!bllUser.DeletePicture(model.Id))
                {
                    result.IsSucceeded = false;
                    result.Message = "Category Image is not found.";
                    return result;
                }

                System.IO.File.Delete(directoryPath);
                UserImage.Picture = null;
                bllUser.Update(UserImage);
                result.IsSucceeded = true;
                result.Message = "User Picture name "+UserImage.FirstName+" has been successfully deleted.";
            }
            catch (Exception ex)
            {
                result.IsSucceeded = false;
                result.Message = ex.Message;
            }
            return result;
        }
    }
}



/*
BllUser bllUser = new BllUser();
private ServiceResponse result = new ServiceResponse { IsSucceeded = true };

*/
