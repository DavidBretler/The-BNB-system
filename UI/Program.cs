using System;
using BE;
using BL;
using System.Collections.Generic;
namespace UI
{
    class Program
    {
        static void Main(string[] args)
        {
            BL.IBL bl = BL.Factory.GetBL();      
            int op = Convert.ToInt32(Console.ReadLine()); ;
            BE.HostingUnit h;
            while(op!=0)
            switch(op)              
                {
                    case 0: 
                       List < BE.HostingUnit>  List = bl.getListOfHostingUnits();
                        bl.UpdateHostingUnit(h);

                        break;
                    case 1:

                        break;
                    case 2:

                        break;
                    case 3:

                        break;
                    case 4:

                        break;
                    case 5:

                        break;
                    case 6:

                        break;

                }

            
        }
    }
}
