namespace Stregsystemet {
    public class StregsystemController {
        public StregsystemController(IStregsystem stregsystem, IStregsystemUI stregsystemUI) {
            _stregsystem = stregsystem;
            _stregsystemUI = stregsystemUI;
            _parser = new StregsystemCommandParser(this);
            _stregsystemUI.CommandEntered += CommandLogic;
        }
        public void CommandLogic(string command) {
           try {
                _parser.ParseCommand(command);
           }
           catch (UserDoesNotExistExeption e) {
               _stregsystemUI.DisplayUserNotFound(e.username);
            }
           catch (InvalidProductIDExeption<string> e) {
               _stregsystemUI.DisplayInvalidProductID(e.ID);
           }
           catch (InvalidProductIDExeption<int> e) {
               _stregsystemUI.DisplayInvalidProductID(e.ID);
           }
           catch (InactiveProductExeption e) {
               _stregsystemUI.DisplayInactiveProduct(e.ProductName);
           }
           catch (InsufficientCreditsExeption e) {
               _stregsystemUI.DisplayInsufficientCash(e.User, e.Product);
           }
           catch (TooManyArgsException e) {
               _stregsystemUI.DisplayTooManyArgumentsError(e.Commad);
           }
           catch (System.Exception e) {
               _stregsystemUI.DisplayGeneralError(e.Message);
           }
        }
        public void UserInfo(string username) {
            User user = _stregsystem.GetUserByUsername(username);
            _stregsystemUI.DisplayUserInfo(user);
        }
        public void BuyProduct(string username, string productID) {
            int intProductID;
            User user = _stregsystem.GetUserByUsername(username);
            if(int.TryParse(productID, out intProductID)) {
                Product product = _stregsystem.GetProductByID(intProductID);
                BuyTransaction transaction = new BuyTransaction(user, product);
                transaction.Execute();
                _stregsystemUI.DisplayUserBuysProduct(transaction);
            }
            else throw new InvalidProductIDExeption<string>(productID);
        }
        public void MultiBuyProduct(string username, int quantity, string productID) {
            int intProductID;
            User user = _stregsystem.GetUserByUsername(username);
            if(int.TryParse(productID, out intProductID)) {
                Product product = _stregsystem.GetProductByID(intProductID);
                product.Price *= quantity;
                BuyTransaction transaction = new BuyTransaction(user, product);
                transaction.Execute();
                _stregsystemUI.DisplayUserBuysProduct(quantity, transaction);
            }
            else throw new InvalidProductIDExeption<string>(productID);
        }


        private StregsystemCommandParser _parser { get; }
        private IStregsystem _stregsystem { get; }
        private IStregsystemUI _stregsystemUI { get; }
    }
}