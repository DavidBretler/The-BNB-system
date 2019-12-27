using System;
using System.Collections.Generic;
using System.Text;

namespace BE
{
    public class BankBranch
    {
        string BankName { get; }
        int BranchNumber { get; }
        string BranchAddress { get; }
        string BranchCity { get; } 
      public BankBranch(string BankName2, int BranchNumber2, string BranchAddress2, string BranchCity2)
        {//temperery till we will get from real banks
            BankName = BankName2; BranchNumber = BranchNumber2;
            BranchAddress = BranchAddress2; BranchCity = BranchCity2;
        }
    }
}