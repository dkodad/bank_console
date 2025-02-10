using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    public class CheckingAccount : Account
    {
        public CheckingAccount(string accountNumber) : base(accountNumber) { }

        public override void Withdraw(decimal amount)
        {
            if (amount <= 0)
            {
                Console.WriteLine("\t Výběr musí být kladná částka.");
                return;
            }

            if (Balance <= 0)
            {
                Console.WriteLine("\t Nedostatečný zůstatek pro výběr.");
                return;
            }


            if (amount <= Balance)
            {
                Balance -= amount;
                Console.WriteLine($" \t Vybráno {amount} Kč z účtu {AccountNumber}.");
                Notify();
            }
            else
            {
                Console.WriteLine(" \t Nedostatečný zůstatek pro výběr.");
            }
        }

    }
}
