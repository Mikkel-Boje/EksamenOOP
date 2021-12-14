using System;

namespace Stregsystemet {
    public class InsertCashTransaction : Transaction {
        public InsertCashTransaction(User user, double amount) : base(user, amount) {
        }

        public override string ToString()
        {
            return "Indbetaling: " + base.ToString();
        }

        public override void Execute()
        {
            this.User.Balance += Amount;
        }
    }
}