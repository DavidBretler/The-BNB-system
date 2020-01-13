using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace DAL
{

    public interface  IDAL
    {
        GuestRequests FinedGuestRequestByKEY(int key);
        void DeleteHostingUnit(int hostUnitKey);
        void DeleteGuestRequests(BE.GuestRequest TheGuestRequest);
        void Deleteorder(BE.Order TheOrder);
        void DeleteHost(BE.Host TheHost);
        void NewGuestRequests(BE.GuestRequest TheGuestRequest);
        void UpdateGuestRequests(BE.GuestRequest TheGuestRequest);
        void AddNewHostingUnit(BE.HostingUnit TheHostingUnit);
         void UpdateHostingUnit(BE.HostingUnit TheHostingUnit);
        void NewOrder(BE.Order TheOrder);

        void UpdateDateOrder(BE.Order TheOrder);
        List<BE.HostingUnit> getListOfHostingUnits();
        List<BE.GuestRequest> getListOfGuestRequest();
        List<BE.Order> getListOfOrder();
        List<BE.BankBranch> getListOfBankBranch();

        List<BE.Host> getListOfHost();


    }
}

