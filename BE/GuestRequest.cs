using System;

namespace BE
{
    public class GuestRequest
    {
        int GuestRequestKey { get;  }
        string PrivateName { get; set; }
        string MailAddress { get; set; }
        string Status { get; set; }
        DateTime RegistrationDate { get; set; }
        DateTime EntryDate { get; set; }
        DateTime ReleaseDate { get; set; }
        string  Area { get; set; }
        string SubArea { get; set; }
        string Type { get; set; }
        int Adults { get; set; }
        int Children { get; set; }
        string Pool { get; set; }
        string Jacuzzi { get; set; }
        string Garden { get; set; }
        string ChildrensAttractions { get; set; }
        public override string ToString() 
        {
            return "the request details:\n" +
                "Guest Request Key: "+ GuestRequestKey+"\n"+
                " PrivateName: "+ PrivateName+ "\n" +
                "MailAddress: " + MailAddress + "\n" + 
                "Status: " + Status+ "\n" + " RegistrationDate: " + RegistrationDate +
                " EntryDate: "+ EntryDate + " ReleaseDate: "+ ReleaseDate+ "\n" +
                " Area: " + Area+  "SubArea: "+ SubArea+ "\n" +
                " Type :" + Type+ " Adults :"+ Adults + 
                " Children :"+ Children+ "\n" +
                "Pool: " + Pool+ " Jacuzzi: "+ Jacuzzi+ 
                " Garden: "+ Garden+ " ChildrensAttractions: "+ChildrensAttractions; 
        }
    }
}
