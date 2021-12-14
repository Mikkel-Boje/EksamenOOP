namespace Stregsystemet {
    public class BuyTransaction : Transaction {
        public BuyTransaction(User user, Product product) : base(user, product.Price) {
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
                else throw new InsufficientCreditsExeption(User, Product);
            }
            else throw new InactiveProductExeption(Product.Name);
        }

        public Product Product { get; }
    }
}