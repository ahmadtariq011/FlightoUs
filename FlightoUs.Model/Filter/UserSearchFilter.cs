using LillyLifestyle.Models.Filters;
using System;
using System.Collections.Generic;
using System.Text;

namespace FlightoUs.Models.Filters
{
    public class UserSearchFilter : BaseFilter
    {
        public string Email { get; set; }
        public string UserName { get; set; }
    }
}
