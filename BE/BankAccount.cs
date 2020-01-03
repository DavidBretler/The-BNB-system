using System;
using System.Collections.Generic;
using System.Text;

namespace BE
{
   public class BankAccount
    {
        string BankName { get; }
        int BranchNumber { get; }
        string BranchAddress { get; }
        string BranchCity { get; }
        int BankAccountNumber { get; }

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

