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


        /// <summary>
        /// make sure that we will craete only one object from this class
        /// </summary>
        /// 
        private DAL() { }
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
                    
             throw new IDalreadyExistsException("HostingUnit", TheHostingUnit.getHostingUnitKey());
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
                throw new MissingIdException("HostingUnit", TheHostingUnit.getHostingUnitKey());
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
      public  List<BE.Host> getListOfHost()
        {
            Host[] newHost = new Host[DataSource.ListHosts.Count];
            DataSource.ListHosts.CopyTo(newHost);
            return newHost.ToList();
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

            public IEnumerable<Order> GetAllOrders()
            {
                var temp = from item in DataSource.ordersList
                           select item;
                List<Order> temp2 = (List<Order>)temp;
                Order[] target = new Order[temp2.Count];
                temp2.CopyTo(target);

                return target.ToList();
            }

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
                    throw new IDalreadyExistsException("GuestRequest", TheGuestRequest.getGuestRequestKey());
                   
                }
            DS.DataSource.ListGuestRequests.Add(TheGuestRequest);
        }

        public void NewOrder(BE.Order TheOrder)
        {
            List<Order> L = DS.DataSource.ListOrders;
            for (int i = 0; i < L.Count; i++)
                if (L[i].getOrderKey() == TheOrder.getOrderKey())
                {
                    throw new IDalreadyExistsException("Order", TheOrder.getOrderKey());
                   
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
                throw new MissingIdException("GuestRequest", TheGuestRequest.getGuestRequestKey());

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
                throw new MissingIdException("Order", TheOrder.getOrderKey());
        }

        public void UpdateHostingUnit(HostingUnit TheHostingUnit)
        {

            //var v= from HostingUnit unit in DS.DataSource.ListHostingUnits
            //where unit.getHostingUnitKey() == TheHostingUnit.getHostingUnitKey()
            //select unit ;         
            //foreach (var item in v)
            //    item = TheHostingUnit;

            bool Flag = false;
            List<HostingUnit> L = DS.DataSource.ListHostingUnits;
            for (int i = 0; i < L.Count; i++)
                if (L[i].getHostingUnitKey() == TheHostingUnit.getHostingUnitKey())
                {
                    L[i] = TheHostingUnit; //need to check if work good
                    Flag = true;
                }
            if (Flag == false)
                throw new MissingIdException("HostingUnit", TheHostingUnit.getHostingUnitKey());

           
        }
        /// <summary>
        /// SQL LInk gets the wanted area of hosting units
        /// and returns all hostins units in the area
        /// </summary>
        /// <param name="Area"></param>
        /// <returns> list of hosting units in specified area</returns>
        //public static List<BE.HostingUnit> ListOfHostingUntisInArea(string Area)
        //{
        //    List<BE.HostingUnit> ListHostingUnitsByArea = new List<BE.HostingUnit>();
        //    var v = from item in DS.DataSource.ListHostingUnits
        //            where item.getArea() == Area
        //            select item;

        //    foreach (var item in v)
        //        ListHostingUnitsByArea.Add(item);
        //    return ListHostingUnitsByArea;
        //}

    }
}


