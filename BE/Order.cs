using System;
using System.Collections.Generic;
using System.Text;

namespace BE
{
   public class Order
    {
        int HostingUnitKey;
       public  int getHostingUnitKey() { return HostingUnitKey; }
        int GuestRequestKey { get; }
        int OrderKey;
        public int getOrderKey() { return OrderKey; }
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
