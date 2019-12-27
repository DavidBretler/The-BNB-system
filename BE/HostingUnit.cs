using System;
using System.Collections.Generic;
using System.Text;

namespace BE
{ 
   public class HostingUnit
    {
        int HostingUnitKey;
        public int getHostingUnitKey() { return HostingUnitKey; }
        public void setHostingUnitKey(int key) { HostingUnitKey = key; }
        Host Owner;
        public int getHostingUnitKey() { return HostingUnitKey; }
        public void setHostingUnitKey(int key) { HostingUnitKey = key; }
        string HostingUnitName;
        public int getHostingUnitKey() { return HostingUnitKey; }
        public void setHostingUnitKey(int key) { HostingUnitKey = key; }
        int NumOfRooms;
        public int getHostingUnitKey() { return HostingUnitKey; }
        public void setHostingUnitKey(int key) { HostingUnitKey = key; }
        bool pool;
        public int getHostingUnitKey() { return HostingUnitKey; }
        public void setHostingUnitKey(int key) { HostingUnitKey = key; }
        bool Jacuzzi;
        public int getHostingUnitKey() { return HostingUnitKey; }
        public void setHostingUnitKey(int key) { HostingUnitKey = key; }
        string Area;
        public int getHostingUnitKey() { return HostingUnitKey; }
        public void setHostingUnitKey(int key) { HostingUnitKey = key; }
        public string getArea() { return Area; }
        bool Garden;
        public int getHostingUnitKey() { return HostingUnitKey; }
        public void setHostingUnitKey(int key) { HostingUnitKey = key; }
        bool AirConditioner;
        public int getHostingUnitKey() { return HostingUnitKey; }
        public void setHostingUnitKey(int key) { HostingUnitKey = key; }
       
        bool [,] Dairy = new bool[12,31];
        public int getHostingUnitKey() { return HostingUnitKey; }
        public void setHostingUnitKey(int key) { HostingUnitKey = key; }
        public override string ToString() 
        {
            return "HostingUnitKey: " + HostingUnitKey +
                "/n Owner: " + Owner + "HostingUnitName: " + HostingUnitName +
                "Num Of Rooms: " + NumOfRooms + "AirConditioner: "+ AirConditioner;
      //          for (int i = 0; i<12; i++)
			   //{
      //        for (int j = 0; j<31; j++)

      //              Console.WriteLine(Dairy[i, j]);
               }
         }
    }

