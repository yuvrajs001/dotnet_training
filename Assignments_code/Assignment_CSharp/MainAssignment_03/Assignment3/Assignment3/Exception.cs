using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment3
{
    public class ZeroBalance: Exception
    {

        public ZeroBalance(string message) : base(message) { }
    }



    public class Account
    {
        private double balance;

        public void Deposit(double amount)
        {
            if (amount <= 0) throw new ArgumentException("Deposit must be greater than zero.");
            balance += amount;
            Console.WriteLine($"Deposited: ${amount}. Current Balance: ${balance}");
        }



        public void Withdraw(double amount)
        {
            if (amount <= 0) throw new ArgumentException("Withdrawal must be greater than zero.");

            if (amount > balance) throw new ZeroBalance("Insufficient balance for your withdrawal.");


            balance -= amount;

            Console.WriteLine($"Withdrawn: ${amount}. Current Balance: ${balance}");
        }

        public double CheckBalance() => balance;
    }


    class Exceptionn
    {
        static void Main()
        {
            Account acc = new Account();

            try
            {
                acc.Deposit(1000);
                acc.Withdraw(500);
                double balance = acc.CheckBalance();
                Console.WriteLine($"Current Balance: ${balance}");
            }
            catch (ArgumentException ex) { Console.WriteLine($"Error: {ex.Message}"); }
            catch (ZeroBalance ex) { Console.WriteLine($"Error: {ex.Message}"); }
            catch (Exception ex) { Console.WriteLine($"Unexpected Error occured: {ex.Message}"); }
            Console.ReadKey();
        }

    }
}
