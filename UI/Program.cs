using System;
using BE;
using BL;
using System.Collections.Generic;
using System.Linq;
namespace UI
{
    class Program
    {
        static void Main(string[] args)
        {
            BL.IBL bl = BL.Factory.GetBL();
            int op = Convert.ToInt32(Console.ReadLine()); ;
            BE.HostingUnit h;
            h = new BE.HostingUnit()
            {
                HostingUnitKey = 4,
                // Owner="doby",
                HostingUnitName = "the rock",
                NumOfRooms = 20,
                NumOfBeds = 20,
                pool = (Choice)1,
                Jacuzzi = (Choice)1,
                Area = (Area)1,
                Garden = (Choice)1,
                AirConditioner = 0,
                ChildrensAttractions = 0,
                Type = 0,
                Hikes = 0,
            };
            BE.GuestRequest GR =
            new BE.GuestRequest()
            {
                GuestRequestKey = BE.Configuration.getNewHostingUnitKey(),
                PrivateName = "dov",
                FamilyName = "aquamen",
                MailAddress = "bbb@aaa.com",
                Status = 0,
                RegistrationDate = new DateTime(2019, 01, 02),
                EntryDate = new DateTime(2019, 01, 02),
                EndDate = new DateTime(2019, 01, 03),
                Type = 0,
                Area = 0,
                Adults = 10,
                Pool = 0,
                Jacuzzi = 0,
                Garden = 0,
                ChildrensAttractions = 0,
                Hikes = 0,
                AirConditioner = 0,
                NumOfBeds = 0,
            };
            while (op != 0)
            {
                
                Console.WriteLine("what do you want to do?");
                Console.WriteLine("1. to add Hosting Unit");
                Console.WriteLine("2. to add guest request");             
                Console.WriteLine("3. to update order status");
                Console.WriteLine("4. to update  Hosting Unit");              
                Console.WriteLine("5. to delete hosting unit");

                Console.WriteLine("6. to open new order");
                Console.WriteLine("7. to get Hosting Unit by Area");
                  bool[,] Diary = new bool[12, 31]; 
                switch (op)
                {
                    case 1:
                        List<BE.HostingUnit> List = bl.getListOfHostingUnits();
                        bl.AddNewHostingUnit("asd", 5,  6, 0, 0, 0, 0, 0, 0, 0, 0, Diary, 1);
                        break;
                    case 2:
                        bl.AddNewGestreqest();
                        break;
                    case 3:
                        Console.WriteLine("Enter order to change status ");
                        Order order;
                        int orderKey = int.Parse(Console.ReadLine());
                        var orignalOrder = bl.getListOfOrder().Where(x => x.OrderKey == orderKey);
                        order = orignalOrder.First();

                        bl.updateStatusOfOrder(order, 0);
                        break;
                    case 4:
                           bl.UpdateHostingUnit(h);
                        break;
                    case 5:
                        bl.DeleteHostingUnit(h);
                        break;
                    case 6:
                        bl.NewOrder(GR, h);
                        break;
                    case 7:
                        bl.list
                        break;

                }
            }
            
        }
    }
}
