using System;

namespace BE
{
    public class GuestRequest
    {
        public int GuestRequestKey { get; set; }

        public int getGuestRequestKey() { return GuestRequestKey; }
        //
        public string PrivateName { get; set; }
        public string FamilyName { get; set; }
  
   

        public string MailAddress { get; set; }


        public orderStatus Status { get; set; }
       
        public DateTime RegistrationDate { get; set; }


        public DateTime EntryDate { get; set; }


        public DateTime EndDate { get; set; }
    

        public Area Area { get; set; }


        public int NumOfRooms { get; set; }


        //Hotel Motel Tzimer
        public ResortType Type{ get; set; }
       
        public int Adults { get; set; }


        public int Children { get; set; }
   

        public int NumOfBeds { get; set; }
    

        public Choice Pool{ get; set; }


    public Choice Jacuzzi { get; set; }
 
        public Choice Garden{ get; set; }

        public Choice ChildrensAttractions { get; set; }


        public Choice AirConditioner  { get; set; }
        
        public Choice Hikes { get; set; }
       

        public override string ToString() 
        {
            return "The request details:\n" +
                "Guest Request Key: "+ GuestRequestKey+"\n"+
                " Name: "+ PrivateName+" "+ FamilyName + "\n" +    
                "MailAddress: " + MailAddress + "\n" + 
                "Status: " + Status+ "\n" + " RegistrationDate: " + RegistrationDate +
                " EntryDate: "+ EntryDate + " EndDate: " + EndDate + "\n" +
                " Area: " + Area +
                " Type :" + Type+ " Adults :"+ Adults + 
                " Children :"+ Children+ "\n" +
                "Pool: " + Pool+ " Jacuzzi: "+ Jacuzzi+ 
                " Garden: "+ Garden+ " ChildrensAttractions: "+ChildrensAttractions+
                " hikes: "+ Hikes + "AirConditioner: "+ AirConditioner; 
        }
    }
}
