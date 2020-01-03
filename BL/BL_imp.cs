using System;
using System.Collections.Generic;
using System.Text;
using BE;
using DAL;
using System.Linq;


namespace BL
{
    class BL_imp : IBL
    {
      
        IDAL dal = FactoryDal.GetDal();
       
    
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
        public void AddNewHostingUnit( string HostingUnitName, int NumOfRooms,
            int NumOfBeds, Choice pool, Choice Jacuzzi, Area Area, Choice Garden,
            Choice AirConditioner, Choice ChildrensAttractions, ResortType Type, Choice Hikes, bool[][] Diary,int KeyOfHost)
        {

            Host host = new Host();


            if (cheakIfHostExsits(KeyOfHost,ref host))//need enter the host key.
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
            throw new  MissingIdException ("BL_imp", KeyOfHost, "אנא וודא תקינות מספר זיהוי או הוסף את פרטיך לרשימת המארחים");
        }

        /// <summary>
        /// the function scans the list of hosts and checks if the id exsits
        /// </summary>
        /// <param name="HostKey"></param>
        /// <returns>return true if exsits and by reference the host</returns>
        bool cheakIfHostExsits(int HostKey, ref Host host)
        {
            List<Host> ListOfhosts = new List<Host>();
            ListOfhosts = getListOfHost();//צריך להגדיר את הפונקציה להחזרת רשימה של
                for(int i=0;i<ListOfhosts.Count;i++)
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
        public Host NewHost(int HostKey, string PrivateName ,
                            string FamilyName ,string PhoneNumber ,
                            string MailAddress,BankAccount HostBankAccuont)
        {
            Host EnterdHost = new Host();
            EnterdHost.setHostKey(BE.Configuration.getNewHostKey());
            EnterdHost.setPrivateName(PrivateName);
            EnterdHost.setFamilyName(FamilyName);
            EnterdHost.setPhoneNumber(PhoneNumber);
            EnterdHost.setMailAddress(MailAddress);

            return EnterdHost;

        }



        public void DeleteHostingUnit(HostingUnit TheHostingUnit)
        {
            throw new NotImplementedException();
        }


        public void NewGuestRequests(GuestRequest TheGuestRequest)
        {
            throw new NotImplementedException();
        }

        public void NewOrder(Order TheOrder)
        {
            throw new NotImplementedException();
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

    }
    /// <summary>
    /// create a list of guest request by number of Area
    /// </summary>
    /// <returns>list by number of beds</returns>
   

    //        • רשימת דרישות לקוח מקובצת )Grouping )ע"פ אזור הנופש הנדרש.
    //• רשימת דרישות לקוח מקובצת )Grouping )ע"פ מספר הנופשים.
    //• רשימת מארחים מקובצת )Grouping )ע"פ מספר יחידות האירוח שהם מחזיקים
    //• רשימת יחידות אירוח מקובצת )Grouping )ע"פ אזור הנופש הנדרש.

    public bool CheakDateIfOk(DateTime StartDate, DateTime EndtDate) 
        {
            return (StartDate < EndtDate);
        }


      
    }
}


