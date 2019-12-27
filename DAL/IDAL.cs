using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace DAL
{
    interface Idal
    {
        void NewCustomerRequest(BE.GuestRequest TheGuestRequest);
        void UpdateCustomerRequest(BE.GuestRequest TheGuestRequest);
        void AddNewHostingUnit(BE.HostingUnit TheHostingUnit);
        void DeleteHostingUnit(BE.HostingUnit TheHostingUnit);
        void UpdateHostingUnit(BE.HostingUnit TheHostingUnit);
        void NewOrder(BE.Order TheOrder);
        void UpdateDateOrder(BE.Order TheOrder);
        List<BE.HostingUnit> ListOfAllHostingUnits();
        List<BE.GuestRequest> ListOfAllGuestRequest();
        List<BE.Order> ListOfAllOrder();
        List<BE.BankBranch> ListOfAllBankBranch();

       
    }
}


