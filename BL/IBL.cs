using System;
using System.Collections.Generic;
using System.Text;

namespace BL
{
    interface IBL
    {
        void NewGuestRequests(BE.GuestRequest TheGuestRequest);
        void UpdateGuestRequests(BE.GuestRequest TheGuestRequest);
        void AddNewHostingUnit(BE.HostingUnit TheHostingUnit);
        void DeleteHostingUnit(BE.HostingUnit TheHostingUnit);
        void UpdateHostingUnit(BE.HostingUnit TheHostingUnit);
        void NewOrder(BE.Order TheOrder);
        void UpdateDateOrder(BE.Order TheOrder);
        List<BE.HostingUnit> ListOfAllHostingUnits();
        List<BE.GuestRequest> ListOfAllGuestRequest();
        List<BE.Order> ListOfAllOrder();
        List<BE.BankBranch> ListOfAllBankBranch();



        List<BE.HostingUnit> ListOfHostingUnits();
        List<BE.GuestRequest> ListOfGuestRequest();
        List<BE.Order> ListOfOrder();
        List<BE.BankBranch> ListOfBankBranch();


    }
}
