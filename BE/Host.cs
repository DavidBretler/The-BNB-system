using System;
using System.Collections.Generic;
using System.Text;

namespace BE
{
    public class Host
    {
        int HostKey { get; }
         string PrivateName { set; get; }
        string FamilyName { set; get; }
        string FhoneNumber { set; get; }
        string MailAddress { set; get; }

        BankAccount HostBankAccuont;
        bool CollectionClearance { set; get; }//permision to debit from bank

        public override string ToString()
        {
            return
                (
                "Host informatin:" +
                "\nHost Key: " + HostKey +
                "\nPrivate Name:" + PrivateName +
                "\nFamily Name:" + FamilyName +
                "\nFhone Number:" + FhoneNumber +
                "\nMail Address:" + MailAddress+
                HostBankAccuont.ToString()+
                "\npermision to debit from bank:"+ CollectionClearance

                );

        }

    }
}
