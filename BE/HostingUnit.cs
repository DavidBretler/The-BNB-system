using System;
using System.Collections.Generic;
using System.Text;
namespace BE
{
    public class HostingUnit : Clonable
    {
       //
         public int HostingUnitKey { get; set; }  
    //
        public Host Owner { get; set; }
        //
        public string HostingUnitName { get; set; }
        public int NumOfRooms { get; set; }
        //
        public int NumOfBeds { get; set; }
        //
        public Choice pool { get; set; }
        //
        public Choice Jacuzzi { get; set; }
        //
        public Area Area { get; set; }
        //
        public Choice Garden { get; set; }
        //
        public  Choice AirConditioner { get; set; }
        //
        public Choice ChildrensAttractions { get; set; }
        //
        public ResortType Type { get; set; }
        //
        public Choice Hikes { get; set; }
        //
        //calender that  is made of array of  12 arrays
        public bool[,] Diary = new bool[12, 31];
        public HostingUnit GetCopy() { 
            return (HostingUnit)this.MemberwiseClone();
        }

        /// <summary>
        /// indexer for hosting unit
        /// </summary>
        /// <param name="date"></param>
        /// <returns>true/false if the unit is free or ocuipided on the givin date</returns>


        public bool this[DateTime date]
        {
            set => Diary[ date.Month - 1,date.Day - 1] = value;
            get => Diary[ date.Month - 1, date.Day - 1];
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

