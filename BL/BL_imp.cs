using System;
using System.Collections.Generic;
using System.Text;
using BE;
using DAL;
using System.Linq;


namespace BL
{
    public class BL_imp : IBL
    {

        
        IDAL dal = FactoryDal.GetDal();

        #region lists      

        public List<BankBranch> getListOfBankBranch()
        {
            return dal.getListOfBankBranch();
            throw new NotImplementedException();
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
        public void AddNewHostingUnit(string HostingUnitName, int NumOfRooms,
            int NumOfBeds, Choice pool, Choice Jacuzzi, Area Area, Choice Garden,
            Choice AirConditioner, Choice ChildrensAttractions, ResortType Type, Choice Hikes,  int KeyOfHost)
        {

            Host host = new Host();


            if (cheakIfHostExsits(KeyOfHost, ref host))//need enter the host key.
            {
                HostingUnit EnterdHostingUnit = new HostingUnit();
                EnterdHostingUnit.setHostingUnitName(HostingUnitName);
                EnterdHostingUnit.setNumOfRooms(NumOfRooms);
                EnterdHostingUnit.setNumOfBeds(NumOfBeds);
                EnterdHostingUnit.setPool(pool);
                EnterdHostingUnit.setJacuzzi(Jacuzzi);
                EnterdHostingUnit.setArea(Area);
                EnterdHostingUnit.setGarden(Garden);
                EnterdHostingUnit.setAirConditioner(AirConditioner);
                EnterdHostingUnit.setChildrensAttractions(ChildrensAttractions);
                EnterdHostingUnit.setType(Type);
                EnterdHostingUnit.setHikes(Hikes);
                EnterdHostingUnit.setOwner(host);
                dal.AddNewHostingUnit(EnterdHostingUnit);
            }
            else
                throw new MissingIdException("BL_imp", KeyOfHost, "אנא וודא תקינות מספר זיהוי או הוסף את פרטיך לרשימת המארחים");
        

        /// <summary>
        /// check if the hostingunit that we want to delete  has been booked in a order before 
        /// if yes send exepction if not use the delete func from dal
        /// </summary>
        /// <param name="TheHostingUnit"></param>
         void DeleteHostingUnit(HostingUnit TheHostingUnit)
        {
            try
            {
                List<BE.Order> problomaticOrderS = dal.getListOfOrder().FindAll(delegate (Order order) { return order.HostingUnitKey == TheHostingUnit.HostingUnitKey; });
                if (problomaticOrderS.Count > 0)
                {
                    foreach (Order item in problomaticOrderS)
                        if (item.Status == (Status)2)
                            if (GetGuestRequestFromOrder(item).EntryDate > DateTime.Now)
                                throw new keyBeenBooked("hostingUint", TheHostingUnit.HostingUnitKey, problomaticOrderS);
                }
                else
                    dal.DeleteHostingUnit(TheHostingUnit);
            }
            catch (keyBeenBooked e)
            {
                throw e;
            }
        }

        #endregion Hosting unit

        #region Host
        /// <summary>
        /// the function scans the list of hosts and checks if the id exsits
        /// </summary>
        /// <param name="HostKey"></param>
        /// <returns>return true if exsits and by reference the host</returns>
        bool cheakIfHostExsits(int HostKey, ref Host host)
        {
            List<Host> ListOfhosts = new List<Host>();
            ListOfhosts = getListOfHost();
            for (int i = 0; i < ListOfhosts.Count; i++)
            {
                if (ListOfhosts[i].getHostKey() == HostKey)
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
        public Host NewHost(int HostKey, string PrivateName,
                            string FamilyName, string PhoneNumber,
                            string MailAddress, BankAccount HostBankAccuont)
        {
            Host EnterdHost = new Host();
            EnterdHost.setHostKey(BE.Configuration.getNewHostKey());
            EnterdHost.setPrivateName(PrivateName);
            EnterdHost.setFamilyName(FamilyName);
            EnterdHost.setPhoneNumber(PhoneNumber);
            EnterdHost.setMailAddress(MailAddress);

            return EnterdHost;

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
            }
            catch (GenralException E)
            { throw E; }

        }
        #endregion Host

        #region Order
        public void NewOrder(GuestRequest guestRequest, HostingUnit hostingUnit)
        {
            if (CheakDatesAreFree(hostingUnit, guestRequest.EntryDate, guestRequest.EndDate))

            {
                Order order = new Order();
                order.CreateDate = DateTime.Now;
                order.OrderKey = BE.Configuration.getNewOrderKey();
                order.GuestRequestKey = guestRequest.GuestRequestKey;
                order.HostingUnitKey = hostingUnit.HostingUnitKey;
                order.Status = (Status)0;
                dal.NewOrder(order);
                sendEmailIfHasClearance(order);

            }
            else throw new GenralException("BL_imp", "ERROR in creating order.");
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
            Console.WriteLine("send email to the host and cosmumer of the order");
            dal.Deleteorder(TheOrder);
        }

        /// <summary>
        /// given a specific order returns the Guest requset 
        /// </summary>
        /// <param name="order"></param>
        /// <returns></returns>
        public GuestRequest GetGuestRequestFromOrder(Order order)
        {
            var guestRequest = dal.getListOfGuestRequest().Where(x => x.GuestRequestKey == order.GuestRequestKey);
            return guestRequest.First();
        }
        /// <summary>
        /// given a specific order returns the HostingUnit
        /// </summary>
        /// <param name="order"></param>
        /// <returns></returns>

        public HostingUnit GetHostingUnitFromOrder(Order order)
        {
            var HostingUnit = dal.getListOfHostingUnits().Where(x => x.HostingUnitKey == order.HostingUnitKey);
            return HostingUnit.First();
        }

        /// <summary>
        /// given a specific order returns the Host
        /// </summary>
        /// <param name="order"></param>
        /// <returns></returns>
        public Host GetHostFromOrder(Order order)
        {
            var Host = dal.getListOfHost().Where(x => x.HostKey == GetHostingUnitFromOrder(order).Owner.HostKey);
            return Host.First();
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
                    updateAllOrdersStatus(order);

                    return calcCommission(order);
                }

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
            var guestRequest = dal.getListOfGuestRequest().Where(x => x.GuestRequestKey == order.GuestRequestKey);
            DateTime tempDate = guestRequest.FirstOrDefault().EntryDate;
            while (tempDate < guestRequest.FirstOrDefault().EndDate)
            {
                Commission += Configuration.getCommission();
                tempDate.AddDays(1);
            }
            return Commission;
        }
        #endregion Order

        #region Guest Request


        /// <summary>
        /// 
        /// </summary>
        /// <param name="PrivateName"></param>
        /// <param name="FamilyName"></param>
        /// <param name="MailAddress"></param>
        /// <param name="Status"></param>
        /// <param name="RegistrationDate"></param>
        /// <param name="EntryDate"></param>
        /// <param name="EndDate"></param>
        /// <param name="Area"></param>
        /// <param name="NumOfRooms"></param>
        /// <param name="Type"></param>
        /// <param name="Adults"></param>
        /// <param name="Children"></param>
        /// <param name="NumOfBeds"></param>
        /// <param name="Pool"></param>
        /// <param name="Jacuzzi"></param>
        /// <param name="Garden"></param>
        /// <param name="ChildrensAttractions"></param>
        /// <param name="AirConditioner"></param>
        /// <param name="Hikes"></param>
        public void NewGuestRequests(string PrivateName
        , string FamilyName, string MailAddress, orderStatus Status,
            DateTime RegistrationDate, DateTime EntryDate,
            DateTime EndDate, Area Area, int NumOfRooms, ResortType Type,
            int Adults, int Children, int NumOfBeds, Choice Pool, Choice Jacuzzi,
            Choice Garden, Choice ChildrensAttractions, Choice AirConditioner
            , Choice Hikes)
        {
            GuestRequest guestRequest = new GuestRequest();
            guestRequest.GuestRequestKey = Configuration.getNewGuestRequestKey();
            guestRequest.PrivateName = PrivateName;
            guestRequest.FamilyName = FamilyName;
            guestRequest.MailAddress = MailAddress;
            guestRequest.Status = Status;
            guestRequest.RegistrationDate = DateTime.Now;
            guestRequest.EntryDate = EntryDate;
            guestRequest.EndDate = EndDate;
            guestRequest.Area = Area;
            guestRequest.NumOfRooms = NumOfRooms;
            guestRequest.Pool = Pool;
            guestRequest.Jacuzzi = Jacuzzi;
            guestRequest.Garden = Garden;
            guestRequest.ChildrensAttractions = ChildrensAttractions;
            guestRequest.AirConditioner = AirConditioner;
            guestRequest.Hikes = Hikes;
            dal.NewGuestRequests(guestRequest);

        }

        public void DeleteGuestRequests(BE.GuestRequest TheGuestRequest)
        {
            try
            {
                List<BE.Order> problomaticOrderS = dal.getListOfOrder().FindAll(delegate (Order order) { return order.HostingUnitKey == TheGuestRequest.GuestRequestKey; });
                if (problomaticOrderS.Count > 0)
                {

                    throw new keyBeenBooked("hostingUint", TheGuestRequest.GuestRequestKey, problomaticOrderS);
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
        /// <summary>
        /// cheks if the host has Collection Clearance and  if it dos sends a Email to guest
        /// </summary>
        /// <param name="host"></param>
        /// <param name="guestRequest"></param>
        void sendEmailIfHasClearance(Order order)
        {
            if (GetHostFromOrder(order).CollectionClearance)
            {
                GetGuestRequestFromOrder(order).Status = (orderStatus)1;
                sendEmail(order);
            }
            else
                throw new MisinigClearanceException("BL_imp", "Misinig Collection Clearance,to contact custumer aprove Clearance. ");


        }
        /// <summary>
        /// send email to the costumor by the host and change the date 
        /// </summary>
        /// <param name="currrentOrder"></param>
        public void sendEmail(Order currrentOrder)
        {
            Console.WriteLine("email have been with order num  " + currrentOrder.OrderKey + "aboute request num :" + currrentOrder.getGuestRequestKey());
            currrentOrder.contactCustumerDate = DateTime.Now;
        }
        #endregion Guest Request

        #region NotImplemented

        public void UpdateGuestRequests(GuestRequest TheGuestRequest)
        {
            throw new NotImplementedException();
        }

        public void UpdateHostingUnit(HostingUnit TheHostingUnit)
        {
            dal.getListOfHostingUnits();

            throw new NotImplementedException();
        }

        #endregion NotImplemented

        #region Grouping
        /// <summary>
        /// create a list of hosting units by area
        /// </summary>
        /// <returns>list by area</returns>
        public IEnumerable<IGrouping<Area, HostingUnit>> ListOfHostingUntisInArea()
        {
            List<BE.HostingUnit> hostingUnits = dal.getListOfHostingUnits();
            var AraeGroups = from unit in hostingUnits
                             orderby unit.Area
                             group unit by unit.Area into groupArea
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
                            orderby unit.getNumOfBeds()
                            group unit by unit.getNumOfBeds() into groupNum
                            select groupNum;
            return NumGroups;

        }

        /// <summary>
        /// create a list of Gust Requests by area
        /// </summary>
        /// <returns>list by area</returns>
        public IEnumerable<IGrouping<Area, GuestRequest>> ListOfguestRequestsByArea()
        {
            List<BE.GuestRequest> guestRequests = dal.getListOfGuestRequest();
            var AreaGroups = from unit in guestRequests
                             orderby unit.getArea(), unit.getFamliyName()
                             group unit by unit.getArea() into groupArea
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
                              orderby unit.numberOfUints descending
                              group unit by unit.numberOfUints into groupunits
                              select groupunits;
            return unitsGroups;

        }
        #endregion Grouping

        #region Date

        /// <summary>
        /// gets order and books the dates
        /// </summary>
        /// <param name="order"></param>
        public void BookDates(Order order)
        {
            HostingUnit hostingUnit = GetHostingUnitFromOrder(order);
            DateTime temp= GetGuestRequestFromOrder(order).EntryDate;
            while (temp < GetGuestRequestFromOrder(order).EndDate)
            {

                hostingUnit[temp] = true;

                temp = temp.AddDays(1);

            }

        }

        /// <summary>
        /// cheks if the starting date is before the end date by one day at least
        /// </summary>
        /// <param name="StartDate"></param>
        /// <param name="EndtDate"></param>
        /// <returns></returns>
        public bool CheakDateIfInOrder(DateTime StartDate, DateTime EndtDate)
        {
            if (StartDate < EndtDate) ;
            return true;
            throw new DateException("BL_imp", "אנא הזן תאריך התחלה לפחות יום אחד לפני תאיך הסיום.");
        }

        /// <summary>
        /// cheks if dates are free  on the range given
        /// </summary>
        /// <param name="StartDate"></param>
        /// <param name="EndtDate"></param>
        /// <returns></returns>
        public bool CheakDatesAreFree(HostingUnit hostingUnit, DateTime StartDate, DateTime EndtDate)//לסיים את הפונקציה
        {

            if (chekDates(StartDate, EndtDate))

                while (StartDate < EndtDate)
                {


                    if (hostingUnit[StartDate])
                        return false;
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
                throw new DateException("BL_imp", " אפשר להזמין עד 11 חודשים קדימה.");
            return true;
        }

        /// <summary>
        /// calls functions that check the range and order of the dates
        /// </summary>
        /// <param name="StartDate"></param>
        /// <param name="EndtDate"></param>
        /// <returns></returns>
        public bool chekDates(DateTime StartDate, DateTime EndtDate)
        {
            if (checkIfDatesAreInRange(StartDate, EndtDate) && CheakDateIfInOrder(StartDate, EndtDate))
                return true;
            return false;
        }

        #endregion Date
    }
}



    
       
        

        



