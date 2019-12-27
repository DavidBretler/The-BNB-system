using System;
using System.Collections.Generic;
using System.Text;
using BE;
using DS;


namespace DAL 
{
  public class Dal_imp : IDAL
    {       
        //public int checkIfExist<T>(List<T> list,T parm)
        //{
        //    for (int i = 0; i < list.Count; i++)
        //        if (list[i].GetType().GetProperty() == parm.GetType().GetProperty)
        //        return i;

        //        return -1;
        //}
        public T GetMax<T>(T lhs, T rhs)
        {
            return Comparer<T>.Default.Compare(lhs, rhs) > 0 ? lhs : rhs;
        }

        public void AddNewHostingUnit(HostingUnit TheHostingUnit)
        {
            List<HostingUnit> L = DS.DataSource.ListHostingUnits;
            for (int i = 0; i < L.Count; i++)
                if (L[i].getHostingUnitKey() == TheHostingUnit.getHostingUnitKey())
                {
                    Console.WriteLine("the HostingUnitKey is alredy exist");
                    return; 
                }
                    DS.DataSource.ListHostingUnits.Add(TheHostingUnit);
        }

        public void DeleteHostingUnit(HostingUnit TheHostingUnit)
        {
            List<HostingUnit> L = DS.DataSource.ListHostingUnits;
            for (int i = 0; i < L.Count; i++)
            {
                if (L[i].getHostingUnitKey()== TheHostingUnit.getHostingUnitKey())
                    L.Remove(L[i]); //need to check if work good
            }
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
            throw new NotImplementedException();
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
        /// <summary>
        /// 
        /// </summary>
        /// <param name="TheGuestRequest"></param>
        public  void NewGuestRequests(GuestRequest TheGuestRequest)
        {
            DS.DataSource.ListGuestRequests.Add(TheGuestRequest);
        }
    
         public void NewOrder(BE.Order TheOrder)
         {
            DS.DataSource.ListOrders.Add(TheOrder);
         }

        public void UpdateGuestRequests(GuestRequest TheGuestRequest)
        {
            List<GuestRequest> L = DS.DataSource.ListGuestRequests;
            for (int i = 0; i < L.Count; i++)
            {
                if (L[i].getGuestRequestKey() == TheGuestRequest.getGuestRequestKey())
                    L[i] = TheGuestRequest; //need to check if work good
            }
        }

        public void UpdateDateOrder(Order TheOrder)
        {
            List<Order> L = DS.DataSource.ListOrders;
            for (int i = 0; i < L.Count; i++)
            {
                if (L[i].getOrderKey() == TheOrder.getOrderKey())
                    L[i] = TheOrder; //need to check if work good
            }
        }

        public void UpdateHostingUnit(HostingUnit TheHostingUnit)
        {
            List<HostingUnit> L = DS.DataSource.ListHostingUnits;
            for (int i = 0; i < L.Count; i++)
            {
                if (L[i].getHostingUnitKey() == TheHostingUnit.getHostingUnitKey())
                    L[i]= TheHostingUnit; //need to check if work good
            }
        }
    }

}
