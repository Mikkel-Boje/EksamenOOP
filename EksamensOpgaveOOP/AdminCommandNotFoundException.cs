using System;

namespace Stregsystemet {
    public class AdminCommandNotFoundException : Exception {
        public AdminCommandNotFoundException(string adminCommand) : base() {
            AdminCommand = adminCommand;
        }
        public string AdminCommand { get; }
    }
}