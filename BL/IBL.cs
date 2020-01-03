using System;
using System.Collections.Generic;
using System.Text;
using BE;

namespace BL
{
    interface IBL
    {
        void NewGuestRequests(BE.GuestRequest TheGuestRequest);
        void UpdateGuestRequests(BE.GuestRequest TheGuestRequest);
        void AddNewHostingUnit(string HostingUnitName, int NumOfRooms,
           int NumOfBeds, Choice pool, Choice Jacuzzi, Area Area, Choice Garden,
           Choice AirConditioner, Choice ChildrensAttractions, ResortType Type, Choice Hikes, bool[][] Diary, int KeyOfHost)sortType Type, Choice Hikes, bool[][] Diary);
        void DeleteHostingUnit(BE.HostingUnit TheHostingUnit);
        void DeleteGuestRequests(BE.GuestRequest TheGuestRequest);
        void Deleteorder(BE.Order TheOrder);
        void DeletHost(BE.Host TheHost);
        void UpdateHostingUnit(BE.HostingUnit TheHostingUnit);
        void NewOrder(BE.Order TheOrder);
        void UpdateDateOrder(BE.Order TheOrder);
        List<BE.HostingUnit> getListOfHostingUnits();
        List<BE.GuestRequest> getListOfGuestRequest();
        List<BE.Order> getListOfOrder();
        List<BE.BankBranch> getListOfBankBranch();
         void sendEmail(Order currrentOrder);


      
    }
}
