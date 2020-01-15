using System;
using System.Collections.Generic;
using System.Text;
namespace BE
{
    public class HostingUnit : Clonable
    {
       //
         public int HostingUnitKey;    
    //
        public Host Owner; 
        //
        public string HostingUnitName;
        //
        public int NumOfRooms;
        //
        public int NumOfBeds;
       //
        public Choice pool;
        //
        public Choice Jacuzzi;     
        //
       public Area Area;    
        //
        public Choice Garden;  
        //
       public  Choice AirConditioner;
        //
        public Choice ChildrensAttractions;
        //
        public ResortType Type;     
        //
        public Choice Hikes;
        //
        //calender that  is made of array of  12 arrays
        public bool[,] Diary = new bool[12, 31];  
        
        /// <summary>
        /// indexer for hosting unit
        /// </summary>
        /// <param name="date"></param>
        /// <returns>true/false if the unit is free or ocuipided on the givin date</returns>
       
      
        public bool this[DateTime date]
        {
            set => Diary[date.Day - 1, date.Month - 1] = value;
            get => Diary[date.Day - 1, date.Month - 1];
        }

       
        // new bool[31],//January 
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
        public override string ToString() 
        {
            return "HostingUnitKey: " + HostingUnitKey +
                "\n Owner: " + Owner + " HostingUnitName: " +  HostingUnitName +
                " Num Of Rooms: " + NumOfRooms + " AirConditioner: "+ AirConditioner;
               }
         }
    }

