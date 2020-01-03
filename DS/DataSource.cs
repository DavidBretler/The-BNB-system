using BE;
using System;
using System.Collections.Generic;
using System.Text;

namespace DS
{
    public class DataSource
    {
        public static List<BE.GuestRequest> ListGuestRequests = new List<BE.GuestRequest>
        {
                new BE.GuestRequest()
                {
                   GuestRequestKey= BE.Configuration.getNewHostingUnitKey(),
                    PrivateName = "david",
                    FamilyName = "bornstain",
                    MailAddress = "aaa@aaa.com",
                    Status = 0,
                    RegistrationDate = new DateTime(2019, 01, 01),
                    EntryDate = new DateTime(2019, 01, 01),
                    ReleaseDate = new DateTime(2019, 01, 03),
                    Type = 0,
                    Area = 0,
                    Adults = 10,
                    Pool = 0,
                    Jacuzzi = 0,
                    Garden = 0,
                    ChildrensAttractions = 0,
                    Hikes =0,
                    AirConditioner=0,
                    NumOfBeds=0,
                },
            new BE.GuestRequest()
            {
                 GuestRequestKey= BE.Configuration.getNewHostingUnitKey(),
            PrivateName = "dov",
                    FamilyName = "aquamen",
                    MailAddress = "bbb@aaa.com",
                    Status = 0,
                    RegistrationDate = new DateTime(2019, 01, 02),
                    EntryDate = new DateTime(2019, 01, 02),
                    ReleaseDate = new DateTime(2019, 01, 03),
                    Type = 0,
                    Area = 0,
                    Adults = 10,
                    Pool = 0,
                    Jacuzzi = 0,
                    Garden = 0,
                    ChildrensAttractions = 0,
                    Hikes =0,
                    AirConditioner=0,
                    NumOfBeds=0,
                 }
        };
        public static List<BE.HostingUnit> ListHostingUnits = new List<BE.HostingUnit>
        {
            new BE.HostingUnit()
            {
                 HostingUnitKey=4,     
                // Owner="doby",
                  HostingUnitName="the rock",
                 NumOfRooms=5,
                 NumOfBeds=8,
                 pool=0,
                 Jacuzzi=0,
                 Area=0,
                 Garden=0,
                 AirConditioner=0,
                 ChildrensAttractions=0,
                 Type=0,
                 Hikes=0,
            },
            new BE.HostingUnit()
            {
                HostingUnitKey=4,     
                // Owner="doby",
                  HostingUnitName="the rock",
                 NumOfRooms=5,
                 NumOfBeds=8,
                 pool=0,
                 Jacuzzi=0,
                 Area=0,
                 Garden=0,
                 AirConditioner=0,
                 ChildrensAttractions=0,
                 Type=0,
                 Hikes=0,
            }

        };

        public static List<BE.Host> ListHosts = new List<BE.Host>
        {
            new BE.Host()
            {
             HostKey=BE.Configuration.getNewHostKey() ,
             PrivateName="dfg",
             FamilyName="dfggg",
             PhoneNumber="05225461",
             MailAddress="asd@aaa.com",
             numberOfUints =5,
            // HostBankAccuont =ListBankBranches[0],
             CollectionClearance=true, //permision to debit from bank
            },
     new BE.Host()
            {
             HostKey=BE.Configuration.getNewHostKey() ,
             PrivateName="aba",
             FamilyName="sba",
             PhoneNumber="0527893446",
             MailAddress="atyl@aaa.com",
             numberOfUints =6,
          //   HostBankAccuont =ListBankBranches[0],
             CollectionClearance=false, //permision to debit from bank
            },
        };
        public static List<BE.BankBranch> ListBankBranches = new List<BE.BankBranch>();

        public static List<BE.Order> ListOrders = new List<BE.Order>
        {

            new BE.Order()
            {
             HostingUnitKey=BE.Configuration.getNewOrderKey(),
             GuestRequestKey=BE.Configuration.getNewGuestRequestKey(),
            OrderKey=BE.Configuration.getNewOrderKey() ,
            Status=0 ,  
           CreateDate=new DateTime(11,1,2010) ,   
           OrderDate=new DateTime(11,6,2010),
            },
           new BE.Order()
            {
             HostingUnitKey=BE.Configuration.getNewOrderKey(),
             GuestRequestKey=BE.Configuration.getNewGuestRequestKey(),
            OrderKey=BE.Configuration.getNewOrderKey() ,
            Status=0 ,
           CreateDate=new DateTime(15,1,2010) ,
           OrderDate=new DateTime(20,6,2010),
            }

        };
        
        }
   
}
