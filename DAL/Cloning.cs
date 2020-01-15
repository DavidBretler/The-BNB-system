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
        public static BE.HostingUnit Clone(this BE.HostingUnit original)
        {
            BE.HostingUnit target = new BE.HostingUnit();
            target.Owner = original.Owner;
          target.Area = original.Area;
            target.HostingUnitName = original.HostingUnitName;
            target.HostingUnitKey = original.HostingUnitKey;
            target.NumOfRooms = original.NumOfRooms;
            target.NumOfBeds = original.NumOfBeds;
            target.pool = original.pool;
            target.Jacuzzi = original.Jacuzzi;
            target.Garden = original.Garden;
            target.AirConditioner = original.AirConditioner;
            target.ChildrensAttractions = original.ChildrensAttractions;
            target.Type = original.Type;
            target.Hikes = original.Hikes;
            DateTime time = DateTime.Today, time2 = DateTime.Today.AddMonths(11);
            while(time<time2)
            {
                target[time] = original[time];
                time=time.AddDays(1);
            }

            return target;
        }
        public static BE.Host Clone(this BE.Host original)
        {
            BE.Host target = new BE.Host();
            target.HostKey = original.HostKey;
                target.password = original.password;
                target.PrivateName = original.PrivateName;
                target.FamilyName = original.FamilyName;
                target.PhoneNumber = original.PhoneNumber;
                target.MailAddress = original.MailAddress;
                target.numberOfUints = original.numberOfUints;
            target.HostBankAccuont = new BankAccount();
            target.HostBankAccuont.BankName = original.HostBankAccuont.BankName;
            target.HostBankAccuont.BankAccountNumber = original.HostBankAccuont.BankAccountNumber;
            target.HostBankAccuont.BranchAddress = original.HostBankAccuont.BranchAddress;
            target.HostBankAccuont.BranchCity = original.HostBankAccuont.BranchCity;
            target.HostBankAccuont.BranchNumber = original.HostBankAccuont.BranchNumber;
           
            target.CollectionClearance = original.CollectionClearance;

            return target;
        }
        };
}


