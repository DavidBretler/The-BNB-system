using System;
using System.Collections.Generic;
using System.Text;
using BE;
using DS;
using System.Linq;


namespace DAL
{
   public  class DAL : IDAL
    {
        //public int checkIfExist<T>(List<T> list,T parm)
        //{
        //    for (int i = 0; i < list.Count; i++)
        //        if (list[i].GetType().GetProperty() == parm.GetType().GetProperty)
        //        return i;

        //        return -1;
        //}

        private DAL() { }
    /// <summary>
    /// make sure that we will craete only one object from this class
    /// </summary>
       protected static DAL newDAL = null;
    public static DAL GetDAL()
        {
            if (newDAL == null)
                newDAL = new DAL();
            return newDAL;
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
            bool Flag = false;
            List<HostingUnit> L = DS.DataSource.ListHostingUnits;
            for (int i = 0; i < L.Count; i++)

                if (L[i].getHostingUnitKey() == TheHostingUnit.getHostingUnitKey())
                {
                    L.Remove(L[i]); //need to check if work good
                    Flag = true;
                }
            if (Flag == false)
                Console.WriteLine("the HostingUnitKey is not exict");
        }
        public List<BankBranch> getListOfBankBranch()
        {
            List<BankBranch> List = new List<BE.BankBranch>();
            for (int i = 0; i < 5; i++)
            {     
                BankBranch  bankBranch = new BankBranch("laomy", i, "hatabor", "jerusalem");
                List.Add(bankBranch);
            }            
            return List;
        }
        //returns copies of list by clones
        public List<GuestRequest> getListOfGuestRequest()
        {

            GuestRequest[] newGuestRequest = new GuestRequest[DataSource.ListGuestRequests.Count];
            DataSource.ListGuestRequests.CopyTo(newGuestRequest);
            return newGuestRequest.ToList();
        }
       
        public List<HostingUnit> getListOfHostingUnits()
        {   //לעשות שכפול לרשימה של היחידות אירוח 
       
            HostingUnit[] newHostingUnits = new HostingUnit[DataSource.ListHostingUnits.Count];
            DataSource.ListHostingUnits.CopyTo(newHostingUnits);
            return newHostingUnits.ToList();
     
        }   
        public List<Order> getListOfOrder()
        {
        Order[] newOrders = new Order[DataSource.ListOrders.Count];
        DataSource.ListOrders.CopyTo(newOrders);
        return newOrders.ToList();
    }            
        /// <summary>
        /// 
        /// </summary>
        /// <param name="TheGuestRequest"></param>
        public void NewGuestRequests(GuestRequest TheGuestRequest)
        {
            List<GuestRequest> L = DS.DataSource.ListGuestRequests;
            for (int i = 0; i < L.Count; i++)
                if (L[i].getGuestRequestKey() == TheGuestRequest.getGuestRequestKey())
                {
                    Console.WriteLine("the GuestRequestKey is alredy exist");
                    return;
                }
            DS.DataSource.ListGuestRequests.Add(TheGuestRequest);
        }

        public void NewOrder(BE.Order TheOrder)
        {
            List<Order> L = DS.DataSource.ListOrders;
            for (int i = 0; i < L.Count; i++)
                if (L[i].getOrderKey() == TheOrder.getOrderKey())
                {
                    Console.WriteLine("the OrderKey is alredy exist");
                    return;
                }
            DS.DataSource.ListOrders.Add(TheOrder);
        }

        public void UpdateGuestRequests(GuestRequest TheGuestRequest)
        {
            bool Flag = false;
            List<GuestRequest> L = DS.DataSource.ListGuestRequests;
            for (int i = 0; i < L.Count; i++)
                if (L[i].getGuestRequestKey() == TheGuestRequest.getGuestRequestKey())
                {
                    L[i] = TheGuestRequest; //need to check if work good
                    Flag = true;
                }
            if (Flag == false)
                Console.WriteLine("the GuestRequestKey is not exict");

        }

        public void UpdateDateOrder(Order TheOrder)
        {
            bool Flag = false;
            List<Order> L = DS.DataSource.ListOrders;
            for (int i = 0; i < L.Count; i++)

                if (L[i].getOrderKey() == TheOrder.getOrderKey())
                {
                    L[i] = TheOrder; //need to check if work good
                    Flag = true;
                }
            if (Flag == false)
                Console.WriteLine("the Order is not exict");
        }

        public void UpdateHostingUnit(HostingUnit TheHostingUnit)
        {
            bool Flag = false;
            List<HostingUnit> L = DS.DataSource.ListHostingUnits;
            for (int i = 0; i < L.Count; i++)
                if (L[i].getHostingUnitKey() == TheHostingUnit.getHostingUnitKey())
                {
                    L[i] = TheHostingUnit; //need to check if work good
                    Flag = true;
                }
            if (Flag == false)
                Console.WriteLine("the Order is not exict");
        }

        /// <summary>
        /// SQL LInk gets the wanted area of hosting units
        /// and returns all hostins units in the area
        /// </summary>
        /// <param name="Area"></param>
        /// <returns> list of hosting units in specified area</returns>
        public static List<BE.HostingUnit> ListOfHostingUntisInArea(string Area)
        {
            List<BE.HostingUnit> ListHostingUnitsByArea = new List<BE.HostingUnit>();
            var v = from item in DS.DataSource.ListHostingUnits
                    where item.getArea() == Area
                    select item;

            foreach (var item in v)
                ListHostingUnitsByArea.Add(item);
            return ListHostingUnitsByArea;
        }

    }
}


