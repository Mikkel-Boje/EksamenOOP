using System;

namespace Stregsystemet {
    public class BuyTransaction : Transaction {
        public BuyTransaction(User user, Product product, double amount) : base(user, amount) {
            Product = product;
        }

        public override string ToString()
        {
            return "Udbetalt:" + base.ToString();
        }

        public override void Execute()
        {
            if(Product.Active) {
                if(User.Balance > Amount)
                    User.Balance -= Amount;
                else 
                    throw new InsufficientCreditsExeption(User.Username, Product.Name);
            }
            else
                throw new InactiveProductExeption(User.Username, Product.Name);
        }

        public Product Product { get; }
    }
}