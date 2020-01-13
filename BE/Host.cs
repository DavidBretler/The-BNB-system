using System;
using System.Collections.Generic;
using System.Text;

namespace BE
{
    public class Host
    {

        //

       public int HostKey { get; set; }

        //

        public int password { get; set; }
        //
        public string PrivateName { get; set; }
     
        //
        public string FamilyName { get; set; }
   
        //
        public string PhoneNumber { get; set; }
      
        //
        public string MailAddress { get; set; }
      
        //
        public int  numberOfUints { get; set; }
       

        public BankAccount HostBankAccuont { get; set; }
     
        //
        public bool CollectionClearance { set; get; }//permision to debit from bank

        public override string ToString()
        {
            return
                (
                "Host informatin:" +
                "\nHost Key: " + HostKey +
                "\nPrivate Name:" + PrivateName +
                "\nFamily Name:" + FamilyName +
                "\nFhone Number:" + PhoneNumber +
                "\nMail Address:" + MailAddress+
  //              HostBankAccuont.ToString()+
                "\npermision to debit from bank:"+ CollectionClearance

                );

        }

    }
}
