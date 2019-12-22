using System;
using System.Collections.Generic;
using System.Text;

namespace BE
{
    class Configuration
    {
        static int  HostingUnitKey ;
        static int GuestRequestKey;
        static int HostKey;
        static int OrderKey;
         
        public int getNewHostingUnitKey() { return ++HostingUnitKey; }//the func in adding one to the num and then returning the new num
        public int getNewGuestRequestKey() { return ++GuestRequestKey; }//the func in adding one to the num and then returning the new num
        public int getNewHostKey() { return ++HostKey; }//the func in adding one to the num and then returning the new num
        public int getNewOrderKey() { return ++OrderKey; }//the func in adding one to the num and then returning the new num

    }
}
