using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Asbtract
{
    public abstract class BackAccount
    {
        public virtual double Balance { protected set;  get; }
        public double CalculateTotal(double balance)
        {
            return Balance + balance;
        }

        public double GetTotal()
        {
            return Balance;
        }

        public double Debit(double balance)
        {
            Balance -= balance;
            return Balance;
        }
        public double Add(double balance)
        {
            Balance += balance;
            return Balance;
        }

    }
}
