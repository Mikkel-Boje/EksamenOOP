namespace Stregsystemet {
    public interface IStregsystemUI {
        void DisplayUserNotFound(string username);
        //void DisplayProductNotFound(string product); lavet om til DisplayProductDoesNotExist
        void DisplayUserInfo(User user);
        void DisplayTooManyArgumentsError(string command);
        void DisplayAdminCommandNotFoundMessage(string adminCommand);
        void DisplayUserBuysProduct(BuyTransaction transaction);
        void DisplayUserBuysProduct(int count, BuyTransaction transaction);
        void Close();
        void DisplayInsufficientCash(User user, Product product);
        void DisplayGeneralError(string errorString);
        void Start();
        event StregsystemEvent CommandEntered;

        //Ektra functionaliteter
        void DisplayInvalidProductID<T>(T productID);
        void DisplayInactiveProduct(string productName);
        void Wipe();
    }
}