namespace Stregsystemet {
    public class StregsystemCommandParser {
        public StregsystemCommandParser(StregsystemController controller) {
            _controller = controller;
        }
        public void ParseCommand(string command) {
            if(command == "")
                throw new System.Exception("No command entered");
            string[] commandParts = command.Split(" ");

            switch (commandParts.Length)
            {
                case 1:
                    _controller.UserInfo(commandParts[0]);
                    break;
                case 2:
                    //Buy single product
                    break;
                case 3:
                    //Multibuy
                    break;
                default:
                    throw new System.Exception("Something went wrong");
            }
        }
        private StregsystemController _controller;
    }
}