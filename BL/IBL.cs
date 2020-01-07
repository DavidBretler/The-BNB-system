using System;
using System.Collections.Generic;
using System.Text;
using BE;

namespace BL
{
    public interface IBL
    {
        double updateStatusOfOrder(Order order, int newStatus);

        void DeleteHostingUnit(BE.HostingUnit TheHostingUnit);
        void DeleteGuestRequests(BE.GuestRequest TheGuestRequest);
        void DeleteOrder(BE.Order TheOrder);
        void DeleteHost(BE.Host TheHost);
        void NewGuestRequests(BE.GuestRequest TheGuestRequest);
        void UpdateGuestRequests(BE.GuestRequest TheGuestRequest);
        void AddNewHostingUnit(string HostingUnitName, int NumOfRooms,
           int NumOfBeds, Choice pool, Choice Jacuzzi, Area Area, Choice Garden,
           Choice AirConditioner, Choice ChildrensAttractions, ResortType Type, Choice Hikes, bool[][] Diary, int KeyOfHost)sortType Type, Choice Hikes, bool[][] Diary);
        void UpdateHostingUnit(BE.HostingUnit TheHostingUnit);
        void NewOrder(GuestRequest guestRequest, HostingUnit hostingUnit);
        void UpdateDateOrder(BE.Order TheOrder);
        List<BE.HostingUnit> getListOfHostingUnits();
        List<BE.GuestRequest> getListOfGuestRequest();
        List<BE.Order> getListOfOrder();
        List<BE.BankBranch> getListOfBankBranch();
        void sendEmail(Order currrentOrder);




    }
}
