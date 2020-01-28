using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Xml.Linq;
using System.Xml.Serialization;
using BE;
namespace DAL
{
    class DAL_XML_imp : IDAL
    {
        static XElement configRoot;
        XElement OrderRoot;
        XElement bankBrunchRoot;

       // static readonly string ProjectPath = Directory.GetParent(Directory.GetParent(Environment.CurrentDirectory.ToString()).FullName).FullName;//path of xml files           
        static private readonly string
            OrderPath = @"OrderXML.xml",
            HostingUnitPath = @"HostingUnitXML.xml",
            HostPath = @"HostXML.xml",
            GuestRequestPath = @"GuestRequestXML.xml",
            BankBranchPath = @"atm.xml",
          configPath = @"ConfigurationPathXML.xml";
       // configPath = ProjectPath + "/Data/ConfigurationPathXML.xml";

        public static List<BE.HostingUnit> ListHostingUnit = new List<HostingUnit>();
        public static List<BE.Host> ListHost = new List<Host>();
        public static List<BE.GuestRequest> ListGuestRequest = new List<GuestRequest>();
        public static List<BE.BankBranch> ListBankBranch = new List<BankBranch>();      
        public static List<BE.Order> ListOrder = new List<Order>();

        bool ListOrderChange;
        //  private Dal_imp() { }
        // public static DAL_XML_imp GetDALXml();
        protected static DAL_XML_imp newDAL = null;
        public static DAL_XML_imp GetDALXml()
        {
            if (newDAL == null)
                newDAL = new DAL_XML_imp();
            return newDAL;
        }

        internal DAL_XML_imp()////////////////////////////////////////////////////////////////////
        {
            try
            {
                GetBankXml();

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
                    BE.Configuration.SystemEmail = configRoot.Element("SystemEmail").Value;
                    BE.Configuration.SystemEmailPassward = configRoot.Element("SystemEmailPassward").Value;

                }

                if (!File.Exists(OrderPath))
                {
                    OrderRoot = new XElement("Order");
                    OrderRoot.Save(OrderPath);
                }

                if (!File.Exists(HostPath))
                    SaveToXML(new List<Host>(), HostPath);

                if (!File.Exists(HostingUnitPath))
                    SaveToXML(new List<HostingUnit>(), HostingUnitPath);

                if (!File.Exists(GuestRequestPath))
                    SaveToXML(new List<GuestRequest>(), GuestRequestPath);

                if (!File.Exists(BankBranchPath))
                    SaveToXML(new List<BankBranch>(), BankBranchPath);
                //if (!File.Exists(BankBranchPath))
                //{
                //    bankBrunchRoot = new XElement("Order");
                //    OrderRoot.Save(OrderPath);
                //}

                bankBrunchRoot = XElement.Load(BankBranchPath);
                OrderRoot = XElement.Load(OrderPath);
                ListHost = LoadFromXML<List<Host>>(HostPath);
                ListHostingUnit = LoadFromXML<List<HostingUnit>>(HostingUnitPath);
                ListGuestRequest = LoadFromXML<List<GuestRequest>>(GuestRequestPath);
                //ListBankBranch = LoadFromXML<List<BankBranch>>(BankBranchPath);
            }
            catch { throw new FileProblem("Problem with one of the the Files"); }
            }
        ~DAL_XML_imp()
        {

            // configRoot.Save(configPath);
            SaveConfigToXml();
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
            //SaveConfigToXml();
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
                               new XElement("MangerPassword", BE.Configuration.MangerPassword),
                               new XElement("MangerPassword", BE.Configuration.MangerPassword),
                               new XElement("SystemEmail", BE.Configuration.SystemEmail) ,
                               new XElement("SystemEmailPassward", BE.Configuration.SystemEmailPassward));
                configRoot.Save(configPath);
            }
            
            catch 
            {      throw new  FileProblem("there was a problem with the config file"); }
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
                throw new IDalreadyExistsException("the hosting unit is allready exist");
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
                throw new MissingIdException("the hosting unit is not exist");
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
                for (int i = 0; i < ListGuestRequest.Count; i++)
                    if (ListGuestRequest[i].GuestRequestKey == GuestRequestToAdd.GuestRequestKey)
                        throw new IDalreadyExistsException("GuestRequest", GuestRequestToAdd.GuestRequestKey);
                ListGuestRequest.Add(GuestRequestToAdd);
                SaveToXML(ListGuestRequest, GuestRequestPath);
            }
            catch (Exception E) { throw E; }
        }
        public void UpdateGuestRequests(GuestRequest GuestRequestToUpdate)
        {
            try
            {
                for (int i = 0; i < ListGuestRequest.Count; i++)
                    if (ListGuestRequest[i].GuestRequestKey == GuestRequestToUpdate.GuestRequestKey)
                    {
                        ListGuestRequest[i] = GuestRequestToUpdate;
                        SaveToXML(ListGuestRequest, GuestRequestPath);
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
                for (int i = 0; i < ListHost.Count; i++)
                    if (ListHost[i].HostKey == HostToAdd.HostKey)
                        throw new IDalreadyExistsException("the host is allready exist");
                ListHost.Add(HostToAdd);
                SaveToXML(ListHost, HostPath);
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
                        SaveToXML(ListHost, HostPath);
                        return;
                    }
                throw new MissingIdException("the host  is not exist");
            }
            catch (Exception E) { throw E; }
        }


        public void DeleteHost(Host Host)
        {
            try
            {
                for (int i = 0; i < ListHost.Count; i++)
                    if (ListHost[i].HostKey == Host.HostKey)
                    {
                        ListHost.Remove(ListHost[i]);
                        SaveToXML(ListHost, HostPath);
                        return;
                    }
                throw new IDalreadyExistsException("the Host is not exist");
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
               //if(ListOrderChange==true)
              //  {
                    ListOrder.Clear();
                    BE.Order TempOrder = new BE.Order();
                    foreach (var order in OrderRoot.Elements())
                    {
                        BE.Order TempOrder1 = new BE.Order();
                        TempOrder1.OrderKey = Int32.Parse(order.Element("OrderKey").Value);
                        TempOrder1.HostingUnitKey = Int32.Parse(order.Element("HostingUnitKey").Value);
                        TempOrder1.GuestRequestKey = Int32.Parse(order.Element("GuestRequestKey").Value);
                        TempOrder1.Status = (Status)Enum.Parse(typeof(Status), order.Element("Status").Value);

                        TempOrder1.contactCustumerDate = DateTime.Parse(order.Element("contactCustumerDate").Value);
                        TempOrder1.CreateDate = DateTime.Parse(order.Element("CreateDate").Value);

                        ListOrder.Add(TempOrder1);
                    }
               
              //  }
                ListOrderChange = false;
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
                                       where Int32.Parse(t.Element("OrderKey").Value) == TheOrder.OrderKey
                                     select t).FirstOrDefault();
            if (OrderElement == null)
                throw new KeyNotFoundException("key: " + TheOrder.OrderKey+" not founed");
             OrderElement.Remove();
                OrderRoot.Save(OrderPath);
            
         
        }
        public void NewOrder(BE.Order TheOrder)
        {
          foreach(var Order in OrderRoot.Elements())         
            if (Int32.Parse(Order.Element("OrderKey").Value) == TheOrder.OrderKey)
                throw new IDalreadyExistsException("the order is already exit");
            try
            {
                XElement O = new XElement("Order") ;
                O.Add(new XElement("GuestRequestKey", TheOrder.GuestRequestKey.ToString()),
                     new XElement("HostingUnitKey", TheOrder.HostingUnitKey.ToString()),
                    new XElement("OrderKey", TheOrder.OrderKey.ToString()),
                      new XElement("Status", TheOrder.Status.ToString()),
                      new XElement("contactCustumerDate", TheOrder.contactCustumerDate.ToString()),
                      new XElement("CreateDate", TheOrder.CreateDate.ToString())   );

                ListOrderChange = true;
                OrderRoot.Add(O);
                OrderRoot.Save(OrderPath);
              // ListChainged = true;
            }
            catch (Exception E)
            { throw E; }
        }
        public void UpdateDateOrder(BE.Order TheOrder)
        {
            try
            {
                XElement t = (from item in OrderRoot.Elements()
                              where item.Element("OrderKey").Value == TheOrder.OrderKey.ToString()
                              select item).FirstOrDefault();
                
                  t.Element("Status").Value = TheOrder.Status.ToString();
                OrderRoot.Save(OrderPath);
            }
            catch (Exception)
            {
                throw new KeyNotFoundException("the order is not exict " + TheOrder.OrderKey);
            }
        }
        #endregion Order
        public List<BankBranch> getListOfBankBranch()
        {                     

            try
            {
                return (from BankBranch in bankBrunchRoot.Elements()
                        select new BankBranch()
                        {
                            BankName = BankBranch.Element("שם_בנק").Value.Trim(),
                           // BankNumber = Convert.ToInt32(BankBranch.Element("קוד_בנק").Value.Trim()),
                            BranchAddress = BankBranch.Element("כתובת_ה-ATM").Value.Trim(),
                            BranchCity = BankBranch.Element("ישוב").Value.Trim(),
                            BranchNumber = Convert.ToInt32(BankBranch.Element("קוד_סניף").Value.Trim())
                        }
                        ).Distinct().ToList();
            }
            catch (Exception ex)
            {
                 throw new FileProblem("file_problem_banks_brunches ");
               // throw ex;
            }
        }                  
    public void  GetBankXml()
        {
            const string xmlLocalPath = @"atm.xml";
            WebClient wc = new WebClient();
            try
            {
                string xmlServerPath =
               @"http://www.jct.ac.il/~coshri/atm.xml";
                wc.DownloadFile(xmlServerPath, xmlLocalPath);
            }
            catch (Exception)
            {
                string xmlServerPath = @"https://drive.google.com/file/d/1FpcqslnRD6naLHOjrCvKArCg3Ihkb9hR/view?usp=sharing";
                wc.DownloadFile(xmlServerPath, xmlLocalPath);
            }
            finally
            {
                wc.Dispose();
            }

        }


    }

}
