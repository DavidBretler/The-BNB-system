using System;
using System.Collections.Generic;
using System.Text;

namespace BE
{
   public class Order
    {
        int HostingUnitKey;
       public  int getHostingUnitKey() { return HostingUnitKey; }
        public void setHostingUnitKey(int NewHostingUnitKey) { HostingUnitKey = NewHostingUnitKey; }

        int GuestRequestKey;
        public int getGuestRequestKey() { return GuestRequestKey; }
        public void setGuestRequestKey(int NewGuestRequestKey) { GuestRequestKey = NewGuestRequestKey; }

        int OrderKey;
        public int getOrderKey() { return OrderKey; }
        public void setOrderKey(int NewOrderKey) { OrderKey = NewOrderKey; }

        string Status;
        public string getStatus() { return Status; }
        public void setStatus(string NewStatus) { Status = NewStatus; }

        DateTime CreateDate;
        public DateTime getCreateDate() { return CreateDate; }
        public void setCreateDate(DateTime NewCreateDate) { CreateDate = NewCreateDate; }

        DateTime OrderDate;
        public DateTime getOrderDate() { return OrderDate; }
        public void setOrderDate(DateTime NewOrderDate) { OrderDate = NewOrderDate; }

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
