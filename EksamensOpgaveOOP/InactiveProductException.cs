using System;

namespace Stregsystemet {
    public class InactiveProductExeption : Exception {
        public InactiveProductExeption(string Username, string ProductName) : base($"{Username} prøvede at købe {ProductName} men det var inaktivt") {
        }
    }
}