using System;

namespace BE
{
    public class GuestRequest
    {
        int GuestRequestKey;
            
       public int getGuestRequestKey() { return GuestRequestKey; }

        string PrivateName { get; set; }
        string MailAddress { get; set; }
        string Status { get; set; }
        DateTime RegistrationDate { get; set; }
        DateTime EntryDate { get; set; }
        DateTime ReleaseDate { get; set; }
       public string  Area { get; set; }
        public int NumOfRooms { get; set; }

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
            return "the request details:\n" +
                "Guest Request Key: "+ GuestRequestKey+"\n"+
                " PrivateName: "+ PrivateName+ "\n" +
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
