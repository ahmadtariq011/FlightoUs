using System;
using System.Collections.Generic;
using System.Text;

namespace FlightoUs.Model.Enums
{
    public enum UserRoleType
    {
        Admin = 1,
        Manager=2,
        User = 3
    }

    public enum GenderType
    {
        Male=1,
        Female=2
    }
    public enum LeadType
    {
        Normal=1,
        priority = 2
    }
    public enum LeadStatus
    {
        Open=1,
        Close= 2,
        Success = 3
    }
    public enum TripType
    {
        OneWay=1,
        Return = 2
    }
    public enum LeadTypeDemand
    {
        Ticket=1,
        Hotel=2
    }
}
