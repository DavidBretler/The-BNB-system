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
        public void setHostingUnitName(string NewHostingUnitName) { HostingUnitName = NewHostingUnitName; }
        //
        int NumOfRooms;
        public int getNumOfRooms() { return NumOfRooms; }
        public void setNumOfRooms(int NewNumOfRooms) { NumOfRooms = NewNumOfRooms; }
        //
        int NumOfBeds;
        public int getNumOfBeds() { return NumOfBeds; }
        public void setNumOfBeds(int NewNumOfBeds) { NumOfBeds = NewNumOfBeds; }
        //
        bool pool;
        public bool getPool() { return pool; }
        public void setPool(bool NewPool) { pool = NewPool; }
        //
        bool Jacuzzi;
        public int getJacuzzi() { return HostingUnitKey; }
        public void setJacuzzi(int Key) { HostingUnitKey = Key; }
        //
       public string Area;    
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

        string ChildrensAttractions;
        public string getChildrensAttractions() { return ChildrensAttractions; }
        public void setChildrensAttractions(string NewChildrensAttractions) { ChildrensAttractions = NewChildrensAttractions; }
        //
        string Type;
       public  string getType() { return Type; }
        public void setType(string NewType) { Type = NewType; }
        //
        string Hikes { get; set; }
        public string getHikes() { return Hikes; }
        public void setHikes(string NewHikes) { Hikes = NewHikes; }
        //
        bool [,] Diary = new bool[12,31];
        public bool[,] GetDiary()  {return Diary;  }
        public void setDiary(bool[,] NewDiary) { Diary = NewDiary; }

        //

        public override string ToString() 
        {
            return "HostingUnitKey: " + HostingUnitKey +
                "/n Owner: " + Owner + "HostingUnitName: " + HostingUnitName +
                "Num Of Rooms: " + NumOfRooms + "AirConditioner: "+ AirConditioner;
               }
         }
    }

