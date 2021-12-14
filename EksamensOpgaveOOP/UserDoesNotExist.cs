using System;

namespace Stregsystemet {
    public class UserDoesNotExist : Exception {
        public UserDoesNotExist(string Username) : base($"Der findes ingen bruger med navnet: {Username}") {
        }
    }
}