using System;

namespace BE
{
    public class GuestRequest
    {
        public int GuestRequestKey;

        public int getGuestRequestKey() { return GuestRequestKey; }
        //
        public string PrivateName { get; set; }
        public string FamilyName { get; set; }
        public string getPrivateName() { return PrivateName; }
        public void setPrivteName(string NewPrivateName) { PrivateName = NewPrivateName; }

        public string FamliyName { get; set; }
        public string getFamliyName() { return FamliyName; }
        public void setAdults(string NewFamliyName) { FamliyName = NewFamliyName; }

        public string MailAddress { get; set; }
        public string getMailAddress() { return MailAddress; }
        public void setMailAddress(string NewMailAddress) { MailAddress = NewMailAddress; }

        public orderStatus Status { get; set; }
        //public string getStatus() { return Status; }
        //public void setStatus(string NewStatus) { Status = NewStatus; }

        public DateTime RegistrationDate { get; set; }
        public DateTime getRegistrationDate() { return RegistrationDate; }
        public void setRegistrationDate(DateTime NewRegistrationDate) { RegistrationDate = NewRegistrationDate; }

        public DateTime EntryDate { get; set; }
        public DateTime getEntryDate() { return EntryDate; }
        public void setEntryDate(DateTime NewEntryDate) { EntryDate = NewEntryDate; }

        public DateTime EndDate { get; set; }
        public DateTime getendDate() { return EndDate; }
        public void setEndDate(DateTime NewEndDate) { EndDate = NewEndDate; }

        public Area Area;
        public Area getArea() { return Area; }
        public void setArea(Area NewArea) { Area = NewArea; }

        public int NumOfRooms;
        public int getNumOfRooms() { return NumOfRooms; }
        public void setNumOfRooms(int NewNumOfRooms) { NumOfRooms = NewNumOfRooms; }

        //Hotel Motel Tzimer
        public ResortType Type{ get; set; }
       
        public int Adults;
        public int getAdults() { return Adults; }
        public void setAdults(int NewAdults) { Adults = NewAdults; }

        public int Children;
        public int getChildren() { return Children; }
        public void setChildren(int NewChildren) { Children = NewChildren; }

        public int NumOfBeds;
        public int getNumOfBeds() { return NumOfBeds; }
        public void setNumOfBeds(int NewNumOfBeds) { NumOfBeds = NewNumOfBeds; }

        public Choice Pool{ get; set; }


    public Choice Jacuzzi { get; set; }
 
        public Choice Garden{ get; set; }

        public Choice ChildrensAttractions { get; set; }


        public Choice AirConditioner  { get; set; }
        //public string getAirConditioner() { return AirConditioner; }
        //public void setAirConditioner(string NewAirConditioner) { AirConditioner = NewAirConditioner; }

        public Choice Hikes { get; set; }
        //public string getHikes() { return Hikes; }
        //public void setHikes(string NewHikes) { Hikes = NewHikes; }


        public override string ToString() 
        {
            return "The request details:\n" +
                "Guest Request Key: "+ GuestRequestKey+"\n"+
                " Name: "+ PrivateName+" "+ FamliyName + "\n" +    
                "MailAddress: " + MailAddress + "\n" + 
                "Status: " + Status+ "\n" + " RegistrationDate: " + RegistrationDate +
                " EntryDate: "+ EntryDate + " ReleaseDate: "+ ReleaseDate+ "\n" +
                " Area: " + Area +
                " Type :" + Type+ " Adults :"+ Adults + 
                " Children :"+ Children+ "\n" +
                "Pool: " + Pool+ " Jacuzzi: "+ Jacuzzi+ 
                " Garden: "+ Garden+ " ChildrensAttractions: "+ChildrensAttractions+
                " hikes: "+ Hikes + "AirConditioner: "+ AirConditioner; 
        }
    }
}
