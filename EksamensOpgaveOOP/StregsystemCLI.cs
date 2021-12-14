using System;

namespace Stregsystemet {
    public delegate void StregsystemEvent(string command);

    public class StregsystemetCLI : IStregsystemUI {
        public StregsystemetCLI(IStregsystem stregsystem) {
            _stregsystem = stregsystem;
            _stregsystem.UserBalanceWarning += DisplayBalanceWarning;
        }
        public void Start() {
            while (running)
            {
                Console.Clear();
                Console.WriteLine("Stregsystemet");
                Console.WriteLine("Du kan \"saette streger\" foelgende maade:");
                Console.WriteLine("1. Indtast dit brugernavn og et produkt ID (adskilt med \"space\"). \n   Koebet vil blive direkte registreret uden yderligere input.");
                foreach (Product item in _stregsystem.ActiveProducts)
                {
                    Console.WriteLine(item.ToString());
                }
                Console.Write("\nQuickbuy: ");
                CommandEntered.Invoke(Console.ReadLine());
            }
        }

        public void Close()
        {
            throw new NotImplementedException();
        }

        public void DisplayAdminCommandNotFoundMessage(string adminCommand)
        {
            throw new NotImplementedException();
        }

        public void DisplayGeneralError(string errorString)
        {
            throw new NotImplementedException();
        }

        public void DisplayInsufficientCash(User user, Product product)
        {
            throw new NotImplementedException();
        }

        public void DisplayProductNotFound(string product)
        {
            throw new NotImplementedException();
        }

        public void DisplayTooManyArgumentsError(string command)
        {
            throw new NotImplementedException();
        }

        public void DisplayUserBuysProduct(BuyTransaction transaction)
        {
            throw new NotImplementedException();
        }

        public void DisplayUserBuysProduct(int count, BuyTransaction transaction)
        {
            throw new NotImplementedException();
        }

        public void DisplayUserInfo(User user)
        {
            Console.Clear();
            Console.WriteLine($"Username   : {user.Username}\nFulde navn : {user.Firstname} {user.Lastname}\nSaldo      : {user.Balance} kr.\n");
            foreach (Transaction item in _stregsystem.GetTransactions(user, 10))
            {
                if(item is BuyTransaction) {
                    Console.WriteLine(item);
                }
            }
            if(user.Balance < 50) 
                Console.WriteLine("Din saldo er under 50!");
            Console.WriteLine("Tryk paa en knap for at forsaette");
            Console.ReadKey();
        }

        public void DisplayUserNotFound(string username)
        {
            throw new NotImplementedException();
        }
        public event StregsystemEvent CommandEntered;

        public void DisplayBalanceWarning(User user, double balance) {
            Console.WriteLine($"{user} har mindre end 50 kr. tilbage på stregkontoen");
        }
        private IStregsystem _stregsystem;
        public bool running = true;
    }
}