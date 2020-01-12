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
            try
            {
                Console.WriteLine("what do you want to do?");

                BL.IBL bl = BL.Factory.GetBL();
                BE.HostingUnit h;
                h = new BE.HostingUnit()
                {
                    HostingUnitKey =Configuration.getNewHostingUnitKey(),
                    // Owner="doby",
                    HostingUnitName = "the blob",
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
                    GuestRequestKey = 1,
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
                int op = Convert.ToInt32(Console.ReadLine()); ;
                do
                {

                    Console.WriteLine("what do you want to do?");
                    Console.WriteLine("1. to add Hosting Unit");
                    Console.WriteLine("2. to add guest request");
                    Console.WriteLine("3. to update order status");
                    Console.WriteLine("4. to update  Hosting Unit");
                    Console.WriteLine("5. to delete hosting unit");

                    Console.WriteLine("6. to open new order");
                    Console.WriteLine("7. to get Hosting Unit by Area");
                    op = Convert.ToInt32(Console.ReadLine()); ;


                    switch (op)
                    {
                        case 1:
                            bl.AddNewHostingUnit("asd", 5, 6, 0, 0, 0, 0, 0, 0, 0, 0, 1);
                            foreach (HostingUnit item in bl.getListOfHostingUnits())
                                Console.WriteLine(item);
                            break;
                        case 2:
                            bl.NewGuestRequests("aa", "bb", "asd@gmail", 0,
                            new DateTime(2020, 2, 1), new DateTime(2020, 10, 1),
                            new DateTime(2020, 5, 1), 0, 5, 0, 6, 7, 8, 0, 0, 0, 0, 0, 0);
                            foreach (GuestRequest item in bl.getListOfGuestRequest())
                                Console.WriteLine(item);
                            break;
                        case 3:
                            Console.WriteLine("Enter order to change status ");
                            Order order;
                            int orderKey = int.Parse(Console.ReadLine());
                            var orignalOrder = bl.getListOfOrder().FindAll(x => x.OrderKey == orderKey);

                            if (!(orignalOrder.Count() == 0))
                            {
                                order = orignalOrder.First();
                                bl.updateStatusOfOrder(order, 2);
                                foreach (var item in bl.getListOfOrder())
                                    Console.WriteLine(item);
                            }
                            else
                                Console.WriteLine("order not exsit ");

                            break;
                        case 4:
                            bl.UpdateHostingUnit(h);
                            foreach (var item in bl.getListOfHostingUnits())
                                Console.WriteLine(item);

                            break;
                        case 5:
                            bl.DeleteHostingUnit(2);
                            foreach (var item in bl.getListOfHostingUnits())
                                Console.WriteLine(item);
                            break;
                        case 6:
                            bl.NewOrder(GR, h);
                            foreach (var item in bl.getListOfOrder())
                                Console.WriteLine(item);
                            break;
                        case 7:
                            bl.ListOfHostingUntisInArea();
                            IEnumerable<IGrouping<Area, HostingUnit>> temp = bl.ListOfHostingUntisInArea();
                            foreach (var item in temp)
                                Console.WriteLine(item.Key);
                            break;

                    }
                } while (op != 0);
            }
            catch (MissingIdException e)
            {
                Console.WriteLine("catch");
                Console.WriteLine(e); }
        }
    }
}
