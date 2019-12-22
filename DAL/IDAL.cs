using System;
using System.Collections.Generic;
using System.Text;

namespace DAL
{
    interface Idal
    {
        void NewCustomerRequest(BE.GuestRequest TheGuestRequest);
        void UpdateCustomerRequest();
        void AddNewHostingUnit(BE.HostingUnit TheHostingUnit);
        void DeleteHostingUnit(BE.HostingUnit TheHostingUnit);
        void UpdateHostingUnit();
        void NewOrder(BE.Order TheOrder);
        void UpdateDateOrder();
        List<BE.HostingUnit> ListOfHostingUnits();
        List<BE.GuestRequest> ListOfGuestRequest();
        List<BE.Order> ListOfOrder();
        List<BE.BankBranch> ListOfBankBranch();
    }
}


//הוספת דרישת לקוח.
//• עדכון דרישת לקוח )שינוי הסטטוס(.
//• הוספת יחידת אירוח
//• מחיקת יחידת אירוח
//• עדכון יחידת אירוח
//• הוספת הזמנה
//• עדכון הזמנה)שינוי הסטטוס(
//בס"ד פרויקט איתור והתאמת נופש, דוט נט התש"פ
//14
//• קבלת רשימת כל יחידות האירוח
//• קבלת רשימת כל דרישות הלקוחות.
//• קבלת רשימת כל ההזמנות
//• קבלת רשימת כל סניפי הבנק הקיימים בארץ )מחזיר אוסף של סניפים
//מסוג המבנה המתאים שהוגדר ב-BE