using System;

namespace Stregsystemet {
    public class InsufficientCreditsExeption : Exception {
        public InsufficientCreditsExeption(User user, Product product) : base() {
            Product = product;
            User = user;
        }
        public Product Product { get; }
        public User User { get; }
    }
}