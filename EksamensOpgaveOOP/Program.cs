using System;

namespace Stregsystemet {
    class Program {
        static void Main(string[] args){
            User user = new User("Mikkel", "Larsen", "mikkelboje", "Mikkel.Larsen@stofanet.dk");
            Product product = new Product("Cola", 12.5, true);
            Console.WriteLine(user.ToString());
            Console.WriteLine(product.ToString());
        }
    }
}
