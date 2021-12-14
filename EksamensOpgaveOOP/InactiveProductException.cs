using System;

namespace Stregsystemet {
    public class InactiveProductExeption : Exception {
        public InactiveProductExeption(string productName) : base() {
            ProductName = productName;
        }
        public string ProductName { get; }
    }
}