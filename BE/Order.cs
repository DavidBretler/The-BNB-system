using System;
using System.Collections.Generic;
using System.Text;

namespace BE
{
   public class Order
    {
        int HostingUnitKey { get; }
        int GuestRequestKey { get; }
        int OrderKey { get; }
        string Status { get; }
        DateTime CreateDate { get; }
        DateTime OrderDate { get; }

        public override string ToString()
        {
            return
                (
                "Oredr informatin:" +
                "\nHosting Unit Key: " + HostingUnitKey +
                "\nGuest Request Key:" + GuestRequestKey +
                "\nOrder Key:" + OrderKey +
                "\nOrder Status:" + Status +
                "\nCreate Date:" + CreateDate +
                "\nOrder Date:" + OrderDate 
               

                );

        }

    }
}
