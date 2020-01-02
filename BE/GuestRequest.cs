using System;

namespace BE
{
    public class GuestRequest
    {
        int GuestRequestKey;
            
       public int getGuestRequestKey() { return GuestRequestKey; }
        //
        string PrivateName;
        public string getPrivateName() { return PrivateName; }
        public void setPrivteName(string NewPrivateName) { PrivateName = NewPrivateName; }

        string FamliyName;
        public string getFamliyName() { return FamliyName; }
        public void setAdults(string NewFamliyName) { FamliyName = NewFamliyName; }

        string MailAddress;
        public string getMailAddress() { return MailAddress; }
        public void setMailAddress(string NewMailAddress) { MailAddress = NewMailAddress; }
        
        string Status;
        public string getStatus() { return Status; }
        public void setStatus(string NewStatus) { Status = NewStatus; }

        DateTime RegistrationDate;
        public DateTime getRegistrationDate() { return RegistrationDate; }
        public void setRegistrationDate(DateTime NewRegistrationDate) { RegistrationDate = NewRegistrationDate; }
     
        DateTime EntryDate;
        public DateTime getEntryDate() { return EntryDate; }
        public void setEntryDate(DateTime NewEntryDate) { EntryDate = NewEntryDate; }
      
        DateTime ReleaseDate;
        public DateTime getReleaseDate() { return ReleaseDate; }
        public void setReleaseDate(DateTime NewReleaseDate) { ReleaseDate = NewReleaseDate; }

        Area Area;
        public Area getArea() { return Area; }
        public void setArea(Area NewArea) { Area = NewArea; }
        
        int NumOfRooms;
        public int getNumOfRooms() { return NumOfRooms; }
        public void setNumOfRooms(int NewNumOfRooms) { NumOfRooms = NewNumOfRooms; }

        //Hotel Motel Tzimer
        string Type;
         string getType() { return Type; }
         void setType(string NewType) { Type = NewType; }

         int Adults;
        public int getAdults() { return Adults; }
        public void setAdults(int NewAdults) { Adults = NewAdults; }

         int Children;
        public int getChildren() { return Children; }
        public void setChildren(int NewChildren) { Children = NewChildren; }

        int NumOfBeds;
        public int getNumOfBeds() { return NumOfBeds; }
        public void setNumOfBeds(int NewNumOfBeds) { NumOfBeds = NewNumOfBeds; }

        string Pool;
        public string getPool() { return Pool; }
        public void setPool(string NewPool) { Pool = NewPool; }

        string Jacuzzi;
        public string getJacuzzi() { return Jacuzzi; }
        public void setJacuzzi(string NewJacuzzi) { Jacuzzi = NewJacuzzi; }

        string Garden;
        public string getGarden() { return Garden; }
        public void setGarden(string NewGarden) { Garden = NewGarden; }

        string ChildrensAttractions;
        public string getChildrensAttractions() { return ChildrensAttractions; }
        public void setChildrensAttractions(string NewChildrensAttractions) { ChildrensAttractions = NewChildrensAttractions; }

        string AirConditioner;
        public string getAirConditioner() { return AirConditioner; }
        public void setAirConditioner(string NewAirConditioner) { AirConditioner = NewAirConditioner; }
    
        public string Hikes;
        public string getHikes() { return Hikes; }
        public void setHikes(string NewHikes) { Hikes = NewHikes; }


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
