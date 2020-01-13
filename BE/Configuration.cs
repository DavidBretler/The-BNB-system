using System;
using System.Collections.Generic;
using System.Text;

namespace BE
{
  public   class Configuration
    {
        static int  HostingUnitKey ;
        static int GuestRequestKey;
        static int HostKey;
        static int OrderKey=0;
        static double Commission = 10; //commission for orders
        static int Password = 999;

        static public int getPassword() { return ++Password; }
        static public double getCommission() { return Commission; }
        static public int getNewHostingUnitKey() { return ++HostingUnitKey; }//the func in adding one to the num and then returning the new num
        static public int getNewGuestRequestKey() { return ++GuestRequestKey; }//the func in adding one to the num and then returning the new num
        static public int getNewHostKey() { return ++HostKey; }//the func in adding one to the num and then returning the new num
        static public int getNewOrderKey() { return ++OrderKey; }//the func in adding one to the num and then returning the new num

    }
  
}
