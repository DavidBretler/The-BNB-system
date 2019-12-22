using System;
using System.Collections.Generic;
using System.Text;

namespace DS
{
    class DataSource
    {      
        List<BE.GuestRequest> GuestRequests = new List <BE.GuestRequest>();

         List<BE.HostingUnit> HostingUnits = new List<BE.HostingUnit>();
            
         List<BE.Host> Host = new List<BE.Host>();

        BE.GuestRequest GR1;
       
        int GuestRequestKey { get; }
        string PrivateName { get; set; }
        string MailAddress { get; set; }
        string Status { get; set; }
        DateTime RegistrationDate { get; set; }
        DateTime EntryDate { get; set; }
        DateTime ReleaseDate { get; set; }
        string Area { get; set; }
        string SubArea { get; set; }
        string Type { get; set; }
        int Adults { get; set; }
        int Children { get; set; }
        string Pool { get; set; }
        string Jacuzzi { get; set; }
        string Garden { get; set; }
        string ChildrensAttractions { get; set; }
        bool AirConditioner { get; set; }
        string hikes { get; set; }

    }
}
