using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    public class Bank
    {
        private static Bank _instance;
        private List<Account> _accounts = new List<Account>();
        private Bank() { }

        public static Bank Instance
        {
            get
            {
                if (_instance == null)
                    _instance = new Bank();
                return _instance;
            }
        }

        public void AddAccount(Account account)
        {
            _accounts.Add(account);
        }
        public Account GetAccount(string accountNumber)
        {
            return _accounts.FirstOrDefault(a => a.AccountNumber == accountNumber);
        }
        public void ProcessTransaction(string accountNumber, decimal amount)
        {
            var account = _accounts.FirstOrDefault(a => a.AccountNumber == accountNumber);
            if (account != null)
            {
                account.Deposit(amount); // nebo account.Withdraw(amount);
            }
            else
            {
                Console.WriteLine("Účet nebyl nalezen.");
            }
        }
         public void Transfer(string fromAccountNumber, string toAccountNumber, decimal amount)
    {
        var fromAccount = GetAccount(fromAccountNumber);
        var toAccount = GetAccount(toAccountNumber);

        if (fromAccount == null || toAccount == null)
        {
            Console.WriteLine("⛔ Jeden z účtů nebyl nalezen.");
            return;
        }

        if (amount <= 0)
        {
            Console.WriteLine("⛔ Částka pro převod musí být kladná.");
            return;
        }

        // Zkontroluj, zda je na účtu dostatek peněz pro převod
        if (fromAccount.Balance < amount)
        {
            Console.WriteLine("⛔ Nedostatečný zůstatek pro převod.");
            return;
        }

        // Proveď převod
        fromAccount.Withdraw(amount); // Nejprve odečteme částku z účtu odesílatele
        toAccount.Deposit(amount);    // Poté přičteme částku na účet příjemce

        Console.WriteLine($"✅ {amount} Kč bylo převedeno z účtu {fromAccountNumber} na účet {toAccountNumber}.");
    }

    }

}
