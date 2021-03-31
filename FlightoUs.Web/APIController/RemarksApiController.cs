using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FlightoUs.Web.APIController
{
    public class RemarksApiController : Controller
    {
        
        public IActionResult Index()
        {
            return View();
        }
    }
}
