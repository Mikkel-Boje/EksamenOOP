using System;

namespace Stregsystemet {
    public class Product {
        public Product(string name, double price) {
            id = nextId;
            nextId++;
            this._name = name;
            this.price = price;
        }

        public double price 
        {
            get => _price;
            set {
                _price = value >= 0 ? value : throw new Exception($"Price of {this.name} was set incorrectly");
            }
        }

        public int id 
        {
            get => _id;
            init { _id = value; }
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