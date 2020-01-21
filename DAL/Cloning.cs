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
            target.GuestRequestKey = original.GuestRequestKey;
            target.PrivateName = original.PrivateName;
            target.FamilyName = original.FamilyName;
            target.MailAddress = original.MailAddress;
            target.Status = original.Status;
            target.RegistrationDate = original.RegistrationDate;
            target.EntryDate = original.EntryDate;
            target.EndDate = original.EndDate;
            target.Type = original.Type;
            target.Area = original.Area;
            target.Adults = original.Adults;
            target.Children = original.Children;
            target.Pool = original.Pool;
            target.Jacuzzi = original.Jacuzzi;
            target.Garden = original.Garden;
            target.ChildrensAttractions = original.ChildrensAttractions;
            target.GuestRequestKey = original.GuestRequestKey;
            target.Hikes = original.Hikes;
            target.AirConditioner = original.AirConditioner;
            target.NumOfBeds = original.NumOfBeds;
            target.NumOfRooms = original.NumOfRooms;
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
            target.OrderKey = original.OrderKey;
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


