using System;
using System.Collections.Generic;
using System.Text;

namespace BE
{ 
   public class HostingUnit
    {
        //
        int HostingUnitKey;
        public int getHostingUnitKey() { return HostingUnitKey; }
        public void setHostingUnitKey(int Key) { HostingUnitKey = Key; }
        //
        Host Owner;
        public Host getOwner() { return Owner; }
        public void setOwner(Host NewOwner) { Owner = NewOwner; }
        //
        string HostingUnitName;
        public string getHostingUnitName() { return HostingUnitName; }
        public void setHostingUnitName(string key) { HostingUnitKey = key; }
        //
        int NumOfRooms;
        public int getNumOfRooms() { return NumOfRooms; }
        public void setNumOfRooms(int NewNumOfRooms) { NumOfRooms = NewNumOfRooms; }
        //
        int NumOfBeds { get; set; }
        //
        bool pool;
        public bool getPool() { return pool; }
        public void setPool(bool NewPool) { pool = NewPool; }
        //
        bool Jacuzzi;
        public int getJacuzzi() { return HostingUnitKey; }
        public void setJacuzzi(int Key) { HostingUnitKey = Key; }
        //
        string Area;    
        public void setArea(string NewArea) { Area = NewArea; }
        public string getArea() { return Area; }
        //
        bool Garden;
        public bool getGarden() { return Garden; }
        public void setGarden(bool NewGarden) { Garden = NewGarden; }
        //
        bool AirConditioner;
        public bool getAirConditioner() { return AirConditioner; }
        public void setAirConditioner(bool NewAirConditioner) { AirConditioner = NewAirConditioner; }
        //
        public string ChildrensAttractions { get; set; }
        //
        string Type { get; set; }
        //
        string hikes { get; set; }
        //
        bool [,] Dairy = new bool[12,31];
        public bool[,] GetDairy() 
        {
            return Dairy; 
        }
        //
        
        public override string ToString() 
        {
            return "HostingUnitKey: " + HostingUnitKey +
                "/n Owner: " + Owner + "HostingUnitName: " + HostingUnitName +
                "Num Of Rooms: " + NumOfRooms + "AirConditioner: "+ AirConditioner;
               }
         }
    }

