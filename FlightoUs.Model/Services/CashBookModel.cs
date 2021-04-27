using FlightoUs.Model.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlightoUs.Model.Services
{
    public class CashBookModel:CashBook
    {
        public string PaymentModeStr { get; set; }
        public string ToBeUsedStr { get; set; }
    }
}
