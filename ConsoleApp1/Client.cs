﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    public interface IAccountObserver
    {
        void Update(decimal balance);
    }

    public class Client : IAccountObserver
    {
        public string Name { get; }

        public Client(string name)
        {
            Name = name;
        }

        public void Update(decimal balance)
        {
            Console.WriteLine($"Klient {Name} byl informován o změně zůstatku: {balance} Kč");
        }
    }
}
