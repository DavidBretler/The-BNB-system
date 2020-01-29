using System;
using System.Collections.Generic;
using System.Text;
using BE;
using DAL;
using System.Linq;
using System.Net.Mail;

/// <summary>
/// /////////////////////////////////////////////////////
/// </summary>

namespace BL
{
    public class BL_imp : IBL
    {

        
        IDAL dal = FactoryDal.GetDal();

        private BL_imp() { }
        protected static BL_imp newBL =  null;
        public static BL_imp GetBL()
        {
            if (newBL == null)
                newBL = new BL_imp();
            return newBL;
        }

        #region lists      

        public List<BankBranch> getListOfBankBranch()
        {
            return dal.getListOfBankBranch();
            //throw new NotImplementedException();
        }

        public List<GuestRequest> getListOfGuestRequest()
        {
            return dal.getListOfGuestRequest();
            throw new NotImplementedException();
        }

        public List<HostingUnit> getListOfHostingUnits()
        {
            return dal.getListOfHostingUnits();
            throw new NotImplementedException();
        }
        public List<Host> getListOfHost()
        {
            return dal.getListOfHost();
            throw new NotImplementedException();
        }


        public List<Order> getListOfOrder()
        {
            return dal.getListOfOrder();
            throw new NotImplementedException();
        }
        #endregion lists

        #region Hosting unit
        /// <summary>
        /// gets the informtion of the new hosting unit and ads in to the data base
        /// </summary>
        /// <param name="Owner"></param>
        /// <param name="HostingUnitName"></param>
        /// <param name="NumOfRooms"></param>
        /// <param name="NumOfBeds"></param>
        /// <param name="pool"></param>
        /// <param name="Jacuzzi"></param>
        /// <param name="Area"></param>
        /// <param name="Garden"></param>
        /// <param name="AirConditioner"></param>
        /// <param name="ChildrensAttractions"></param>
        /// <param name="Type"></param>
        /// <param name="Hikes"></param>
        /// <param name="Diary"></param>
        public void AddNewHostingUnit(HostingUnit NewHostingUnit)
        {

            Host host = new Host();


            if (cheakIfHostExsits(NewHostingUnit.Owner.HostKey, ref host))//need enter the host key.
            {
                //HostingUnit EnterdHostingUnit = new HostingUnit();
                //EnterdHostingUnit.HostingUnitKey = Configuration.getNewHostingUnitKey();
                //EnterdHostingUnit.HostingUnitName= NewHostingUnit.HostingUnitName;
                //EnterdHostingUnit.NumOfRooms= NewHostingUnit.NumOfRooms;
                //EnterdHostingUnit.NumOfBeds= NewHostingUnit.NumOfBeds;
                //EnterdHostingUnit.pool= NewHostingUnit.pool;
                //EnterdHostingUnit.Jacuzzi= NewHostingUnit.Jacuzzi;
                //EnterdHostingUnit.Area= NewHostingUnit.Area;
                //EnterdHostingUnit.Garden= NewHostingUnit.Garden;
                //EnterdHostingUnit.AirConditioner=(NewHostingUnit.AirConditioner);
                //EnterdHostingUnit.ChildrensAttractions=(NewHostingUnit.ChildrensAttractions);
                //EnterdHostingUnit.Type=(NewHostingUnit.Type);
                //EnterdHostingUnit.Hikes=(NewHostingUnit.Hikes);
                //EnterdHostingUnit.Owner=(host); //??
                NewHostingUnit.HostingUnitKey= Configuration.getNewHostingUnitKey();
                dal.AddNewHostingUnit(NewHostingUnit);
            }
            else
                throw new MissingIdException("HostingUnit", NewHostingUnit.Owner.HostKey, "the host does not exict");
           }

        /// <summary>
        /// gets all the info foe the unit and updates 
        /// </summary>
        /// <param name="HostingUnitName"></param>
        /// <param name="NumOfRooms"></param>
        /// <param name="NumOfBeds"></param>
        /// <param name="pool"></param>
        /// <param name="Jacuzzi"></param>
        /// <param name="Area"></param>
        /// <param name="Garden"></param>
        /// <param name="AirConditioner"></param>
        /// <param name="ChildrensAttractions"></param>
        /// <param name="Type"></param>
        /// <param name="Hikes"></param>
        /// <param name="KeyOfHost"></param>
        public void UpdateHostingUnit(BE.HostingUnit theHostingUnit)

        {
            Host host = new Host();
            if (cheakIfHostExsits(theHostingUnit.Owner.HostKey, ref host))//need enter the host key.
            {
                //HostingUnit EnterdHostingUnit = new HostingUnit();
                //EnterdHostingUnit.HostingUnitKey = Configuration.getNewHostingUnitKey();
                //EnterdHostingUnit.HostingUnitName=HostingUnitName;
                //EnterdHostingUnit.NumOfRooms=NumOfRooms;
                //EnterdHostingUnit.NumOfBeds=NumOfBeds;
                //EnterdHostingUnit.pool=pool;
                //EnterdHostingUnit.Jacuzzi=Jacuzzi;
                //EnterdHostingUnit.Area=Area;
                //EnterdHostingUnit.Garden=Garden;
                //EnterdHostingUnit.AirConditioner=(AirConditioner);
                //EnterdHostingUnit.ChildrensAttractions=(ChildrensAttractions);
                //EnterdHostingUnit.Type=(Type);
                //EnterdHostingUnit.Hikes=(Hikes);
                //EnterdHostingUnit.Owner=(host);
                dal.UpdateHostingUnit(theHostingUnit);
            }
            else
                throw new MissingIdException("HostingUnit", theHostingUnit.Owner.HostKey, "בדוק את מספר התעודה של המארח.");

        }

        /// <summary>
        /// check if the hostingunit that we want to delete  has been booked in a order before 
        /// if yes send exepction if not use the delete func from dal
        /// </summary>
        /// <param name="TheHostingUnit"></param>
        public void DeleteHostingUnit(int hostUnitKey)
        {
           // try
           // {
                List<BE.Order> problomaticOrderS = dal.getListOfOrder().FindAll(delegate (Order order) { return order.HostingUnitKey == hostUnitKey; });
                if (problomaticOrderS.Count > 0)
                {
                    foreach (Order item in problomaticOrderS)
                        if (item.Status == (Status)2)
                        
                            if (GetGuestRequestFromOrder(item).EntryDate > DateTime.Now)
                                throw new keyBeenBooked("hostingUint", hostUnitKey, problomaticOrderS," מס ההזמנה הוזמן כבר");                                       
                                dal.DeleteHostingUnit(hostUnitKey);
                }
                else
                    dal.DeleteHostingUnit(hostUnitKey);
           // }
           // catch 
           // {
            //    throw ;
           // }

        }

        public HostingUnit SearchForHostinUnitByKey(int Key)
        {
            var hostingUnit = dal.getListOfHostingUnits().Find(x => x.HostingUnitKey == Key);
            if (hostingUnit == null)
                throw new MissingIdException("hostingUnit", Key, "The hostingUnit dose not exsit");
            return hostingUnit;
        }


        #endregion Hosting unit

        #region Host
        /// <summary>
        /// the function scans the list of hosts and checks if the id exsits
        /// </summary>
        /// <param name="HostKey"></param>
        /// <returns>return true if exsits and by reference the host</returns>
        public void UpdateHost(BE.Host theHost)
        { dal.UpdateHost(theHost); }
        bool cheakIfHostExsits(int HostKey, ref Host host)
        {
            List<Host> ListOfhosts = new List<Host>();
            ListOfhosts = getListOfHost();
            for (int i = 0; i < ListOfhosts.Count; i++)
            {
                if (ListOfhosts[i].HostKey == HostKey)
                {
                    host = ListOfhosts[i];
                    return true;
                }
            }
            return false;
        }
        /// <summary>
        /// receives the info of the  new Host
        /// </summary>
        /// <returns></returns>
        public void NewHost(Host host)
        {
            
            dal.AddNewHost(host);


        }
        /// <summary>
        /// the func check if the host we want to delete have any bookes hosting unit .
        /// first we make a list of all the booked hosting unit 
        /// second we chack if one of them belong to the host we want to delete.
        /// </summary>
        /// <param name="TheHost"></param>
        public void DeleteHost(BE.Host TheHost)
        {
            try
            {
                List<BE.HostingUnit> bookedHostingUint = dal.getListOfHostingUnits()
               .FindAll(delegate (HostingUnit hostingUnit) { return !CheakDatesAreFree(hostingUnit, DateTime.Now, DateTime.Now.AddMonths(11)); });

                if (bookedHostingUint.Any(delegate (HostingUnit HostingUnit) { return HostingUnit.Owner.HostKey == TheHost.HostKey; }))
                    throw new GenralException("Host", "the host have a booked hostingunit");
                else
                    dal.DeleteHost(TheHost);


            }
            catch (GenralException E)
            { throw E; }

        }

       public  IEnumerable<HostingUnit> getListOfHostingUnitsByOwnerKey(int OwnerKey)
        {
            IEnumerable<HostingUnit> hostingUnitsOfOwner = getListOfHostingUnits().FindAll(item => item.Owner.HostKey== OwnerKey);
            if (!hostingUnitsOfOwner.Any())
                throw new GenralException("host", "אין יחידות אירוח למארח זה.");
            return hostingUnitsOfOwner;
        }
        public IEnumerable<Order> getListOfOrdersByOwnerKey(int OwnerKey)

        {
            IEnumerable<Order> OrderOfOwner = getListOfOrder().FindAll(item => SearchForHostinUnitByKey((item.HostingUnitKey)).Owner.HostKey== OwnerKey);
            if (!OrderOfOwner.Any())
                throw new GenralException("host", " this host dose not have any order");
            return OrderOfOwner;
        }
        #endregion Host

        #region Order
        public void NewOrder(GuestRequest guestRequest, HostingUnit hostingUnit)
        {

            {
                Order order = new Order();
                order.CreateDate = DateTime.Now;
                order.OrderKey = BE.Configuration.getNewOrderKey();
                order.GuestRequestKey = guestRequest.GuestRequestKey;
                order.HostingUnitKey = hostingUnit.HostingUnitKey;
                order.Status = (Status)0;
                dal.NewOrder(order);
                

            }
          //  else throw new GenralException("Order", "ERROR in creating order.");
        }

        public void UpdateOrder(GuestRequest guestRequest, HostingUnit hostingUnit, int orderKey)
        {
            try
            {
                Order order = new Order();
                var orignalOrder = dal.getListOfOrder().Where(x => x.OrderKey == orderKey);
                order = orignalOrder.First();
                if (orignalOrder.Count() == 0)
                    throw new MissingIdException("Order", orderKey, "Can not update order dos not exsit");
                order.GuestRequestKey = guestRequest.GuestRequestKey;
                order.HostingUnitKey = hostingUnit.HostingUnitKey;
                order.Status = (Status)0;
                dal.UpdateDateOrder(order);
                sendEmailIfHasClearance(order);
            }
            catch
            {
                throw;
            }
        }

        public void DeleteOrder(BE.Order TheOrder)
        {
            //send email to the guest"
            dal.Deleteorder(TheOrder);
         
        }

        /// <summary>
        /// given a specific order returns the Guest requset 
        /// </summary>
        /// <param name="order"></param>
        /// <returns></returns>
        public GuestRequest GetGuestRequestFromOrder(Order order)
        {
            
            
                return SearchGetGuestRequestByKey(order.GuestRequestKey);
        }
        /// <summary>
        /// serches the guest requests by key
        /// </summary>
        /// <param name="Key"></param>
        /// <returns></returns>
        public GuestRequest SearchGetGuestRequestByKey(int Key)
        {

            var guestRequest = dal.getListOfGuestRequest().Find(x => x.GuestRequestKey == Key);

            if (guestRequest == null)
                throw new MissingIdException("GuestRequest", Key, "guest request key wrong.");
            return guestRequest;
        }
        /// <summary>
        /// given a specific order returns the HostingUnit
        /// </summary>
        /// <param name="order"></param>
        /// <returns></returns>

        public HostingUnit GetHostingUnitFromOrder(Order order)
        {
            var HostingUnit = dal.getListOfHostingUnits().Find(x => x.HostingUnitKey == order.HostingUnitKey);
            if (HostingUnit == null)
                throw new MissingIdException("HostingUnit", order.HostingUnitKey, "The Hosting Unit dos not exsit");
            return HostingUnit;
        }



        /// <summary>
        /// given a specific order returns the Host
        /// </summary>
        /// <param name="order"></param>
        /// <returns></returns>
        public Host GetHostFromOrder(Order order)
        {
            var Host = dal.getListOfHost().Find(x => x.HostKey == GetHostingUnitFromOrder(order).Owner.HostKey);
            if (Host == null)
                throw new MissingIdException("Host", GetHostingUnitFromOrder(order).Owner.HostKey, "The order dos not exsit");
            return Host;
        }

        public Host SearchForHostByKey(int  Key)
        {
            var Host = dal.getListOfHost().Find(x => x.HostKey == Key);
            if (Host == null)
                throw new MissingIdException("Host", Key, "The host dose not exsit");         
            return Host;
        }


        /// <summary>
        /// update order status 
        /// if closed can not update
        /// when changed to closed returns the Commission
        /// if changed to anthor status returns -1
        /// </summary>
        /// <param name="order"></param>
        /// <param name="newStatus"></param>
        /// <returns></returns>
        public double updateStatusOfOrder(Order order, int newStatus)
        {
            if (order.Status == (Status)2)
                throw new GenralException("Order", "Order closed,can not change Status.");
            else
            {

                order.Status = (Status)newStatus;                
                if (order.Status == (Status)2)
                {                                      
                    BookDates(order);
                    GetGuestRequestFromOrder(order).Status = (orderStatus)2;

                    updateAllOrdersStatus(order);
                    dal.UpdateDateOrder(order);
                    return calcCommission(order);
                }
                dal.UpdateDateOrder(order);
                return -1;
            }

        }

        /// <summary>
        /// after booking a order updates all the other orders with
        /// the same guest request key to Finshed not booked
        /// </summary>
        /// <param name="order"></param>
        public void updateAllOrdersStatus(Order order)
        {


            IEnumerable<Order> RelatedOrders = getListOfOrder().Where(item => item.GuestRequestKey == order.GuestRequestKey);
            foreach (var item in RelatedOrders)
                item.Status = (Status)1;

            order.Status = (Status)2;

        }

        /// <summary>
        /// gerts a order and calculates the Commission 
        /// </summary>
        /// <param name="order"></param>
        /// <returns>Commission</returns>
        public double calcCommission(Order order)
        {
            double Commission = 0;
            var guestRequest = dal.getListOfGuestRequest().Find(x => x.GuestRequestKey == order.GuestRequestKey);
            DateTime tempDate = guestRequest.EntryDate;
            while (tempDate < guestRequest.EndDate)
            {
                Commission += Configuration.getCommission();
                tempDate=tempDate.AddDays(1);
            }
            return Commission;
        }
        #endregion Order

        #region Guest Request
        public void NewGuestRequests(GuestRequest guestRequest)
        {
            guestRequest.Status = 0;
            guestRequest.RegistrationDate = DateTime.Today;
            
            guestRequest.NumOfBeds = guestRequest.Adults + guestRequest.Children;
            
            checkDates(guestRequest.EntryDate, guestRequest.EndDate);
            guestRequest.GuestRequestKey = BE.Configuration.getNewGuestRequestKey();
            dal.NewGuestRequests(guestRequest);

            
        }
        
       

        /// <summary>
        /// 
        /// </summary>
        /// <param name="TheGuestRequest"></param>
        public void UpdateGuestRequests(GuestRequest guestRequest)
        {

               
                dal.UpdateGuestRequests(guestRequest);

           
        }


        public void DeleteGuestRequests(BE.GuestRequest TheGuestRequest)
        {
            try
            {
                List<BE.Order> problomaticOrderS = dal.getListOfOrder().FindAll(delegate (Order order) { return order.GuestRequestKey == TheGuestRequest.GuestRequestKey; });
                if (problomaticOrderS.Count > 0)
                {

                    throw new keyBeenBooked("hostingUint", TheGuestRequest.GuestRequestKey, problomaticOrderS," מס ההזמנה הוזמן כבר");
                }
                else
                    dal.DeleteGuestRequests(TheGuestRequest);
            }
            catch (keyBeenBooked E)
            {
                foreach (Order item in E.list)
                    Console.WriteLine("The GuestRequest has been choose in order num :" + item.OrderKey + "in status: " + item.Status);
                throw E;
            }
        }
        #endregion Guest Request

        #region EMAIL
        /// <summary>
        /// cheks if the host has Collection Clearance and  if it dos sends a Email to guest
        /// </summary>
        /// <param name="host"></param>
        /// <param name="guestRequest"></param>
        public void sendEmailIfHasClearance(Order order)
        {
                if (GetHostFromOrder(order).CollectionClearance)
                {
                    GetGuestRequestFromOrder(order).Status = (orderStatus)1;
                    sendEmail(order);
                }
                else
                    throw new MisinigClearanceException("BL_imp", "Misinig Collection Clearance,to contact custumer aprove Clearance. ");

            //destict choose only one from the list if aperes more then ones..
        }
        /// <summary>
        /// send email to the costumor by the host and change the date 
        /// </summary>
        /// <param name="currrentOrder"></param>

        public void sendEmail(Order currrentOrder)
        {
           // יצירת אובייקט MailMessage
            MailMessage mail = new MailMessage();

            //כתובת הנמען)ניתן להוסיף יותר מאחד( //
             mail.To.Add(SearchGetGuestRequestByKey(currrentOrder.GuestRequestKey).MailAddress);
           // הכתובת ממנה נשלח המייל //
             mail.From = new MailAddress(Configuration.SystemEmail);
             mail.Subject = "VACTION!";
             mail.Body = "You are now one step away from your dream vaction . pleas contact:" +(GetHostFromOrder ( currrentOrder)).MailAddress+ "to confirm. ";
              mail.IsBodyHtml = true;

            SmtpClient smtp = new SmtpClient();
            smtp.Port = 587;
            smtp.Host = "smtp.gmail.com"; //for gmail host  
            smtp.EnableSsl = true;
           // smtp.UseDefaultCredentials = false;
            smtp.Credentials = new System.Net.NetworkCredential(Configuration.SystemEmail,
             Configuration.SystemEmailPassward);
            smtp.DeliveryMethod = SmtpDeliveryMethod.Network;
            smtp.Send(mail);

            Console.WriteLine("email has been sent to order num  " + currrentOrder.OrderKey + "aboute request num :" + currrentOrder.GuestRequestKey);
            currrentOrder.contactCustumerDate = DateTime.Today;
     
    }
        public void sendEmailToCancell(string email)
        {
            // יצירת אובייקט MailMessage
            MailMessage mail = new MailMessage();

            //כתובת הנמען)ניתן להוסיף יותר מאחד( //
            mail.To.Add(email);
            // הכתובת ממנה נשלח המייל //
            mail.From = new MailAddress(Configuration.SystemEmail);
            mail.Subject = "VACTION!";
            mail.Body = "Youre vaction has been canceld for more information .please contact host to confirm. ";
            mail.IsBodyHtml = true;

            SmtpClient smtp = new SmtpClient();
            smtp.Port = 587;
            smtp.Host = "smtp.gmail.com"; //for gmail host  
            smtp.EnableSsl = true;
            // smtp.UseDefaultCredentials = false;
            smtp.Credentials = new System.Net.NetworkCredential(Configuration.SystemEmail,
             Configuration.SystemEmailPassward);
            smtp.DeliveryMethod = SmtpDeliveryMethod.Network;
            smtp.Send(mail);
        
        }

        
        # endregion EMAIL
      
        #region Grouping
        /// <summary>
        /// create a list of hosting units by area
        /// </summary>
        /// <returns>list by area</returns>
        public IEnumerable<IGrouping<Area, HostingUnit>> ListOfHostingUntisInArea()
        {
            List<BE.HostingUnit> hostingUnits = dal.getListOfHostingUnits();
            var AraeGroups = from unit in hostingUnits
                        
                             group unit by unit.Area into groupArea
                             orderby groupArea.Key
                             select groupArea;

            return AraeGroups;
            
            }
        /// <summary>
        /// create a list of guest request by number of beds
        /// </summary>
        /// <returns>list by number of beds</returns>
        public IEnumerable<IGrouping<int, GuestRequest>> ListOfGustRequestByNumOfBeds()
        {
            List<BE.GuestRequest> guestRequests = dal.getListOfGuestRequest();
            var NumGroups = from unit in guestRequests
                            group unit by unit.NumOfBeds into groupNum
                            orderby groupNum.Key
                            select groupNum;
            return NumGroups;
            
        }    
        public IEnumerable<IGrouping<Area, GuestRequest>> ListOfguestRequestsByArea()
        {
            List<BE.GuestRequest> guestRequests = dal.getListOfGuestRequest();
            var AreaGroups = from unit in guestRequests
                             group unit by unit.Area into groupArea
                             orderby groupArea.Key
                            
                             select groupArea;
            return AreaGroups;

        }

        /// <summary>
        /// create a list of Hosts by number of units they own form highest to lowest
        /// </summary>
        /// <returns>list by number of units they own</returns>
        public IEnumerable<IGrouping<int, Host>> ListOfHostsByNumberOfHostingUnits()
        {
            List<BE.Host> hosts = dal.getListOfHost();
            var unitsGroups = from unit in hosts
                              
                              group unit by unit.numberOfUints into groupunits
                              orderby groupunits.Key descending
                              select groupunits;
            return unitsGroups;

        }
        #endregion Grouping

        #region Date

        /// <summary>
        /// resets the dates a month back evrey time the program is activted
        /// </summary>
        public void deleteDatesMonthBack()
        {
            
            foreach(var hostingUnit in getListOfHostingUnits())
            {
                DateTime temp = DateTime.Now.AddMonths(-1);
                while(temp<DateTime.Now)
                {
                    hostingUnit[temp] = false;
                    temp = temp.AddDays(1);
                }
            }

        }


        /// <summary>
        /// gets order and books the dates
        /// </summary>
        /// <param name="order"></param>
        public void BookDates(Order order)
        {
            try
            {
                CheakDatesAreFree(GetHostingUnitFromOrder(order), GetGuestRequestFromOrder(order).EntryDate, GetGuestRequestFromOrder(order).EndDate);
                HostingUnit hostingUnit = GetHostingUnitFromOrder(order);
                DateTime temp = GetGuestRequestFromOrder(order).EntryDate;
                while (temp < GetGuestRequestFromOrder(order).EndDate)
                {

                    hostingUnit[temp] = true;

                    temp = temp.AddDays(1);

                }

                dal.UpdateHostingUnit(hostingUnit);
            }
            catch { throw; }
        }

        /// <summary>
        /// cheks if the starting date is before the end date by one day at least
        /// </summary>
        /// <param name="StartDate"></param>
        /// <param name="EndtDate"></param>
        /// <returns></returns>
        public bool CheakDateIfInOrder(DateTime StartDate, DateTime EndtDate)
        {

            if ((StartDate < EndtDate))
                if (!(StartDate >= DateTime.Now))
                    throw new DateException("Date", "pleas enter start date after today.");
                   else
                     return true;
            throw new DateException("Date", "pleas enter start date before end date.");
        }
       

        /// <summary>
        /// cheks if dates are free  on the range given
        /// </summary>
        /// <param name="StartDate"></param>
        /// <param name="EndtDate"></param>
        /// <returns></returns>
        public bool CheakDatesAreFree(HostingUnit hostingUnit, DateTime StartDate, DateTime EndtDate)//לסיים את הפונקציה
        {

            if (checkDates(StartDate, EndtDate))

                while (StartDate < EndtDate)
                {

                    if (hostingUnit[StartDate]==true)
                        throw new Exception("the dates are not avidable");
                    StartDate = StartDate.AddDays(1);


                }
            return true;

        }

        /// <summary>
        /// checks if the dats are in the range of 11 months from now
        /// </summary>
        /// <param name="StartDate"></param>
        /// <param name="EndtDate"></param>
        /// <returns></returns>
        public bool checkIfDatesAreInRange(DateTime StartDate, DateTime EndtDate)
        {
            DateTime Now = DateTime.Now;
            if (Now.AddMonths(11) < EndtDate)
                throw new DateException("Date", "Can only order 11 months ahead.");
            return true;
        }

        /// <summary>
        /// calls functions that check the range and order of the dates
        /// </summary>
        /// <param name="StartDate"></param>
        /// <param name="EndtDate"></param>
        /// <returns></returns>
        public bool checkDates(DateTime StartDate, DateTime EndtDate)
        {
                if (checkIfDatesAreInRange(StartDate, EndtDate) && CheakDateIfInOrder(StartDate, EndtDate))
                    return true;
                return false;
            
         
        }

        #endregion Date
        public void GetBankXml() { dal.GetBankXml(); }
    }
}



    
       
        

        



