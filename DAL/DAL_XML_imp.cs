using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Xml.Linq;
using System.Xml.Serialization;
using BE;
namespace DAL
{
    class DAL_XML_imp : IDAL
    {
        XElement configRoot;
        XElement OrderRoot;

        static private readonly string
            OrderPath = @"OrderXML.xml",
            HostingUnitPath = @"HostingUnitXML.xml",
            HostPath = @"HostXML.xml",
            GuestRequestPath = @"GuestRequestXML.xml",
            BankBranchPath = @"BankBranchXML.xml",
            configPath = @"configPathXML.xml";

        public static List<BE.HostingUnit> ListHostingUnit = new List<HostingUnit>();
        public static List<BE.Host> ListHost = new List<Host>();
        public static List<BE.GuestRequest> ListGuestRequest = new List<GuestRequest>();
        public static List<BE.BankBranch> ListBankBranch = new List<BankBranch>();
        public static List<BE.Order> ListOrder = new List<Order>();

        internal DAL_XML_imp()////////////////////////////////////////////////////////////////////
        {
            if (!File.Exists(configPath))
            {
                SaveConfigToXml();
            }
            else
            {
                configRoot = XElement.Load(configPath);
                BE.Configuration.HostingUnitKey = Convert.ToInt32(configRoot.Element("HostingUnitKey").Value);
                BE.Configuration.GuestRequestKey = Convert.ToInt32(configRoot.Element("GuestRequestKey").Value);
                BE.Configuration.HostKey = Convert.ToInt32(configRoot.Element("HostKey").Value);
                BE.Configuration.Commission = Convert.ToInt32(configRoot.Element("Commission").Value);
                BE.Configuration.Password = Convert.ToInt32(configRoot.Element("Password").Value);
                BE.Configuration.MangerPassword = configRoot.Element("MangerPassword").Value;

            }

            if (!File.Exists(OrderPath))
                OrderRoot = new XElement("Order");
            OrderRoot.Save(OrderPath);

            if (!File.Exists(HostPath))
                SaveToXML(new List<Host>(), HostPath);

            if (!File.Exists(HostingUnitPath))
                SaveToXML(new List<HostingUnit>(), HostingUnitPath);

            if (!File.Exists(GuestRequestPath))
                SaveToXML(new List<Configuration>(), GuestRequestPath);

            ListGuestRequest = LoadFromXML<List<GuestRequest>>(GuestRequestPath);
            ListHost = LoadFromXML<List<Host>>(HostPath);
            ListBankBranch = LoadFromXML<List<BankBranch>>(BankBranchPath);
            ListHostingUnit = LoadFromXML<List<HostingUnit>>(HostingUnitPath);

        }
        ~DAL_XML_imp()
        {
            OrderRoot.Save(OrderPath);
            SaveToXML<List<GuestRequest>>(ListGuestRequest, GuestRequestPath);
            SaveToXML<List<HostingUnit>>(ListHostingUnit, HostingUnitPath);
            SaveToXML<List<Host>>(ListHost, HostPath);

            SaveConfigToXml();
        }

        # region XmL And ConfigtoXml Func
        public static void SaveToXML<T>(T source, string path)
        {
            FileStream file = new FileStream(path, FileMode.Create);
            XmlSerializer xmlSerializer = new XmlSerializer(source.GetType());
            xmlSerializer.Serialize(file, source);
            file.Close();
        }

        /// <summary>
        /// Load From XML tamplate
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="path"></param>
        /// <returns></returns>
        public static T LoadFromXML<T>(string path)
        {
            FileStream file = new FileStream(path, FileMode.Open);
            XmlSerializer xmlSerializer = new XmlSerializer(typeof(T));
            T result = (T)xmlSerializer.Deserialize(file);
            file.Close();
            return result;
        }

        private void SaveConfigToXml()
        {//craete new ele
            configRoot = new XElement("config");
            try
            {
                configRoot.Add(new XElement("HostingUnitKey", BE.Configuration.HostingUnitKey),
                               new XElement("GuestRequestKey", BE.Configuration.GuestRequestKey),
                               new XElement("HostKey", BE.Configuration.HostKey),
                               new XElement("OrderKey", BE.Configuration.OrderKey),
                               new XElement("Commission", BE.Configuration.Commission),
                               new XElement("Password", BE.Configuration.Password),
                               new XElement("MangerPassword", BE.Configuration.MangerPassword));
                configRoot.Save(configPath);
            }
            catch (Exception e)
            { throw e; }
        }
        #endregion  XmL And ConfigtoXml Func

        #region Hosting Unit
        public void AddNewHostingUnit(HostingUnit HostingUnitToAdd)
        {//לעשות פונ מיוחדת למטריצה              
            try
            {
                for (int i = 0; i < ListHostingUnit.Count; i++)
                    if (ListHostingUnit[i].HostingUnitKey == HostingUnitToAdd.HostingUnitKey)
                        throw new IDalreadyExistsException("HostingUnit", HostingUnitToAdd.HostingUnitKey);
                ListHostingUnit.Add(HostingUnitToAdd);
                SaveToXML(ListHostingUnit, HostingUnitPath);
            }
            catch (Exception E) { throw E; }
        }
        public void UpdateHostingUnit(HostingUnit HostingUnitToUpdate)
        {

            try
            {
                for (int i = 0; i < ListHostingUnit.Count; i++)
                    if (ListHostingUnit[i].HostingUnitKey == HostingUnitToUpdate.HostingUnitKey)
                    {
                        ListHostingUnit[i] = HostingUnitToUpdate;
                        SaveToXML(ListHostingUnit, HostingUnitPath);
                        return;
                    }
                throw new IDalreadyExistsException("HostingUnit", HostingUnitToUpdate.HostingUnitKey);
            }
            catch (Exception E) { throw E; }
        }
        public void DeleteHostingUnit(int hostUnitKey)
        {
            try
            {
                for (int i = 0; i < ListHostingUnit.Count; i++)
                    if (ListHostingUnit[i].HostingUnitKey == hostUnitKey)
                    {
                        ListHostingUnit.Remove(ListHostingUnit[i]);
                        SaveToXML(ListHostingUnit, HostingUnitPath);
                        return;
                    }
                throw new IDalreadyExistsException("HostingUnit", hostUnitKey);
            }
            catch (Exception E) { throw E; }
        }
        public List<HostingUnit> getListOfHostingUnits()
        {   //לעשות שכפול לרשימה של היחידות אירוח 

            var temp = from item in ListHostingUnit
                       select item;
            List<HostingUnit> temp2 = new List<HostingUnit>();
            foreach (var item in temp)
                temp2.Add(Cloning.Clone(item));
            return temp2;
        }
        #endregion Hosting Unit
        #region Guest Request
        public void NewGuestRequests(GuestRequest GuestRequestToAdd)
        {//לעשות פונ מיוחדת למטריצה              
            try
            {
                for (int i = 0; i < ListHostingUnit.Count; i++)
                    if (ListHostingUnit[i].HostingUnitKey == GuestRequestToAdd.GuestRequestKey)
                        throw new IDalreadyExistsException("GuestRequest", GuestRequestToAdd.GuestRequestKey);
                ListGuestRequest.Add(GuestRequestToAdd);
                SaveToXML(ListHostingUnit, HostingUnitPath);
            }
            catch (Exception E) { throw E; }
        }
        public void UpdateGuestRequests(GuestRequest GuestRequestToUpdate)
        {
            try
            {
                for (int i = 0; i < ListHostingUnit.Count; i++)
                    if (ListHostingUnit[i].HostingUnitKey == GuestRequestToUpdate.GuestRequestKey)
                    {
                        ListGuestRequest[i] = GuestRequestToUpdate;
                        SaveToXML(ListHostingUnit, HostingUnitPath);
                        return;
                    }
                throw new IDalreadyExistsException("HostingUnit", GuestRequestToUpdate.GuestRequestKey);
            }
            catch (Exception E) { throw E; }
        }
        public void DeleteGuestRequests(GuestRequest GuestRequest)
        {
            try
            {
                for (int i = 0; i < ListGuestRequest.Count; i++)
                    if (ListGuestRequest[i].GuestRequestKey == GuestRequest.GuestRequestKey)
                    {
                        ListGuestRequest.Remove(ListGuestRequest[i]);
                        SaveToXML(ListGuestRequest, GuestRequestPath);
                        return;
                    }
                throw new IDalreadyExistsException("GuestRequest", GuestRequest.GuestRequestKey);
            }
            catch (Exception E) { throw E; }
        }
        public List<GuestRequest> getListOfGuestRequest()
        {

            var temp = from item in ListGuestRequest
                       select item;
            List<GuestRequest> temp2 = new List<GuestRequest>();
            foreach (var item in temp)
                temp2.Add(Cloning.Clone(item));
            return temp2;
        }
        #endregion Guest Request

        #region Host
        public void AddNewHost(Host HostToAdd)
        {//לעשות פונ מיוחדת למטריצה              
            try
            {
                for (int i = 0; i < ListHostingUnit.Count; i++)
                    if (ListHostingUnit[i].HostingUnitKey == HostToAdd.HostKey)
                        throw new IDalreadyExistsException("HostingUnit", HostToAdd.HostKey);
                ListHost.Add(HostToAdd);
                SaveToXML(ListHostingUnit, HostingUnitPath);
            }
            catch (Exception E) { throw E; }
        }


        public void UpdateHost(Host HostToUpdate)
        {

            try
            {
                for (int i = 0; i < ListHost.Count; i++)
                    if (ListHost[i].HostKey == HostToUpdate.HostKey)
                    {
                        ListHost[i] = HostToUpdate;
                        SaveToXML(ListHostingUnit, HostingUnitPath);
                        return;
                    }
                throw new IDalreadyExistsException("HostingUnit", HostToUpdate.HostKey);
            }
            catch (Exception E) { throw E; }
        }


        public void DeleteHost(Host Host)
        {
            try
            {
                for (int i = 0; i < ListHostingUnit.Count; i++)
                    if (ListHost[i].HostKey == Host.HostKey)
                    {
                        ListHost.Remove(ListHost[i]);
                        SaveToXML(ListHost, HostPath);
                        return;
                    }
                throw new IDalreadyExistsException("Host)", Host.HostKey);
            }
            catch (Exception E) { throw E; }
        }


        public List<Host> getListOfHost()
        {

            var temp = from item in ListHost
                       select item;
            List<Host> temp2 = new List<Host>();
            foreach (var item in temp)
                temp2.Add(Cloning.Clone(item));
            return temp2;
        }
        #endregion Host


        #region Order
        public List<BE.Order> getListOfOrder()
        {
            try
            {
                BE.Order aa = new BE.Order();
                foreach (var order in OrderRoot.Elements())
                {
                    BE.Order TempOrder = new BE.Order();
                    TempOrder.OrderKey = Int32.Parse(order.Element("OrderKey").Value);
                    TempOrder.GuestRequestKey = Int32.Parse(order.Element("GuestRequestKey").Value);
                    TempOrder.Status = (Status)Enum.Parse(typeof(Status), order.Element("Status").Value);

                    TempOrder.contactCustumerDate = DateTime.Parse(order.Element("contactCustumerDate").Value);
                    TempOrder.CreateDate = DateTime.Parse(order.Element("CreateDate").Value);

                    ListOrder.Add(TempOrder);
                }
                return ListOrder;
            }
            catch (Exception)
            {
                throw new FileProblem("Problem with the Orders File");
            }

        }
        public void Deleteorder(BE.Order TheOrder)
        {
            XElement OrderElement = (from t in OrderRoot.Elements()
                                       where Int32.Parse(t.Element("ID").Value) == TheOrder.OrderKey
                                     select t).FirstOrDefault();
            if (OrderElement == null)
                throw new KeyNotFoundException("לא נמצא תלמיד שמספרו " + TheOrder.OrderKey);
            try
            {
                OrderElement.Remove();
                // OrderListChainged = true;
                OrderRoot.Save(OrderPath);
            }
            catch (Exception E)
            {
                throw E;
            }
        }
        public void NewOrder(BE.Order TheOrder)
        {
          foreach(var Order in OrderRoot.Elements())         
            if (Int32.Parse(Order.Element("OrderKey").Value) == TheOrder.OrderKey)
                throw new IDalreadyExistsException("the order is already exit");
            try
            {
                XElement O = new XElement("Order");
                O.Add(new XElement("ID", TheOrder.GuestRequestKey.ToString()),
                      new XElement("FirstName", TheOrder.OrderKey.ToString()),
                      new XElement("LastName", TheOrder.Status.ToString()),
                      new XElement("BirthDate", TheOrder.contactCustumerDate.ToString()),
                      new XElement("Gender", TheOrder.CreateDate.ToString())   );

                OrderRoot.Add(O);
                OrderRoot.Save(OrderPath);
              // ListChainged = true;
            }
            catch (Exception E)
            { throw E; }
        }
        public void UpdateDateOrder(BE.Order TheOrder)
        {
           
        }
        #endregion Order
        public List<BankBranch> getListOfBankBranch()
        {                      //לראות מה עושים עם הרשימת בנקים... 

            var temp = from item in ListBankBranch
                       select item;
            List<BankBranch> temp2 = new List<BankBranch>();
            for (int i = 0; i < 5; i++)
            {
                BankBranch bankBranch = new BankBranch("laomy", i, "hatabor", "jerusalem");
                temp2.Add(bankBranch);
            }
            return temp2;
        }
    }

}
