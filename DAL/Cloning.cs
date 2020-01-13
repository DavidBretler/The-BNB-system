using System;
using System.Collections.Generic;
using System.Text;
using BE;
namespace DAL
{
    public static class Cloning
    {
        public static BE.BankAccount Clone(this BE.BankAccount original)
        {
            BE.BankAccount target = new BankAccount();


            target.BankName = original.BankName;
            target.BranchNumber = original.BranchNumber;
            target.BranchAddress = original.BranchAddress;
            target.BranchCity = original.BranchCity;
            target.BankAccountNumber = original.BankAccountNumber;
            return target;

        }
        public static BE.GuestRequest Clone(this BE.GuestRequest original)
        {
            BE.GuestRequest target = new BE.GuestRequest();
            original.PrivateName = target.PrivateName;
            original.FamilyName = target.FamilyName;
            original.MailAddress = target.MailAddress;
            original.Status = target.Status;
            original.RegistrationDate = target.RegistrationDate;
            original.EntryDate = target.EndDate;
            original.EndDate = target.EndDate;
            original.Type = target.Type;
            original.Area = target.Area;
            original.Adults = target.Adults;
            original.Children = target.Children;
            original.Pool = target.Pool;
            original.Jacuzzi = target.Jacuzzi;
            original.Garden = target.Garden;
            original.ChildrensAttractions = target.ChildrensAttractions;
            original.GuestRequestKey = target.GuestRequestKey;
            original.Hikes = target.Hikes;
            original.AirConditioner = target.AirConditioner;
            return target;
        }
        public static BE.Order Clone(this BE.Order original)
        {
            BE.Order target = new BE.Order();
                target.CreateDate = original.CreateDate;
            target.HostingUnitKey = original.HostingUnitKey;
            target.GuestRequestKey = original.GuestRequestKey;
            target.Status = original.Status;
            target.contactCustumerDate = original.contactCustumerDate;

            return target;
      
    }
        //public static BE.HostingUnit Clone(this BE.HostingUnit original)
        //{
        //    BE.HostingUnit target = new BE.HostingUnit(); original.Owner original.Area, original.HostingUnitName, original.Hostingunitkey);
        //    target.Diary = original.Diary;

        //    return target;
        //}
    };
}


