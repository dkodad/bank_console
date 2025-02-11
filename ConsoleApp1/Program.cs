using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    internal class Program
    {
        static void Main(string[] args)
        {

            Bank bank = Bank.Instance;
            Dictionary<string, Client> clients = new Dictionary<string, Client>();

            while (true)
            {
                Console.WriteLine("\n-----------------------------------------------");
                Console.WriteLine("Bankovní aplikace");
                Console.WriteLine("1. Vytvořit účet");
                Console.WriteLine("2. Vložit peníze");
                Console.WriteLine("3. Vybrat peníze");
                Console.WriteLine("4. Zobrazit zůstatek");
                Console.WriteLine("5. Převod peněz");
                Console.WriteLine("6. Konec");
                Console.Write("Vyberte akci: ");
                string choice = Console.ReadLine();

                switch (choice)
                {
                    case "1": // Vytvoření účtu
                        Console.Write("Zadejte jméno klienta: ");
                        string clientName = Console.ReadLine();

                        Console.Write("Zadejte číslo účtu: ");
                        string accountNumber = Console.ReadLine();

                        Console.Write("Zadejte typ účtu (checking/savings/business): ");
                        string accountType = Console.ReadLine().ToLower();

                        try
                        {
                            Account newAccount = AccountFactory.CreateAccount(accountType, accountNumber);
                            if (!clients.ContainsKey(clientName))
                            {
                                clients[clientName] = new Client(clientName);
                            }
                            newAccount.Attach(clients[clientName]);
                            bank.AddAccount(newAccount);
                            Console.WriteLine($" Účet {accountNumber} ({accountType}) vytvořen pro klienta {clientName}.");
                        }
                        catch (ArgumentException ex)
                        {
                            Console.WriteLine(ex.Message);
                        }
                        break;

                    case "2": // Vklad
                        Console.Write("Zadejte číslo účtu: ");
                        string depositAccount = Console.ReadLine();
                        Console.Write("Zadejte částku k vkladu: ");
                        if (decimal.TryParse(Console.ReadLine(), out decimal depositAmount) && depositAmount > 0)
                        {
                            Account account = bank.GetAccount(depositAccount);
                            if (account != null)
                            {
                                account.Deposit(depositAmount);
                                Console.WriteLine($" Vloženo {depositAmount} Kč na účet {depositAccount}.");
                            }
                            else
                            {
                                Console.WriteLine(" Účet nenalezen.");
                            }
                        }
                        else
                        {
                            Console.WriteLine(" Neplatná částka.");
                        }
                        break;

                    case "3": // Výběr
                        Console.Write("Zadejte číslo účtu: ");
                        string withdrawAccount = Console.ReadLine();

                        Console.Write("Zadejte částku k výběru: ");
                        if (decimal.TryParse(Console.ReadLine(), out decimal withdrawAmount) && withdrawAmount > 0)
                        {
                            Account account = bank.GetAccount(withdrawAccount); 
                            if (account != null)
                            {
                                
                                account.Withdraw(withdrawAmount);
                            }
                            else
                            {
                                Console.WriteLine(" Účet nenalezen.");
                            }
                        }
                        else
                        {
                            Console.WriteLine(" Neplatná částka.");
                        }
                        break;

                    case "4": // Zobrazení zůstatku
                        Console.Write("Zadejte číslo účtu: ");
                        string balanceAccount = Console.ReadLine();
                        Account acc = bank.GetAccount(balanceAccount);
                        if (acc != null)
                        {
                            acc.ShowBalance();
                        }
                        else
                        {
                            Console.WriteLine(" Účet nenalezen.");
                        }
                        break;

                    case "5": // prevod na ucet
                        Console.Write("Zadejte číslo účtu odesílatele: ");
                        string fromAccountNumber = Console.ReadLine();

                        Console.Write("Zadejte číslo účtu příjemce: ");
                        string toAccountNumber = Console.ReadLine();

                        Console.Write("Zadejte částku k převodu: ");
                        if (decimal.TryParse(Console.ReadLine(), out decimal transferAmount) && transferAmount > 0)
                        {
                            bank.Transfer(fromAccountNumber, toAccountNumber, transferAmount);
                        }
                        else
                        {
                            Console.WriteLine("Neplatná částka.");
                        }
                        break;
                    case "6": // Konec programu
                        Console.WriteLine(" Ukončuji program...");

                        return;

                    default:
                        Console.WriteLine(" Neplatná volba. Zkuste to znovu.");
                        break;
                }
            }
        }

        }
    }
