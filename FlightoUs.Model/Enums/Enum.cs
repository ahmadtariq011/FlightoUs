using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace FlightoUs.Model.Enums
{
    public enum UserRoleType
    {
        Admin = 1,
        Manager=2,
        User = 3
    }
    public enum FormOfPayment
    {
        Cash=1,
        Cheque=2
    }
    public enum Leadgender
    {
        Mr=1,
        Mrs=2,
        Miss=3
    }
    public enum CustomerType
    {
        New=1,
        Old=2
    }public enum ClassOfTravel
    {
        Economy=1,
        Bussiness=2
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
        Hotel=2,
        Visa=3,
        Umrah=4
    }

    public enum ReciptStatus
    {
        Pending=1,
        Approved=2,
        Rejected=3
    }
    public enum SalePostType
    {
        Ticket = 1,
        Hotel = 2,
        Other=3,
        Umrah = 4,
        Visa = 5
    }
    public enum PaymentMode
    {
        Cheque=1,
        Cash=2,
        Debut=3,
        Credit=4,
        Online=5,
        JazzCash=6,
        EasyPaisa=7
    }
    public enum ClientType
    {
        Adult=1,
        Children=2,
        Infant=3
    }
    public enum HotelCategory
    {
        //[Display(Name = "1 Star")]
        OneStar = 1,
        //[Display(Name = "2 Star")]
        TwoStar = 2,
        //[Display(Name = "3 Star")]
        ThreeStar = 3,
        //[Display(Name = "4 Star")]
        FourStar = 4,
        //[Display(Name = "5 Star")]
        FiveStar = 5,
        Appartment=6
    }
    public enum UserStatus
    {
        Active=1,
        Block=2
    }
    public enum RefundType
    {
        Partial=1,
        //[Display(Name = "Full Refund")]
        FullRefund =2
    }
    public enum RefundStatus
    {
        Pending = 1,
        Approved = 2,
        InProcess=3
    }
}
