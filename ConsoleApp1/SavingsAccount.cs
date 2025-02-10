using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    public class SavingsAccount : Account
    {
        private const decimal MinimumBalance = 500;

        public SavingsAccount(string accountNumber) : base(accountNumber) { }

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

            if (amount > Balance)
            {
                Console.WriteLine("\t Nedostatečný zůstatek pro výběr.");
                return;
            }

            if (Balance - amount >= MinimumBalance)
            {
                Balance -= amount;
                Console.WriteLine($"\t Vybráno {amount} Kč z účtu {AccountNumber}. Zůstalo na účtu {Balance} Kč.");
                Notify();
            }
            else
            {
                Console.WriteLine($"\t Nelze vybrat! Na spořicím účtu musí zůstat alespoň {MinimumBalance} Kč.");
            }
        }

    }
}
