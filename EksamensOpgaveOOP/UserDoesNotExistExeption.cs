using System;

namespace Stregsystemet {
    public class UserDoesNotExistExeption : Exception {
        public UserDoesNotExistExeption(string Username) : base() {
            username = Username;
        }
        public string username { get; }
    }
}