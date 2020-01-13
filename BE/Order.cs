using System;
using System.Collections.Generic;
using System.Text;

namespace BE
{
   public class Order
    {
        public int HostingUnitKey { get; set; }
      

        public int GuestRequestKey { get; set; }


        public int OrderKey { get; set; }


        public  Status Status { get; set; }
        //public Status getStatus() { return Status; }
        //public void setStatus(Status NewStatus) {
        //    if (Status != (Status)2)
        //        Status = NewStatus;
        //    else
        //        throw new GenralException("Order", "Order closed,can not change Status.");
        //}

        public DateTime CreateDate { get; set; }


        public DateTime contactCustumerDate { get; set; }

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
                "\nOrder Date:" + contactCustumerDate


                );

        }

    }
}
