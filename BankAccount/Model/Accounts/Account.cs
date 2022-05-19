using BankAccount.Core.Model.Operations;
using System;
using System.Collections.Generic;

namespace BankAccount.Core.Model.Accounts
{
    public class Account
    {
        public uint id { get; set; }
        public string firstName { get; set; }
        public string lastname { get; set; }
        public double balance { get; set; }
        public DateTime createdAt { get; set; }
        public DateTime modifiedAt { get; set; }
        public List<Operation> operations { get; set; }

        public Account()
        {
            operations = new List<Operation>();
        }
    }
}