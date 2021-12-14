using System;

namespace Stregsystemet {
    public class Product {
        public Product(string name, double price, bool isActive, bool canBeBoughtOnCredit) {
            ID = nextId;
            nextId++;
            Name = name;
            Price = price;
            Active = isActive;
            CanBeBoughtOnCredit = canBeBoughtOnCredit;
        }
        public Product(int id, string name, double price, bool isActive, bool canBeBoughtOnCredit) {
            ID = id;
            nextId = id + 1;
            Name = name;
            Price = price;
            Active = isActive;
            CanBeBoughtOnCredit = canBeBoughtOnCredit;
        }

        public override string ToString()
        {
            return $"{ID, -5}|{Name, -50}|{Price, -10} kr.";
        }

        public bool Active;
        public bool CanBeBoughtOnCredit;
        public int ID { get; init; }
        public double Price 
        {
            get => _price;
            set {
                _price = value >= 0 ? value : throw new Exception($"Price of {this.Name} was set incorrectly");
            }
        }
        public string Name 
        {
            get => _name;
            set => _name = value ?? throw new Exception();
        }

        private double _price;
        private string _name;

        private static int nextId 
        {
            get => _nextId;
            set {
                if(_nextId < value) {
                    _nextId = value;
                }
            }
        }
        private static int _nextId = 0;
    }
}