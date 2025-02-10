using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    public class AccountFactory
    {
        public static Account CreateAccount(string type, string accountNumber)
        {
            if (type == "checking")
            {
                return new CheckingAccount(accountNumber);
            }
            else if (type == "savings")
            {
                return new SavingsAccount(accountNumber);
            }
            else if (type == "business")
            {
                return new BusinessAccount(accountNumber);
            }
            else
            {
                throw new ArgumentException("Neplatný typ účtu");
            }
        }
    }
}
