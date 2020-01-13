using System;
using System.Collections.Generic;
using System.Text;

namespace BE
{

    public class GenralException : Exception
    {
        string ClassName;
        string explenation;

        public GenralException(string ClassName2, string exp) { ClassName = ClassName2; explenation = exp; }
    }
    public class MissingIdException : Exception
    {
        string ClassName;
        int ID;
        new string  Message;

        public MissingIdException(string ClassName2, int id2) { ID = id2; ClassName = ClassName2; }
        public MissingIdException(string ClassName2, int id2, string exp) { ID = id2; ClassName = ClassName2; Message = exp; }
    }
    //
    public class IDalreadyExistsException : Exception
    {
        string ClassName;
        int ID;
        public IDalreadyExistsException(string ClassName2, int id2) { ID = id2; ClassName = ClassName2; }
    }

    //Misinig Clearance Exceptions
    public class MisinigClearanceException : Exception
    {
        string ClassName;

        string explenation;

        public MisinigClearanceException(string ClassName2, string exp) { ClassName = ClassName2; explenation = exp; }
    }

    public class DateException : Exception
    {
        string ClassName;

        string explenation;

        public DateException(string ClassName2, string exp) { ClassName = ClassName2; explenation = exp; }
    }

  
    public class keyBeenBooked : Exception
    {
        public string ClassName;
        public int key;
        public List<BE.Order> list;
        public keyBeenBooked(string ClassName2, int key2, List<BE.Order> list2) { key = key2; ClassName = ClassName2; list = list2; }
    }
}