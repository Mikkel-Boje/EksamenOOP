using System;

namespace Stregsystemet {
    public class InsufficientCreditsExeption : Exception {
        public InsufficientCreditsExeption(string Username, string ProductName) : base($"{Username} har ikke nok stregdollors til at købe {ProductName}") {
        }
    }
}