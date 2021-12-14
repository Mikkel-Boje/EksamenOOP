using System;

namespace Stregsystemet {
    public class StregsystemetCLI : IStregsystemUI {
        public StregsystemetCLI(IStregsystem stregsystem) {
            _stregsystem = stregsystem;
            _stregsystem.UserBalanceWarning += DisplayBalanceWarning;
        }
        public void Start() {
            Console.WriteLine("Du kan \"saette streger\" foelgende maade:\n");
            Console.WriteLine("1. Indtast dit brugernavn og et produkt ID (adskilt med \"space\"). \n   Koebet vil blive direkte registreret uden yderligere input.\n");
            foreach (Product item in _stregsystem.ActiveProducts)
            {
                Console.WriteLine(item.ToString());
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
            throw new NotImplementedException();
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
    }
}