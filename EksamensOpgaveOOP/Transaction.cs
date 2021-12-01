using System;

namespace Stregsystemet {
    public class Transaction {
        public Transaction() {
            id = nextId;
            nextId++;
        }
        public int id 
        {
            get => _id;
            init { _id = value; }
        }
        private int _id;
        private static int nextId;
    }
}