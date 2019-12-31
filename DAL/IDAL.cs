using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace DAL
{

    public interface  IDAL
    {    

        void NewGuestRequests(BE.GuestRequest TheGuestRequest);
        void UpdateGuestRequests(BE.GuestRequest TheGuestRequest);
        void AddNewHostingUnit(BE.HostingUnit TheHostingUnit);
        void DeleteHostingUnit(BE.HostingUnit TheHostingUnit);
        void UpdateHostingUnit();
        void NewOrder(BE.Order TheOrder);

        void UpdateDateOrder(BE.Order TheOrder);
        List<BE.HostingUnit> getListOfHostingUnits();
        List<BE.GuestRequest> getListOfGuestRequest();
        List<BE.Order> getListOfOrder();
        List<BE.BankBranch> getListOfBankBranch();

     
    }
}

