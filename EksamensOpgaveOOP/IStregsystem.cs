using System.Collections.Generic;
using System;

namespace Stregsystemet {
    public interface IStregsystem {
        IEnumerable<Product> ActiveProducts { get; }
        InsertCashTransaction AddCreditsToAccount(User user, double amount);
        BuyTransaction BuyProduct(User user, Product product);
        Product GetProductByID(int id);
        IEnumerable<Transaction> GetTransactions(User user, int count);
        List<User> GetUsers(Predicate<User> predicate);
        User GetUserByUsername(string username);
        void ExecuteTransaction(Transaction transaction);
        event UserBalanceNotification UserBalanceWarning;
    }
}