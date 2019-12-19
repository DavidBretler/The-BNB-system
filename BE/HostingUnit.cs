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
        int NumOfRooms { get; set; };
        bool pool { get; set; };
        bool Jacuzzi { get; set; }
        bool Garden { get; set; }
        bool AirCondisiner { get; set; }
        bool [,] Dairy = new bool[12,31];     
        public override string ToString() 
        {
            return "HostingUnitKey: " + HostingUnitKey +
                "/n Owner: " + Owner + "HostingUnitName: " + HostingUnitName +
                "Num Of Rooms: " + NumOfRooms;
                for (int i = 0; i<12; i++)
			   {
              for (int j = 0; j<31; j++)

                    Console.WriteLine(Dairy[i, j]);
               }
         }
    }
}
