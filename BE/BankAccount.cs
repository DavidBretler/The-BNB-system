using System;
using System.Collections.Generic;
using System.Text;

namespace BE
{
   public class BankAccount
    {
       public string BankName { get; set; }
        public int BranchNumber { get; set; }
        public string BranchAddress { get; set; }
        public string BranchCity { get; set; }
        public int BankAccountNumber { get; set; }
        public int BankNumber { get; set; }

        public override string ToString()
        {
            return 
                (
                "\nBankAccount informatin:"+
                "\nBankName: " + BankName+
                "\nBranch Number:" + BranchNumber+
                "\nBranch Address:" + BranchAddress +
                "\nBranch City:" + BranchCity +
                "\nBank Account Number:" + BankAccountNumber
                );

        }
    }
}

