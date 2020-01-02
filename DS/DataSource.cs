using BE;
using System;
using System.Collections.Generic;
using System.Text;

namespace DS
{
    public   class DataSource
    {
        public static List<BE.GuestRequest> ListGuestRequests = new List<BE.GuestRequest>
        {
                new BE.GuestRequest()
                {

                    setPrivateName = "ely",
                    FamilyName = "klein",
                    MailAddress = "aaa@aaa.com",
                    Status = 0,
                    RegistrationDate = new DateTime(2019, 01, 01),
                    EntryDate = new DateTime(2019, 01, 01),
                    ReleaseDate = new DateTime(2019, 01, 03),
                    Type = BE.Type.Hotel,
                    Area = BE.Area.Center,
                    SubArea = BE.SubArea.רחובות,
                    Adults = 10,
                    children = 100,
                    Pool = BE.StatusPool.מעוניין,
                    Jacuzzi = BE.StatusJacuzzi.אפשרי,
                    Garden = BE.StatusGarden.אפשרי,
                    ChildrensAttractions = BE.StatusChildrensAttractions.מעוניין
                },
           };
        public static List<BE.HostingUnit> ListHostingUnits = new List<BE.HostingUnit>();

        public static List<BE.Host> ListHosts = new List<BE.Host>();

        public static List<BE.BankBranch> ListBankBranches = new List<BE.BankBranch>();

        public static List<BE.Order> ListOrders = new List<BE.Order>();
       
    }
    

}
