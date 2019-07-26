using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WPos.Domain
{
   public  class Operator : BaseEntity
    {
        public string Phone { get; set; }
        public string Email { get; set; }
        public string CNIC { get; set; }
        public string Address { get; set; }
        public string Notes { get; set; }
        public string User { get; set; }
        public Role Role { get; set; }
        public string Password { get; set; }
        public ICollection<Shift> Shifts { get; set; }

        public Shift LastShift { get => Shifts?.OrderBy(x => x.Id).Last(); }
        public float NetOpeining { get => Shifts?.Sum(x => x.OpeningBalance) ?? 0; }
        public float NetClosing { get => Shifts?.Sum(x => x.ClosingBalance) ?? 0; }
        public float CashReceived { get => Shifts?.Sum(x => x.CashIn) ?? 0; }
        public float Cashout { get => Shifts?.Sum(x => x.CashOut) ?? 0; }


        public override bool HasErrors(out string errors)
        {
            errors = null;
            return false;
        }
    }

    public class Shift : BaseEntity
    {
        public List<Transaction> CurrentTransactions { get => currentTransactions; }
        private readonly List<Transaction> currentTransactions = new List<Transaction>();
        public float OpeningBalance { get; set; }
        public float ClosingBalance { get; set; }
        public ICollection<Transaction> Transactions { get; set; }

        public float CashIn { get => currentTransactions?.ToList().FindAll(x => x.TransactionType == TransactionType.Cashin).Sum(x => x.Amount) ?? 0; }
        public float CashOut { get => currentTransactions?.ToList().FindAll(x => x.TransactionType != TransactionType.Cashin).Sum(x => x.Amount) ?? 0; }

        public float AddTransaction(Transaction transaction)
        {
            if (Transactions == null)
            {
                Transactions = new List<Transaction>();
            }
            Transactions.Add(transaction);
            currentTransactions.Add(transaction);
            ClosingBalance = OpeningBalance + CashIn - CashOut;
            return ClosingBalance;
        }

        public override bool HasErrors(out string errors)
        {
            errors = null;
            return false;
        }
    }

    public enum Role
    {
        StandardUser = 0,
        Administrator = 1
    }
}