using System;
using System.Collections.Generic;
using System.Text;

namespace BE
{
    public class BankBranch
    {
       public string BankName { get; set; }
        public int BranchNumber { get; set; }
        public string BranchAddress { get; set; }
        public string BranchCity { get; set; } 
      public BankBranch(string BankName2, int BranchNumber2, string BranchAddress2, string BranchCity2)
        {//temperery till we will get from real banks
            BankName = BankName2; BranchNumber = BranchNumber2;
            BranchAddress = BranchAddress2; BranchCity = BranchCity2;
        }
        public BankBranch()  { }

        public BankBranch GetCopy()
        {
            return (BankBranch)this.MemberwiseClone();
        }
    }
}