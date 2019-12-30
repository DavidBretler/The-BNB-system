using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace DAL
{
    interface Idal
    {
        void NewGuestRequests(BE.GuestRequest TheGuestRequest);
        void UpdateGuestRequests(BE.GuestRequest TheGuestRequest);
        void AddNewHostingUnit(BE.HostingUnit TheHostingUnit);
        void DeleteHostingUnit(BE.HostingUnit TheHostingUnit);//למה יש רק פונ מחיקה אחת ??
        void UpdateHostingUnit(BE.HostingUnit TheHostingUnit);
        void NewOrder(BE.Order TheOrder);
        void UpdateDateOrder(BE.Order TheOrder);
        List<BE.HostingUnit> ListOfHostingUnits();
        List<BE.GuestRequest> ListOfGuestRequest();
        List<BE.Order> ListOfOrder();
        List<BE.BankBranch> ListOfBankBranch();

      
    }
}

