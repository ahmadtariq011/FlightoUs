using FlightoUs.Bll;
using FlightoUs.Model.Data;
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
    public class RemarksApiController : Controller
    {

        BllRemarks bllRemarks = new BllRemarks();

        ServiceResponse result = new ServiceResponse();
        [HttpPost]
        public ServiceResponse SaveRemarks(Remarks remarks)
        {
            try
            {
                if (remarks.Id == 0)
                {
                    Remarks dbRemarks = new Remarks();
                    dbRemarks.Details = remarks.Details;
                    dbRemarks.CreatedDate = DateTime.Now;


                    int RemarkId = bllRemarks.Insert(dbRemarks);
                    result.IsSucceeded = true;
                    result.TotalCount = RemarkId;
                    result.Message = "Remark is Created Successfully";
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
        public ServiceResponse DeleteRemarks(int Id)
        {
            try
            {

                bllRemarks.Delete(Id);
                result.IsSucceeded = true;
                result.Message = "Remark Deleted Successfully";
            }

            catch (Exception e)
            {
                result.IsSucceeded = false;
                result.Message = e.Message + " </br> " + e.StackTrace;
            }
            return result;
        }

        [HttpPost]
        public ServiceResponse GetAllRemarks()
        {
            try
            {
                result.Message = bllRemarks.GetAllRemarks();
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
