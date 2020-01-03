using System;
using System.Collections.Generic;
using System.Text;

namespace BE
{
    public class Host
    {
        //
        int HostKey;
       public int getHostKey() { return HostKey; }
        public void setHostKey(int Key) { HostKey = Key; }
        //
        string PrivateName;
        public string getPrivateName() { return PrivateName; }
        public void setPrivateName(string NewPrivateName) { PrivateName = NewPrivateName; }
        //
        string FamilyName;
        public string getFamilyName() { return FamilyName; }
        public void setFamilyName(string NewFamilyName) { FamilyName = NewFamilyName; }
        //
        string PhoneNumber;
        public string getPhoneNumber() { return PhoneNumber; }
        public void setPhoneNumber(string NewPhoneNumber) { PhoneNumber = NewPhoneNumber; }
        //
        string MailAddress;
        public string getMailAddress() { return MailAddress; }
        public void setMailAddress(string NewMailAddress) { MailAddress = NewMailAddress; }
        //

        BankAccount HostBankAccuont;
        public BankAccount getHostBankAccuont() { return HostBankAccuont; }
        public void setHostBankAccuont(BankAccount NewHostBankAccuont) { HostBankAccuont = NewHostBankAccuont; }
        //
        bool CollectionClearance { set; get; }//permision to debit from bank

        public override string ToString()
        {
            return
                (
                "Host informatin:" +
                "\nHost Key: " + HostKey +
                "\nPrivate Name:" + PrivateName +
                "\nFamily Name:" + FamilyName +
                "\nFhone Number:" +PhoneNumber +
                "\nMail Address:" + MailAddress+
                HostBankAccuont.ToString()+
                "\npermision to debit from bank:"+ CollectionClearance

                );

        }

    }
}
