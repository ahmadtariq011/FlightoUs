﻿using System;
using System.Collections.Generic;
using System.Text;

namespace LillyLifestyle.Models.Services
{
    public class ServiceResponse
    {
        public Boolean IsSucceeded { get; set; }
        public object Message { get; set; }
        public Int64 TotalCount { get; set; }

        public ServiceResponse()
        {
            IsSucceeded = true;
        }
    }
}
