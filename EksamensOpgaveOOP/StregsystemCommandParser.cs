namespace Stregsystemet {
    public class StregsystemCommandParser {
        public StregsystemCommandParser(StregsystemController controller) {
            _controller = controller;
        }
        public void ParseCommand(string command) {
            if(command == "")
                throw new System.Exception("No command entered");

            if(command.IndexOf(":") == 0)
                ParseAdminCommand(command);
            
            string[] commandParts = command.Split(" ");
            
            if(commandParts.Length > 3)
                throw new TooManyArgsException(command);

            switch (commandParts.Length)
            {
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
                    throw new System.Exception("Forkert kvantitet i multibuy");
                default:
                    throw new System.Exception();
            }
        }
        private void ParseAdminCommand(string command) {
            
        }

        private StregsystemController _controller;
    }
}