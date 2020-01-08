using System;
using System.Collections.Generic;
using System.Text;
using BE;
using DS;
using System.Linq;

 
namespace DAL
{
    public class Dal_imp : IDAL
    {
       

        /// <summary>
        /// make sure that we will craete only one object from this class
        /// </summary>
        /// 
        private Dal_imp() { }
        protected static Dal_imp newDAL = null;
        public static Dal_imp GetDAL()
        {
            if (newDAL == null)
                newDAL = new Dal_imp();
            return newDAL;
        }

        #region Hosting Unit

        public void AddNewHostingUnit(HostingUnit TheHostingUnit)
        {
            try
            {
                List<HostingUnit> L = DS.DataSource.ListHostingUnits;
                for (int i = 0; i < L.Count; i++)
                    if (L[i].getHostingUnitKey() == TheHostingUnit.getHostingUnitKey())

                        throw new IDalreadyExistsException("HostingUnit", TheHostingUnit.getHostingUnitKey());
                DS.DataSource.ListHostingUnits.Add(TheHostingUnit);
            }
            catch (IDalreadyExistsException E) { throw E; }

        }

        public void UpdateHostingUnit(HostingUnit TheHostingUnit)
        {

            //var v= from HostingUnit unit in DS.DataSource.ListHostingUnits
            //where unit.getHostingUnitKey() == TheHostingUnit.getHostingUnitKey()
            //select unit ;         
            //foreach (var item in v)
            //    item = TheHostingUnit;
            try
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
                    throw new MissingIdException("HostingUnit", TheHostingUnit.getHostingUnitKey());
            }
            catch (MissingIdException E) { throw E; }

        }

        public void DeleteHostingUnit(HostingUnit TheHostingUnit)
        {
            try
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
            catch (MissingIdException E) { throw E; }
        }

        public List<HostingUnit> getListOfHostingUnits()
        {   //לעשות שכפול לרשימה של היחידות אירוח 

            var temp = from item in DataSource.ListHostingUnits
                       select item;
            List<HostingUnit> temp2 = (List<HostingUnit>)temp;
            HostingUnit[] target = new HostingUnit[temp2.Count];
            temp2.CopyTo(target);

            return target.ToList();

        }

        #endregion Hosting Unit

        #region Guest Requests

        public void NewGuestRequests(GuestRequest TheGuestRequest)
        {
            try
            {
                List<GuestRequest> L = DS.DataSource.ListGuestRequests;
                for (int i = 0; i < L.Count; i++)
                    if (L[i].getGuestRequestKey() == TheGuestRequest.getGuestRequestKey())
                    {
                        throw new IDalreadyExistsException("GuestRequest", TheGuestRequest.getGuestRequestKey());

                    }
                DS.DataSource.ListGuestRequests.Add(TheGuestRequest);
            }
            catch (IDalreadyExistsException E) { throw E; }
        }

        public void UpdateGuestRequests(GuestRequest TheGuestRequest)
        {
            try
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
            catch (MissingIdException E) { throw E; }
        }

        public void DeleteGuestRequests(BE.GuestRequest theGuestRequests)
        {
            try
            {
                bool Flag = false;
                List<GuestRequest> L = DS.DataSource.ListGuestRequests;
                for (int i = 0; i < L.Count; i++)

                    if (L[i].GuestRequestKey == theGuestRequests.GuestRequestKey)
                    {
                        L.Remove(L[i]); //need to check if work good
                        Flag = true;
                    }
                if (Flag == false)
                    throw new MissingIdException("GuestRequest", theGuestRequests.GuestRequestKey);
            }
            catch (MissingIdException E) { throw E; }
        }

        public List<GuestRequest> getListOfGuestRequest()
        {

            var temp = from item in DataSource.ListHosts
                       select item;
            List<GuestRequest> temp2 = (List<GuestRequest>)temp;
            GuestRequest[] target = new GuestRequest[temp2.Count];
            temp2.CopyTo(target);

            return target.ToList();
        }

        #endregion Guest Requests

        #region Order

        public void NewOrder(BE.Order TheOrder)
        {
            try
            {
                List<Order> L = DS.DataSource.ListOrders;
                for (int i = 0; i < L.Count; i++)
                    if (L[i].getOrderKey() == TheOrder.getOrderKey())
                    {
                        throw new IDalreadyExistsException("Order", TheOrder.getOrderKey());

                    }
                DS.DataSource.ListOrders.Add(TheOrder);
            }
            catch (IDalreadyExistsException E) { throw E; }
        }

        public void UpdateDateOrder(Order TheOrder)
        {
            try
            {
                bool Flag = false;
                List<Order> L = DS.DataSource.ListOrders;
                for (int i = 0; i < L.Count; i++)

                    if (L[i].getOrderKey() == TheOrder.getOrderKey())
                    {
                        L[i] = TheOrder; //need to check if works good
                        Flag = true;
                    }
                if (Flag == false)
                    throw new MissingIdException("Order", TheOrder.getOrderKey(),"Can not update order dos not exsit");
            }
            catch (MissingIdException E) { throw E; }
        }
        public void Deleteorder(BE.Order TheOrder)
        {
            try
            {
                bool Flag = false;
                List<Order> L = DS.DataSource.ListOrders;
                for (int i = 0; i < L.Count; i++)

                    if (L[i].GuestRequestKey == TheOrder.OrderKey)
                    {
                        L.Remove(L[i]); //need to check if work good
                        Flag = true;
                    }
                if (Flag == false)
                    throw new MissingIdException("order", TheOrder.OrderKey);
            }
            catch (MissingIdException E) { throw E; }
        }

        public List<Order> getListOfOrder()
        {
            var temp = from item in DataSource.ListOrders
                       select item;
            List<Order> temp2 = (List<Order>)temp;
            Order[] target = new Order[temp2.Count];
            temp2.CopyTo(target);

            return target.ToList();
        }
        #endregion Order

        #region Host

        public void DeleteHost(BE.Host TheHost)
        {
            try
            {
                bool Flag = false;
                List<Host> L = DS.DataSource.ListHosts;
                for (int i = 0; i < L.Count; i++)

                    if (L[i].HostKey == TheHost.HostKey)
                    {
                        L.Remove(L[i]); //need to check if work good
                        Flag = true;
                    }
                if (Flag == false)
                    throw new MissingIdException("Host", TheHost.HostKey);
            }
            catch (MissingIdException E) { throw E; }
        }


        public List<BE.Host> getListOfHost()
        {
            var temp = from item in DataSource.ListHosts
                       select item;
            List<Host> temp2 = (List<Host>)temp;
            Host[] target = new Host[temp2.Count];
            temp2.CopyTo(target);

            return target.ToList();
        }

        #endregion Host


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
     
      
   
      

     
       

        
        

    }
}


