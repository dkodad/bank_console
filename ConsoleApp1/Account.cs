using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    public abstract class Account
    {
        public string AccountNumber { get; }
        public decimal Balance { get; protected set; }
        private List<IAccountObserver> _observers = new List<IAccountObserver>();

        public Account(string accountNumber)
        {
            AccountNumber = accountNumber;
            Balance = 0;
        }

        public void Attach(IAccountObserver observer)
        {
            _observers.Add(observer);
        }


        protected void Notify()
        {
            foreach (var observer in _observers)
            {
                observer.Update(Balance);
            }
        }

        public virtual void Deposit(decimal amount)
        {
            if (amount > 0)
            {
                Balance += amount;
                Notify();
            }
        }
        public void ShowBalance()
        {
            Console.WriteLine($"\t Zůstatek na účtu {AccountNumber}: {Balance} Kč");
        }
        public abstract void Withdraw(decimal amount);
    }
}
