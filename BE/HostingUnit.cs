using System;
using System.Collections.Generic;
using System.Text;

namespace BE
{ 
    class HostingUnit
    {
      int HostingUnitKey { get; }
       Host Owner { get; }
        string HostingUnitName { get; }
        bool [,] Dairy = new bool[12,31];     
        public override string ToString() 
        { 
            return "HostingUnitKey: "+HostingUnitKey+
                "/n Owner: "+Owner +"HostingUnitName: "+HostingUnitName +
                for (int i = 0; i<12; i++)
			   {
              for (int j = 0; j<31; j++)

                    Console.WriteLine(Dairy[i, j]);
               }
         }
    }
}
