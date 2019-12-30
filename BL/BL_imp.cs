using System;
using System.Collections.Generic;
using System.Text;
using BE;
using DAL;
using System.Linq;


namespace BL
{
    class BL_imp : IBL
    {
        IDAL dal = FactoryDal.GetDal();
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
            return dal.ListOfHostingUnits();
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
            dal.ListOfHostingUnits();

            throw new NotImplementedException();
        }

       public IEnumerable<IGrouping<Area, HostingUnit>> ListOfHostingUntisInArea()
        {
            List<BE.HostingUnit> hostingUnits = dal.ListOfHostingUnits();
            var AraeGroups = from unit in hostingUnits
                             orderby unit.Area
                             group unit by unit.Area into groupArea
                             select groupArea;
            return AraeGroups;

        }


        //    public IEnumerable<BE.HostingUnit> ListOfHostingUntisInArea(string Area)
        //{

        //    var AraeGroups = from unit in dal.ListOfHostingUnits()
        //                     group unit by unit.getArea into groupArea

        //                     select new { g = groupArea };
        //    List<BE.HostingUnit> arr = new List<HostingUnit>();

        //    foreach (var unit in AraeGroups)
        //    {

        //        foreach (var unitkey in unit.key)
        //        {
        //            arr.Add(unitkey);
        //        }
        //    }
        //    return arr;
        //}
    }
}


