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
        Choice pool;
        public Choice getPool() { return pool; }
        public void setPool(Choice NewPool) { pool = NewPool; }
        //
        Choice Jacuzzi;
        public Choice getJacuzzi() { return Jacuzzi; }
        public void setJacuzzi(Choice NewJacuzzi) { Jacuzzi = NewJacuzzi; }
        //
       public Area Area;    
        public void setArea(Area NewArea) { Area = NewArea; }
        public Area getArea() { return Area; }
        //
        Choice Garden;
        public Choice getGarden() { return Garden; }
        public void setGarden(Choice NewGarden) { Garden = NewGarden; }
        //
        Choice AirConditioner;
        public Choice getAirConditioner() { return AirConditioner; }
        public void setAirConditioner(Choice NewAirConditioner) { AirConditioner = NewAirConditioner; }
        //

        Choice ChildrensAttractions;
        public Choice getChildrensAttractions() { return ChildrensAttractions; }
        public void setChildrensAttractions(Choice NewChildrensAttractions) { ChildrensAttractions = NewChildrensAttractions; }
        //
         ResortType Type;
       public ResortType getType() { return Type; }
        public void setType(ResortType NewType) { Type = NewType; }
        //
        Choice Hikes;
        public Choice getHikes() { return Hikes; }
        public void setHikes(Choice NewHikes) { Hikes = NewHikes; }
        //
        //calender that  is made of array of  12 arrays
        bool[][] Diary = new bool[12][]
             //{   new bool[31],//January 
             //    new bool[28],//February
             //    new bool[31],//March 
             //    new bool[30],//April 
             //    new bool[31],//May
             //    new bool[30],//June 
             //    new bool[31],//July 
             //    new bool[31],//August 
             //    new bool[30],//September 
             //    new bool[31],//October 
             //    new bool[30],//November 
             //    new bool[31],//December 
             //  };
             for (int i = 0; i<length; i++)
			{
            for (int i = 0; i<length; i++)
			{

			}
			}


        public bool[][] GetDiary() { return Diary; }
        public void setDiary(bool[][] NewDiary)
        {
            Diary = NewDiary;
            for (int i = 0; i < 12; i++)
            {
                for (int j = 0; j < NewDiary[i].Length; j++)
                {
                    Diary[i][j] = NewDiary[i][j];
                }
            }
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

