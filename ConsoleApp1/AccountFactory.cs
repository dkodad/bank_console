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
            switch (type.ToLower())
            {
                case "checking":
                    return new CheckingAccount(accountNumber);
                case "business":
                    return new BusinessAccount(accountNumber);
                case "savings":
                    return new SavingsAccount(accountNumber);
                default:
                    throw new ArgumentException("Neplatný typ účtu");
            }
        }
    }
}
