using System;

namespace Stregsystemet {
    public class InvalidProductIDExeption<T> : Exception {
        public InvalidProductIDExeption(T id) : base() {
            ID = id;
        }
        public T ID { get; }
    }
}