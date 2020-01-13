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

            try
            {
                bool Flag = false;
                List<HostingUnit> L = DS.DataSource.ListHostingUnits;
                for (int i = 0; i < L.Count; i++)
                    if (L[i].getHostingUnitKey() == TheHostingUnit.getHostingUnitKey())
                    {
                        L[i] = TheHostingUnit; 
                        Flag = true;
                    }
                if (Flag == false)
                    throw new MissingIdException("HostingUnit", TheHostingUnit.getHostingUnitKey());
            }
            catch (MissingIdException E) { throw E; }

        }

        public void DeleteHostingUnit(int hostUnitKey)
        {
            try
            {
                bool Flag = false;
                List<HostingUnit> L = DS.DataSource.ListHostingUnits;
                for (int i = 0; i < L.Count; i++)

                    if (L[i].getHostingUnitKey() == hostUnitKey)
                    {
                        L.Remove(L[i]); //need to check if work good
                        Flag = true;
                    }
                if (Flag == false)
                    throw new MissingIdException("HostingUnit", hostUnitKey);
            }
            catch (MissingIdException E) { throw E; }
        }

        public List<HostingUnit> getListOfHostingUnits()
        {   //לעשות שכפול לרשימה של היחידות אירוח 

            var temp = from item in DataSource.ListHostingUnits
                       select item;          
            List<HostingUnit> temp2 = new List<HostingUnit>();
            foreach (HostingUnit item in temp)
                temp2.Add(item);
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
            var temp = from item in DataSource.ListGuestRequests
                       select item;
            List<GuestRequest> temp2 = new List<GuestRequest>();
            foreach (GuestRequest item in temp)
             temp2.Add(Cloning.Clone(item));
            return temp2;
        }

        #endregion Guest Requests

        #region Order

        public void NewOrder(BE.Order TheOrder)
        {
            try
            {
                List<Order> L = DS.DataSource.ListOrders;
                for (int i = 0; i < L.Count; i++)
                    if (L[i].OrderKey == TheOrder.OrderKey)
                    {
                        throw new IDalreadyExistsException("Order", TheOrder.OrderKey);

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

                    if (L[i].OrderKey == TheOrder.OrderKey)
                    {
                        L[i] = TheOrder; //need to check if works good
                        Flag = true;
                    }
                if (Flag == false)
                    throw new MissingIdException("Order", TheOrder.OrderKey,"Can not update order dos not exsit");
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
          //  List<Order> temp2 = DS.DataSource.ListOrders;

           // if (temp2.Count!=0)
          //  {
                var temp = from item in DS.DataSource.ListOrders
                           select item;
                List<Order> temp2 = new List<Order>();
                foreach (Order item in temp)
                    temp2.Add(item);
                Order[] target = new Order[temp2.Count];

                temp2.CopyTo(target);

                return target.ToList();
         //   }
         //   else { Order[] target = new Order[4]; return target.ToList(); }
        }
        #endregion Order

        #region Host
        public void UpdateHost(BE.Host theHost)
        {
            try
            {
                bool Flag = false;
                List<Host> L = DS.DataSource.ListHosts;
                for (int i = 0; i < L.Count; i++)
                    if (L[i].HostKey == theHost.HostKey)
                    {
                        L[i] = theHost; //need to check if work good
                        Flag = true;
                    }
                if (Flag == false)
                    throw new MissingIdException("GuestRequest", theHost.HostKey);
            }
            catch (MissingIdException E) { throw E; }
        } 
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
           var temp = from item in DS.DataSource.ListHosts
                      select item;

            // List<Host> temp2 = (List< Host > )temp;
            List<Host> temp2= new List<Host>();          
            foreach (Host item in temp)
                temp2.Add(item);
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


