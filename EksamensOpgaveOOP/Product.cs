using System;

namespace Stregsystemet {
    public class Product {
        public Product(string name, double price, bool isActive) {
            id = nextId;
            nextId++;
            this._name = name;
            this.price = price;
            this.active = isActive;
        }

        public override string ToString()
        {
            return $"{id} {name} {price} {active} {canBeBoughtOnCredit}";
        }

        public bool active;
        public bool canBeBoughtOnCredit;
        public int id 
        {
            get => _id;
            init { _id = value; }
        }
        public double price 
        {
            get => _price;
            set {
                _price = value >= 0 ? value : throw new Exception($"Price of {this.name} was set incorrectly");
            }
        }
        public string name 
        {
            get => _name;
            set => _name = value ?? throw new Exception();
        }

        private int _id;
        private double _price;
        private string _name;

        private static int nextId;
    }
}