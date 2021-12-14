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

        public void Close() {
            running = false;
        }

        public void DisplayAdminCommandNotFoundMessage(string adminCommand)
        {
            ExeptionDisplay($"Admin commad: {adminCommand} was not found");
        }

        public void DisplayGeneralError(string errorString) {
            if(errorString == "") ExeptionDisplay("Noget gik galt");
            else ExeptionDisplay(errorString);
        }

        public void DisplayInsufficientCash(User user, Product product) {
            ExeptionDisplay($"{user.Username} har ikke nok stregdollars til at koebe {product.Name}");
        }

        public void DisplayTooManyArgumentsError(string command) {
            ExeptionDisplay($"Commandoen havde for mange argumenter: {command}");
        }

        public void DisplayUserBuysProduct(BuyTransaction transaction) {
            ExeptionDisplay($"{transaction.User.Username} koebte {transaction.Product.Name} til {transaction.Amount} kr.");
        }

        public void DisplayUserBuysProduct(int count, BuyTransaction transaction) {
            ExeptionDisplay($"{transaction.User.Username} koebte {count} {transaction.Product.Name} til {transaction.Amount * count} kr. i alt, {transaction.Amount} kr. stk.");
        }

        public void DisplayUserInfo(User user) {
            Console.Clear();
            Console.WriteLine($"Username   : {user.Username}\nFulde navn : {user.Firstname} {user.Lastname}\nSaldo      : {user.Balance} kr.\n");
            foreach (Transaction item in _stregsystem.GetTransactions(user, 10)) {
                if(item is BuyTransaction) {
                    Console.WriteLine(item);
                }
            }
            if(user.Balance < 50) {
                Console.WriteLine("Din saldo er under 50!");
                Console.WriteLine("Tryk paa en knap for at forsaette");
            } 
            Console.ReadKey();
        }

        public void DisplayUserNotFound(string username) {
            ExeptionDisplay($"Der findes ingen bruger med navnet: {username}");
        }

        public void DisplayInvalidProductID<T>(T productID) {
            ExeptionDisplay($"Der findes intet produkt med id: {productID}");
        }
        
        public void DisplayInactiveProduct(string productName) {
            ExeptionDisplay($"Produktet {productName} er ikke aktivt");
        }

        public void DisplayBalanceWarning(User user, double balance) {
            Console.WriteLine($"WARNING: {user.Username} har mindre end 50 kr. tilbage på stregkontoen");
        }

        public void Wipe() {
            Console.Clear();
        }

        private void ExeptionDisplay(string text) {
            Console.WriteLine(text);
            Console.WriteLine("Tryk paa en knap for at fortsaette");
            Console.ReadKey();
        }

        public event StregsystemEvent CommandEntered;
        private IStregsystem _stregsystem;
        public bool running = true;
    }
}