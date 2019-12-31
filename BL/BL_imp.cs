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
       
    
        public List<BankBranch> getListOfBankBranch()
        {
            throw new NotImplementedException();
        }

        public List<GuestRequest> getListOfGuestRequest()
        {
            throw new NotImplementedException();
        }

        public List<HostingUnit> getListOfHostingUnits()
        {
            throw new NotImplementedException();
        }

        public List<Order> getListOfOrder()
        {
            throw new NotImplementedException();
        }

        public void AddNewHostingUnit(HostingUnit TheHostingUnit)
        {
            throw new NotImplementedException();
        }

        public void DeleteHostingUnit(HostingUnit TheHostingUnit)
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

        public bool CheakDateIfOk(DateTime StartDate, DateTime EndtDate) 
        {
            return (StartDate < EndtDate);
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


