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
        public Host getOwner() { return Owner; }
        public void setOwner(Host newOwner) { Owner = newOwner; }
        string HostingUnitName;
        public string getHostingUnitName() { return HostingUnitName; }
        public void setHostingUnitName(string name) { HostingUnitKey = key; }
        int NumOfRooms;
        public int getNumOfRooms() { return NumOfRooms; }
        public void setNumOfRooms(int newNumOfRooms) { NumOfRooms = newNumOfRooms; }
       
        bool pool;
        public bool getPool() { return pool; }
        public void setPool(bool newPool) { pool = newPool; }
        bool Jacuzzi;
        public int getJacuzzi() { return HostingUnitKey; }
        public void setJacuzzi(int key) { HostingUnitKey = key; }
        string Area;    
        public void setArea(string newArea) { Area = newArea; }
        public string getArea() { return Area; }
        bool Garden;
        public bool getGarden() { return Garden; }
        public void setGarden(bool NewGarden) { Garden = NewGarden; }
        
        bool AirConditioner;
        public bool getAirConditioner() { return AirConditioner; }
        public void setAirConditioner(bool newAirConditioner) { AirConditioner = newAirConditioner; }
       
        bool [,] Dairy = new bool[12,31];
        public bool[,] GetDairy() 
        {
            for (int i = 0; i < length; i++)
            {
                for (int i = 0; i < length; i++)
                {
//העתקת המערך החדש לישן 
                }
            }
            return ; }
       
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

