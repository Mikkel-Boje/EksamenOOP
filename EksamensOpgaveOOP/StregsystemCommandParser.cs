using System.Collections.Generic;
using System;

namespace Stregsystemet {
    public class StregsystemCommandParser {
        public StregsystemCommandParser(StregsystemController controller) {
            _controller = controller;
            SetupAdminCommands();
        }
        public void ParseCommand(string command) {
            if(command == "")
                throw new Exception("No command entered");

            string[] commandParts = command.Split(" ");
            
            if(commandParts.Length > 3)
                throw new TooManyArgsException(command);

            if(command.IndexOf(":") == 0)
                ParseAdminCommand(commandParts);
            else {
                switch (commandParts.Length) {
                    case 1:
                        _controller.UserInfo(commandParts[0]);
                        break;
                    case 2:
                        _controller.BuyProduct(commandParts[0], commandParts[1]);
                        break;
                    case 3:
                        int quantity;
                        if(int.TryParse(commandParts[1], out quantity)) {
                            _controller.MultiBuyProduct(commandParts[0], quantity, commandParts[2]);
                            break;
                        }
                        throw new Exception("Forkert kvantitet i multibuy");
                    default:
                        throw new Exception();
                }
            }
            
        }
        private void ParseAdminCommand(string[] command) {
            Action<string[]> actions;
            if(adminCommands.TryGetValue(command[0], out actions)) {
                actions(command);
            }
        }
        private void SetupAdminCommands() {
            adminCommands.Add(":q", (_) => _controller.Close());
            adminCommands.Add(":quit", (_) => _controller.Close());
            adminCommands.Add(":activate", (command) => _controller.Activate(command[1], true));
            adminCommands.Add(":deactivate", (command) => _controller.Activate(command[1], false));
            adminCommands.Add(":crediton", (command) => _controller.Credit(command[1], true));
            adminCommands.Add(":creditoff", (command) => _controller.Credit(command[1], false));
            adminCommands.Add(":addcredits", (command) => _controller.AddCredit(command[1], command[2]));
        }
        Dictionary<string, Action<string[]>> adminCommands = new Dictionary<string, Action<string[]>>();
        private StregsystemController _controller;
    }
}