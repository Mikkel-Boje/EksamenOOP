using System;

namespace Stregsystemet {
    public class ProductDoesNotExist : Exception {
        public ProductDoesNotExist(int ID) : base($"Produktet med id {ID} findes ikke") {
        }
    }
}