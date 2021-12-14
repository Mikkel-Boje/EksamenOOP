namespace Stregsystemet {
    public class StregsystemController {
        public StregsystemController(IStregsystem stregsystem, IStregsystemUI stregsystemUI) {
            _stregsystem = stregsystem;
            _stregsystemUI = stregsystemUI;
            _parser = new StregsystemCommandParser(this);
            _stregsystemUI.CommandEntered += CommandLogic;
        }
        public void CommandLogic(string command) {
            _parser.ParseCommand(command);
        }
        public void UserInfo(string username) {
            User user = _stregsystem.GetUserByUsername(username);
            _stregsystemUI.DisplayUserInfo(user);
        }

        private StregsystemCommandParser _parser { get; }
        private IStregsystem _stregsystem { get; }
        private IStregsystemUI _stregsystemUI { get; }
    }
}