using System;
using System.Collections.Generic;
using System.Text;
using BE;
using DAL;

namespace BL
{ 
    class BL_imp : IBL
    {
        public void AddNewHostingUnit(HostingUnit TheHostingUnit)
        {
            throw new NotImplementedException();
        }

        public void DeleteHostingUnit(HostingUnit TheHostingUnit)
        {
            throw new NotImplementedException();
        }

        public List<BankBranch> ListOfAllBankBranch()
        {
            throw new NotImplementedException();
        }

        public List<GuestRequest> ListOfAllGuestRequest()
        {
            throw new NotImplementedException();
        }

        public List<HostingUnit> ListOfAllHostingUnits()
        {
            return DAL.DAL.getListOfHostingUnits();
        }

        public List<Order> ListOfAllOrder()
        {
            throw new NotImplementedException();
        }

        public List<BankBranch> ListOfBankBranch()
        {
            throw new NotImplementedException();
        }

        public List<GuestRequest> ListOfGuestRequest()
        {
            throw new NotImplementedException();
        }

        public List<HostingUnit> ListOfHostingUnits()
        {
            throw new NotImplementedException();
        }

        public List<Order> ListOfOrder()
        {
            throw new NotImplementedException();
        }

        public void NewGuestRequests(GuestRequest TheGuestRequest)
        {
            throw new NotImplementedException();
        }

        public void NewOrder(Order TheOrder)
        {
            throw new NotImplementedException();
        }

        public void UpdateDateOrder(Order TheOrder)
        {
            throw new NotImplementedException();
        }

        public void UpdateGuestRequests(GuestRequest TheGuestRequest)
        {
            throw new NotImplementedException();
        }
         
        public void UpdateHostingUnit(HostingUnit TheHostingUnit)
        { 
            throw new NotImplementedException(); 
        }
        // לסיים את הפונקציה מיון לפי איזורים
        //public static List<BE.HostingUnit> ListOfHostingUntisInArea(string Area)
        //{
        //    var AraeGroups = from unit in ListOfAllHostingUnits
        //                     group unit by HostingUnit.getArea into g
        //                      orderby g.Key
        //                     select g;

        //    foreach (var nameGroup in AraeGroups)
        //    {
               
        //        foreach (var student in nameGroup)
        //        {
        //        }
        //}
    }

}
