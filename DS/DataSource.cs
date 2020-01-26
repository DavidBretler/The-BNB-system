using BE;
using System;
using System.Collections.Generic;
using System.Text; 

namespace DS
{
    public class DataSource

    {

        public static List<BE.Host> ListHosts = new List<BE.Host>
        {
            new BE.Host()
            {
             HostKey=BE.Configuration.getNewHostKey() ,
             PrivateName="dfg",
             FamilyName="dfggg",
             PhoneNumber="05225461",
             MailAddress="ddkill8@gmail.com",
             numberOfUints =5,
             HostBankAccuont= new BankAccount(),

        CollectionClearance=true, //permision to debit from bank
            },
     new BE.Host()
            {
             HostKey=BE.Configuration.getNewHostKey() ,
             PrivateName="aba",
             FamilyName="sba",
             PhoneNumber="0527893446",
             MailAddress="ddkill8@gmail.com",
             numberOfUints =6,
             HostBankAccuont= new BankAccount(),
             CollectionClearance=true, //permision to debit from bank
            },
        };
        public static List<BE.GuestRequest> ListGuestRequests = new List<BE.GuestRequest>
        {
                new BE.GuestRequest()
                {
                   GuestRequestKey= BE.Configuration.getNewGuestRequestKey(),
                    PrivateName = "david",
                    FamilyName = "bornstain",
                    MailAddress ="dovb15@walla.com",
                    Status = 0,
                    RegistrationDate = new DateTime(2020, 01, 01),
                    EntryDate = new DateTime(2020, 01, 01),
                    EndDate = new DateTime(2020, 01, 03),
                    Type = 0,
                    Area = (Area)2,
                    Adults = 10,
                    Pool = (Choice)1,
                    Jacuzzi = (Choice)1,
                    Garden = (Choice)1,
                    ChildrensAttractions = (Choice)1,
                    Hikes =(Choice)1,
                    AirConditioner=(Choice)1,
                    NumOfBeds=2,
                },
            new BE.GuestRequest()
            {
                 GuestRequestKey= BE.Configuration.getNewGuestRequestKey(),
            PrivateName = "dov",
                    FamilyName = "aquamen",
                    MailAddress = "ddkill8@gmail.com",
                    Status = 0,
                    RegistrationDate = new DateTime(2020, 01, 02),
                    EntryDate = new DateTime(2020, 01, 02),
                    EndDate = new DateTime(2020, 01, 03),
                    Type = 0,
                    Area = 0,
                    Adults = 10,
                    Pool = 0,
                    Jacuzzi = 0,
                    Garden = 0,
                    ChildrensAttractions = 0,
                    Hikes =0,
                    AirConditioner=0,
                    NumOfBeds=3,
                 }
        };
        public static List<BE.HostingUnit> ListHostingUnits = new List<BE.HostingUnit>
        {
            new BE.HostingUnit()
            {
                 HostingUnitKey=Configuration.getNewHostingUnitKey(),     
                 Owner=ListHosts[0],
                  HostingUnitName="the rock",
                 NumOfRooms=5,
                 NumOfBeds=8,
                 pool=0,
                 Jacuzzi=0,
                 Area=(Area)0,
                 Garden=0,
                 AirConditioner=0,
                 ChildrensAttractions=0,
                 Type=0,
                 Hikes=0,
            },
            new BE.HostingUnit()
            {
                HostingUnitKey=Configuration.getNewHostingUnitKey(),     
                 Owner=ListHosts[0],
                  HostingUnitName="dov's houes",
                 NumOfRooms=12,
                 NumOfBeds=2,
                 pool=0,
                 Jacuzzi=0,
                 Area=(Area)1,
                 Garden=0,
                 AirConditioner=0,
                 ChildrensAttractions=0,
                 Type=0,
                 Hikes=0,
            }

        };

        
        public static List<BE.BankBranch> ListBankBranches = new List<BE.BankBranch>();

        public static List<Order> ListOrders = new List<BE.Order>
        {

            new BE.Order()
            {
             HostingUnitKey=1,           
             GuestRequestKey=1,
            OrderKey=BE.Configuration.getNewOrderKey() ,
            Status=0 ,  
           CreateDate=new DateTime(2020,1,10) ,
           contactCustumerDate=new DateTime(2020,6,10),

            },
           new BE.Order()
            {
             HostingUnitKey=2,
             GuestRequestKey=2,
            OrderKey=BE.Configuration.getNewOrderKey() ,
            Status=0 ,
           CreateDate= DateTime.Today ,
           contactCustumerDate=new DateTime(2020,6,16),
            }

        };
        
    }
    
}
