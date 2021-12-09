using System;

namespace Stregsystemet {
    public abstract class Transaction {
        public Transaction(User user, double amount) {
            ID = nextId;
            nextId++;
            Date = DateTime.Now;
            Amount = amount;
            User = user;
        }

        public override string ToString()
        {
            return $"{ID} {User} {Amount} {Date.ToString("dd/MM/yyyy hh:mm:ss")}";
        }

        public abstract void Execute();

        public int ID { get; init; }
        public User User 
        {
            get => _user;
            set => _user = value ?? throw new Exception();
        }
        public DateTime Date { get; }
        public double Amount { get; }

        private User _user;

        private static int nextId;
    }
}