using System;
using System.Collections.Generic;
using System.Text;
using BE;
using DS;
using System.Linq;
using System.Net;

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
        public void GetBankXml() {
            const string xmlLocalPath = @"atm.xml";
            //WebClient wc = new WebClient();
            //try
            //{
            //    string xmlServerPath =
            //@"http://www.jct.ac.il/~coshri/atm.xml";
            //    wc.DownloadFile(xmlServerPath, xmlLocalPath);
            //}
            //catch (Exception)
            //{
            //    string xmlServerPath = @"http://www.jct.ac.il/~coshri/atm.xml";
            //    wc.DownloadFile(xmlServerPath, xmlLocalPath);
            //}
            //finally
            //{
            //    wc.Dispose();
            //}
        }
        public void AddNewHostingUnit(HostingUnit TheHostingUnit)
        {
            try
            {
                List<HostingUnit> L = DS.DataSource.ListHostingUnits;
                for (int i = 0; i < L.Count; i++)
                    if (L[i].HostingUnitKey == TheHostingUnit.HostingUnitKey)
                        throw new IDalreadyExistsException("HostingUnit", TheHostingUnit.HostingUnitKey);
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
                    if (L[i].HostingUnitKey == TheHostingUnit.HostingUnitKey)
                    {
                        L[i] = TheHostingUnit; 
                        Flag = true;
                    }
                if (Flag == false)
                    throw new MissingIdException("HostingUnit", TheHostingUnit.HostingUnitKey);
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

                    if (L[i].HostingUnitKey == hostUnitKey)
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
            foreach (var item in temp)
                temp2.Add(Cloning.Clone(item));
            return temp2;
        }

        #endregion Hosting Unit

        #region Guest Requests

        public void NewGuestRequests(GuestRequest TheGuestRequest)
        {
            try
            {
                List<GuestRequest> L = DS.DataSource.ListGuestRequests;
                for (int i = 0; i < L.Count; i++)
                    if (L[i].GuestRequestKey == TheGuestRequest.GuestRequestKey)
                    {
                        throw new IDalreadyExistsException("GuestRequest", TheGuestRequest.GuestRequestKey);

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
                    if (L[i].GuestRequestKey == TheGuestRequest.GuestRequestKey)
                    {
                        L[i] = TheGuestRequest;
                        Flag = true;
                    }
                if (Flag == false)
                    throw new MissingIdException("GuestRequest", TheGuestRequest.GuestRequestKey);
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
            var temp = from item in DataSource.ListOrders
                       select item;
            List<Order> temp2 = new List<Order>();
            foreach (var item in temp)
                temp2.Add(Cloning.Clone(item));
            return temp2;
        }
        #endregion Order

        #region Host

        public void AddNewHost(Host TheHost)
        {
            try
            {
                List<HostingUnit> L = DS.DataSource.ListHostingUnits;
                for (int i = 0; i < L.Count; i++)
                    if (L[i].HostingUnitKey == TheHost.HostKey)
                        throw new IDalreadyExistsException("Host", TheHost.HostKey);
                DS.DataSource.ListHosts.Add(TheHost);
            }
            catch (IDalreadyExistsException E) { throw E; }

        }
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
            var temp = from item in DataSource.ListHosts
                       select item;
            List<Host> temp2 = new List<Host>();
            foreach (var item in temp)
                temp2.Add(Cloning.Clone(item));
            return temp2;
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


