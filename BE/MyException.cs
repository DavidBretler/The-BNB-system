using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace BE
{

 
    [Serializable]
    public class GenralException : Exception
    {
        string ClassName;
        public int capacity { get; private set; }
        public GenralException() : base() { }
        public GenralException(string message) : base(message) { }
        public GenralException(string ClassName, string message) : base(message)
        {
            this.ClassName = ClassName;
        }
        // special constructor for our custom exception       
        override public string ToString()
        {
            return "OverloadCapacityException: "+ Message;
        }
    }
    public class MissingIdException : Exception
    {
        string ClassName;
        int ID;
        //string message;      
        public MissingIdException() : base() { }
        public MissingIdException(string message) : base(message) { }
        // special constructor for our custom exception       
        public MissingIdException(string ClassName, int ID, string message) : base(message)
        {
            this.ID = ID; this.ClassName = ClassName;
        }

        public MissingIdException(string ClassName, int ID)
        {
            this.ID = ID; this.ClassName = ClassName;
        }

          override public string ToString()
           {

             return base.Message + ID + "חסרה במחלקה  " + ClassName + "תעודת זהות חסרה : תעודת הזהות ";
            }
       }



    //      
    public class IDalreadyExistsException : Exception
    {
        string ClassName;
        int ID;
        public IDalreadyExistsException() : base() { }
        public IDalreadyExistsException(string message) : base(message) { }
        // special constructor for our custom exception       
        public IDalreadyExistsException(string ClassName, int ID, string message) : base(message)
        {
            this.ID = ID; this.ClassName = ClassName;
        }

        public IDalreadyExistsException(string ClassName, int ID)
        {
            this.ID = ID; this.ClassName = ClassName;
        }
        override public string ToString()
        {

            return base.Message + ID + "חסרה במחלקה  " + ClassName + "שגיאה :תעודת זהות כבר קיימת  : תעודת הזהות ";
        }
    }
        //Misinig Clearance Exceptions
        public class MisinigClearanceException : Exception
        {
            string ClassName;

            public MisinigClearanceException(string ClassName2, string exp) : base(exp) { ClassName = ClassName2; }
            override public string ToString()
            {

                return base.Message;
            }

        }   

    public class DateException : Exception
    {
        string ClassName;

        string explenation;

        public DateException(string ClassName2, string exp) : base(exp) { ClassName = ClassName2;  }
        override public string ToString()
        {

            return base.Message;
        }
    }

  
    public class keyBeenBooked : Exception
    {
        public string ClassName;
        public int key;
        public List<BE.Order> list;
        public keyBeenBooked(string ClassName2, int key2, List<BE.Order> list2, string exp):base(exp) { key = key2; ClassName = ClassName2; list = list2; }
        override public string ToString()
        {

            return base.Message;
        }
    }
}
