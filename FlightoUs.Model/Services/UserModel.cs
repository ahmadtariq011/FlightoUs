using FlightoUs.Model.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlightoUs.Model.Services
{
    public class UserModel:User
    {
        public string UserTypeName { get; set; }
        public string GenderTypename { get; set; }
    }
}
