using System;
using System.Collections.Generic;
using System.Text;
using BE;
using DAL;
using System.Linq;


namespace BL
{
    try
    {
        class BL_imp : IBL
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
                Choice AirConditioner, Choice ChildrensAttractions, ResortType Type, Choice Hikes, bool[][] Diary, int KeyOfHost)
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
            }

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

            #region NotImplemented


            public void NewGuestRequests(GuestRequest TheGuestRequest)
            {
                throw new NotImplementedException();
            }

            /// <summary>
            /// creats a new order and calls func to cotact the custumer if the host has Clearance
            /// </summary>
            /// <param name="guestRequest"></param>
            /// <param name="hostingUnit"></param>
            public void NewOrder(GuestRequest guestRequest, HostingUnit hostingUnit)
            {
                if (CheakDatesAreFree(hostingUnit, guestRequest.EntryDate, guestRequest.EndDate))

                {
                    Order order = new Order();
                    order.OrderDate = DateTime.Now;
                    order.OrderKey = BE.Configuration.getNewOrderKey();
                    order.GuestRequestKey = guestRequest.GuestRequestKey;
                    order.HostingUnitKey = hostingUnit.HostingUnitKey;
                    order.Status = (Status)0;
                    dal.NewOrder(order);
                    sendEmailIfHasClearance(hostingUnit.Owner, guestRequest);

                }
                else throw new GenralException("BL_imp", "ERROR in creating order.");
            }

            public void UpdateDateOrder(Order TheOrder)
            {
                throw new NotImplementedException();
            }

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
            public IEnumerable<IGrouping<Area, GuestRequest>> ListOfGustRequestByArea()
            {
                List<BE.GuestRequest> guestRequests = dal.getListOfGuestRequest();
                var AreaGroups = from unit in guestRequests
                                 orderby unit.getArea()
                                 group unit by unit.getArea() into groupArea
                                 select groupArea;
                return AreaGroups;

            }


            /// <summary>
            /// create a list of Gust Requests by area
            /// </summary>
            /// <returns>list by area</returns>
            public IEnumerable<IGrouping<Area, GuestRequest>> ListOfHostsByArea()
            {
                List<BE.GuestRequest> guestRequests = dal.getListOfGuestRequest();
                var AreaGroups = from unit in guestRequests
                                 orderby unit.getArea()
                                 group unit by unit.getArea() into groupArea
                                 select groupArea;
                return AreaGroups;

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
            //לבדוק איזה פונקציות חוזרות על עצמן בגרופ

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
            /// <summary>
            /// cheks if the host has Collection Clearance and  if it dos sends a Email to guest
            /// </summary>
            /// <param name="host"></param>
            /// <param name="guestRequest"></param>
            void sendEmailIfHasClearance(Host host, GuestRequest guestRequest)
            {
                if (host.CollectionClearance)
                    guestRequest.Status = (orderStatus)1;
                else
                    throw new MisinigClearanceException("BL_imp", "Misinig Collection Clearance,to contact custumer aprove Clearance. ");


            }
            //לבדוק מה השגיאות בדוק מדוד

            /// <summary>
            /// send email to the costumor by the host and change the date 
            /// </summary>
            /// <param name="currrentOrder"></param>
            public void sendEmail(Order currrentOrder)
            {
                Console.WriteLine("email have been with order num  " + currrentOrder.OrderKey + "aboute request num :" + currrentOrder.getGuestRequestKey());
                currrentOrder.OrderDate = DateTime.Now;
                //לזמן מהפונ שמשנה סטטוס מייל
            }
            /// <summary>
            /// check if the hostingunit that we want to delete  has been booked in a order before 
            /// if yes send exepction if not use the delete func from dal
            /// </summary>
            /// <param name="TheHostingUnit"></param>
            public void DeleteHostingUnit(HostingUnit TheHostingUnit)
            {

                List<BE.Order> problomaticOrderS = dal.getListOfOrder().FindAll(delegate (Order order) { return order.HostingUnitKey == TheHostingUnit.HostingUnitKey; });
                if (problomaticOrderS.Count > 0)
                {
                    foreach (Order item in problomaticOrderS)
                        Console.WriteLine("the hosting unit has been book in order num :" + item.OrderKey);
                    throw new keyBeenBooked("hostingUint", TheHostingUnit.HostingUnitKey, problomaticOrderS.Count);
                }
                else
                    dal.DeleteHostingUnit(TheHostingUnit);
            }
            public void DeleteGuestRequests(BE.GuestRequest TheGuestRequest)
            {
                List<BE.Order> problomaticOrderS = dal.getListOfOrder().FindAll(delegate (Order order) { return order.HostingUnitKey == TheGuestRequest.GuestRequestKey; });
                if (problomaticOrderS.Count > 0)
                {
                    foreach (Order item in problomaticOrderS)
                        Console.WriteLine("The GuestRequest has been choose in order num :" + item.OrderKey);
                    throw new keyBeenBooked("hostingUint", TheGuestRequest.GuestRequestKey, problomaticOrderS.Count);
                }
                else
                    dal.DeleteGuestRequests(TheGuestRequest);
            }
            public void Deleteorder(BE.Order TheOrder)
            {
                Console.WriteLine("send email to the host and cosmumer of the order");
                dal.Deleteorder(TheOrder);
            }
            /// <summary>
            /// the func check if the host we want to delete have any bookes hosting unit .
            /// first we make a list of all the booked hosting unit 
            /// second we chack if one of them belong to the host we want to delete.
            /// </summary>
            /// <param name="TheHost"></param>
            public void DeleteHost(BE.Host TheHost)
            {
                List<BE.HostingUnit> bookedHostingUint = dal.getListOfHostingUnits()
               .FindAll(delegate (HostingUnit hostingUnit) { return checkIfHostingUnitBooked(hostingUnit, DateTime.Now, DateTime.Now.AddMonths(11)); });

                if (bookedHostingUint.Any(delegate (HostingUnit HostingUnit) { return HostingUnit.Owner.HostKey == TheHost.HostKey; }))
                    throw new GenralException("Host", "the host have a booked hostingunit");
            }

            bool checkIfHostingUnitBooked(HostingUnit hostingUnit, DateTime now, DateTime endOfYear)
            {
                for (int i = 0; i < 12; i++)
                {
                    for (int j = 0; j < 31; j++)
                    {
                        if (hostingUnit.Diary[i, j] == true)
                            return true;
                    }
                }
                return false;
            }

         }
     }
  catch()
    {
    
    }

}
   




