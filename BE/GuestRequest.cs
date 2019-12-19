using System;

namespace BE
{
    public class GuestRequest
    {
        int GuestRequestKey;
        string PrivateName;
        string MailAddress;
        string Status;
        DateTime RegistrationDate;
        DateTime EntryDate;
        DateTime ReleaseDate;
        string  Area;
        string SubArea;
        string Type;
        int Adults;
        int Children;
        string Pool;
        string Jacuzzi;
        string Garden;
        string ChildrensAttractions;
        public override string ToString() { return "the request details:\n" +
                "Guest Request Key:"+ GuestRequestKey+"\n"+; }
    }
}
