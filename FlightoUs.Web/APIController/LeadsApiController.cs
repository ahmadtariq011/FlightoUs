using FlightoUs.Bll;
using FlightoUs.Model.Data;
using FlightoUs.Model.Enums;
using FlightoUs.Model.Filter;
using FlightoUs.Model.Services;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using System.Security.Claims;
using Microsoft.AspNetCore.Hosting;
using FlightoUs.Bll.Helpers;

namespace FlightoUs.Web.APIController
{
    [Produces("application/json")]
    [Route("api/[controller]/[action]")]
    public class LeadsApiController : Controller
    {
        BllLead bllLead = new BllLead();
        BllUser bllUser = new BllUser();
        BllAirportCodes bllAirportCodes = new BllAirportCodes();
        ServiceResponse result = new ServiceResponse();
        [HttpPost]
        public ServiceResponse GetLeadsWithCount(LeadSearchFilter filter)
        {
            try
            {
                result.Message = bllLead.Search(filter);
                result.IsSucceeded = true;
                result.TotalCount = bllLead.GetSearchCount(filter);
            }
            catch (Exception ex)
            {
                result.IsSucceeded = false;
                result.Message = ex.Message + "<br>" +ex.StackTrace;
            }
            return result;

        }


        [HttpPost]
        public ServiceResponse GetLeads(LeadSearchFilter filter)
        {
            try
            {
                result.Message = bllLead.Search(filter);
            }
            catch (Exception ex)
            {
                result.IsSucceeded = false;
                result.Message = ex.Message + "<br>" + ex.StackTrace;
            }
            return result;
        }
        [HttpPost]
        public ServiceResponse SaveFreeText(LeadModel lead)
        {
            try
            {
                Lead dbLead = bllLead.GetByPK(lead.Id);
                dbLead.FreeText = lead.FreeText;
                bllLead.AddFreetext(dbLead);
                result.IsSucceeded = true;
                result.Message = "Free text is Added Successfully";
            }
            catch (Exception ex)
            {
                result.IsSucceeded = false;
                result.Message = ex.Message + "<br>" + ex.StackTrace;
            }
            return result;
        }
        [HttpPost]
        public ServiceResponse SaveLeads(LeadModel lead)
        {
            try
            {
                User user = bllUser.GetByPK(lead.Userlog);
                if (user.UserType == 1)
                {
                    result.Message = "/Admin/LeadsIndex";
                }
                else if (user.UserType == 2)
                {
                    result.Message = "/Manager/LeadsIndex";
                }
                else
                {
                    result.Message = "/User/LeadsIndex";
                }
                var FromCode=bllAirportCodes.GetByPK(lead.FromCode);
                var ToCode = bllAirportCodes.GetByPK(lead.ToCode);
                if (lead.Id == 0)
                {
                
                    Lead dbLead = new Lead();
                    dbLead.FirstName = lead.FirstName;
                    dbLead.UserName = lead.UserName;
                    dbLead.Email = lead.Email;
                    dbLead.Address = lead.Address;
                    dbLead.DepartureDate = lead.DepartureDate;
                    dbLead.Telephone = lead.Telephone;
                    dbLead.LeadTitle = "From " + FromCode.IATA + " To " + ToCode.IATA;
                    dbLead.CreatedDate = DateTime.Now;
                    dbLead.AssignDate = DateTime.Now;
                    dbLead.CreatedBy = lead.CreatedBy;
                    dbLead.Careof = lead.Careof;
                    dbLead.AssignToUser = lead.AssignToUser;
                    dbLead.ContactCustomer = lead.ContactCustomer;
                    dbLead.SecondaryPhoneNumber = lead.SecondaryPhoneNumber;
                    dbLead.FromCode = lead.FromCode;
                    dbLead.ToCode = lead.ToCode;

                    ClassOfTravel classt = (ClassOfTravel)Enum.Parse(typeof(ClassOfTravel), lead.ClassOfTravelName);
                    TripType triptype = (TripType)Enum.Parse(typeof(TripType), lead.TripTypeName);
                    CustomerType customer = (CustomerType)Enum.Parse(typeof(CustomerType), lead.CustomeTypeName);

                    LeadType type = (LeadType)Enum.Parse(typeof(LeadType), lead.LeadTypeName);
                    LeadStatus status = (LeadStatus)Enum.Parse(typeof(LeadStatus), lead.LeadStatusName);
                    Leadgender Gender = (Leadgender)Enum.Parse(typeof(Leadgender), lead.LeadGenderName);

                    dbLead.ClassOfTravel = Convert.ToInt32(classt);
                    dbLead.TripTyepLead = Convert.ToInt32(triptype);
                    dbLead.CustomerType = Convert.ToInt32(customer);
                    dbLead.LeadType = Convert.ToInt32(type);
                    dbLead.LeadStatus = Convert.ToInt32(status);
                    dbLead.LeadGender = Convert.ToInt32(Gender);

                    int LeadId = bllLead.Insert(dbLead);
                    result.IsSucceeded = true;
                    result.TotalCount = LeadId;
                }
                else
                {
                    Lead dbLead = bllLead.GetByPK(lead.Id);

                    if(dbLead.AssignToUser!=lead.AssignToUser)
                    {
                        dbLead.Careof = lead.AssignToUser;
                        //dbLead.AssignToUser = lead.AssignToUser; 
                        //dbLead.AssignDate = DateTime.Now;
                    }
                    dbLead.ContactCustomer = lead.ContactCustomer;
                    dbLead.FirstName = lead.FirstName;
                    dbLead.LastName = lead.LastName;
                    dbLead.LeadTitle = "From " + FromCode.IATA + " To " + ToCode.IATA;
                    dbLead.Email = lead.Email;
                    dbLead.Address = lead.Address;
                    dbLead.DepartureDate = lead.DepartureDate;
                    dbLead.Telephone = lead.Telephone;
                    dbLead.SecondaryPhoneNumber = lead.SecondaryPhoneNumber;
                    dbLead.FromCode = lead.FromCode;
                    dbLead.ToCode = lead.ToCode;

                    ClassOfTravel classt = (ClassOfTravel)Enum.Parse(typeof(ClassOfTravel), lead.ClassOfTravelName);
                    TripType triptype = (TripType)Enum.Parse(typeof(TripType), lead.TripTypeName);
                    CustomerType customer = (CustomerType)Enum.Parse(typeof(CustomerType), lead.CustomeTypeName);

                    LeadType type = (LeadType)Enum.Parse(typeof(LeadType), lead.LeadTypeName);
                    LeadStatus status = (LeadStatus)Enum.Parse(typeof(LeadStatus), lead.LeadStatusName);
                    Leadgender Gender = (Leadgender)Enum.Parse(typeof(Leadgender), lead.LeadGenderName);


                    dbLead.ClassOfTravel = Convert.ToInt32(classt);
                    dbLead.TripTyepLead = Convert.ToInt32(triptype);
                    dbLead.CustomerType = Convert.ToInt32(customer);
                    dbLead.LeadType = Convert.ToInt32(type);
                    dbLead.LeadStatus = Convert.ToInt32(status);
                    dbLead.LeadGender = Convert.ToInt32(Gender);

                    bllLead.Update(dbLead);
                    result.IsSucceeded = true;
                   
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
        public ServiceResponse DeleteLeads(int Id)
        {
            try
            {

                bllLead.DeleteLeads(Id);
                result.IsSucceeded = true;
                result.Message = "User Deleted Successfully";
            }

            catch (Exception e)
            {
                result.IsSucceeded = false;
                result.Message = e.Message + " </br> " + e.StackTrace;
            }
            return result;
        }

        [HttpPost]
        public ServiceResponse GetAllLeads()
        {
            try
            {
                result.Message = bllLead.GetAllLeads();
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
                result.Message = bllLead.GetByEmailLeads(email);
            }
            catch (Exception e)
            {
                result.IsSucceeded = false;
                result.Message = e.Message + "<br>" + e.StackTrace;
            }
            return result;
        }

        [HttpPost]

        public ServiceResponse ChangeStatus(LeadModel lead)
        {
            try
            {
                if(lead.Id!=0)
                {
                    Lead dbLead = bllLead.GetByPK(lead.Id);

                    LeadStatus status = (LeadStatus)Enum.Parse(typeof(LeadStatus), lead.LeadStatusName);
                    dbLead.LeadStatus = Convert.ToInt32(status);

                    bllLead.ChangeStatus(dbLead);
                    result.IsSucceeded = true;
                    result.Message = "Status is updated to " + lead.LeadStatusName;
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
        public ServiceResponse GEtByphoneN0(LeadModel lead)
        {
            var leadphone = bllLead.GetByPhoneNoLeads(lead.Telephone);
            if (leadphone != null)
            {
                var Userlogin = bllUser.GetByPK(lead.Userlog);
                var userloginType = Userlogin.UserType;
                string LeadGenderType = EnumHelper.GetEnumByValue<UserRoleType>(userloginType.ToString()).ToString();
                result.Message = "/"+LeadGenderType+"/AddEditLead/"+leadphone.Id;
                result.IsSucceeded = true ;


            }
            else
            {
                result.IsSucceeded = false;
            }
            return result;
        }


    }
}
