using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    public class BusinessAccount : Account
    {
        private decimal _overdraftLimit;

        public BusinessAccount(string accountNumber, decimal overdraftLimit = -10000) : base(accountNumber) {
            _overdraftLimit = overdraftLimit;
        }



        public override void Withdraw(decimal amount)
        {
            if (amount <= 0)
            {
                Console.WriteLine("\t Výběr musí být kladná částka.");
                return;
            }

            

            if (Balance + _overdraftLimit >= amount)
            {
                Balance -= amount;
                Console.WriteLine($"\t Vybráno {amount} Kč z účtu {AccountNumber}. Zůstalo na účtu {Balance} Kč.");
                Notify();
            }
            else
            {
                Console.WriteLine("\t Nedostatečný zůstatek nebo překročený limit pro výběr.");
            }
        }

    }
}
