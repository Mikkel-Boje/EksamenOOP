using System.Collections.Generic;
using System;
using System.IO;

namespace Stregsystemet {
    public delegate void UserBalanceNotification(User user, double balance);

    public class Stregsystem : IStregsystem {
        public Stregsystem() {
            products = GetProductsFromFile(); // Denne konstroktør er kun lavet idet at der er blevet givet filer med products/users
            users = GetUsersFromFile();
        }
        public BuyTransaction BuyProduct(User user, Product product) {
            BuyTransaction transaction = new BuyTransaction(user, product);
            return transaction;
        }
        public InsertCashTransaction AddCreditsToAccount(User user, double amount) {
            InsertCashTransaction transaction = new InsertCashTransaction(user, amount);
            return transaction;
        }
        public void ExecuteTransaction(Transaction transaction) {
            User user = transaction.User;
            transaction.Execute();
            transactions.Add(transaction);
            if(user.Balance <= 50) {
                UserBalanceWarning.Invoke(user, user.Balance);
            }
            try {
                string path = "Transaktioner.csv";
                StreamWriter file;
                if(!File.Exists(path)) {
                    using(file = File.CreateText(path))
                        file.WriteLine(transaction.ToString());
                }
                else {
                    using(file = File.AppendText(path))
                        file.WriteLine(transaction.ToString());
                }
            }
            catch {
                throw new Exception($"Der kunne ikke skrives til filen for transaktionen med ID: {transaction.ID} af {transaction.User}");
            }
        }
        public event UserBalanceNotification UserBalanceWarning;

        public Product GetProductByID(int ID) {
            foreach (Product product in products)
            {
                if(product.ID == ID)
                    return product;
            }
            throw new InvalidProductIDExeption<int>(ID);
        }
        public List<User> GetUsers(Predicate<User> predicate) {
            List<User> predicateUsers = new List<User>();
            foreach (User user in users)
            {
                if(predicate(user))
                    predicateUsers.Add(user);
            }
            return predicateUsers;
        }

        public User GetUserByUsername(string username) {
            foreach (User user in users)
            {
                if(user.Username == username)
                    return user;
            }
            throw new UserDoesNotExistExeption(username);
        }

        public IEnumerable<Transaction> GetTransactions(User user, int count) {
            List<Transaction> truncatedList = new List<Transaction>();
            for (int i = transactions.Count; i == transactions.Count - count; i--)
            {
                truncatedList.Add(transactions[i]);
            }
            return truncatedList;
        }
        public List<Product> GetProductsFromFile() {
            List<Product> productsInFile = new List<Product>();
            int counter = 0;
            string path = File.Exists("products.csv") ? "products.csv" : "../../../products.csv";
            if (File.Exists(path)) {
                foreach (string line in File.ReadLines(path)) {  
                    if(counter != 0) {
                        string[] strings = line.Split(";");
                        int id;
                        double price;
                        string name = strings[1];
                        bool isActive = strings[3] == "0" ? false : true;

                        if(name[0] == '"' && name[name.Length - 1] == '"') {
                            name = name.Remove(name.IndexOf('"'), 1);
                            name = name.Remove(name.LastIndexOf('"'), 1);
                        }
                        if(name[0] == '<') {
                            name = name.Remove(name.IndexOf('<'), name.IndexOf('>') + 1);
                            name = name.Remove(name.LastIndexOf('<'), name.LastIndexOf('>') - name.LastIndexOf('<') + 1);
                        }

                        if(int.TryParse(strings[0], out id)) {
                            if(double.TryParse(strings[2], out price)) {
                                price /= 100;
                                if(strings[4] != "") {
                                    strings[4] = strings[4].Remove(strings[4].IndexOf('"'), 1);
                                    strings[4] = strings[4].Remove(strings[4].LastIndexOf('"'), 1);
                                    productsInFile.Add(new SeasonalProduct(DateTime.Parse(strings[4]), DateTime.Parse(strings[4]), id, name, price, isActive, false));
                                }
                                else
                                    productsInFile.Add(new Product(id, name, price, isActive, false));
                            }
                        }
                    }
                    else counter++;
                }
                return productsInFile;
            }
            throw new FileNotFoundException();
        }

        public List<User> GetUsersFromFile() {
            List<User> usersInFile = new List<User>();
            int counter = 0;
            string path = File.Exists("users.csv") ? "users.csv" : "../../../users.csv";
            if (File.Exists(path)) {
                foreach (string line in File.ReadLines(path)) {  
                    if(counter != 0) {
                        string[] strings = line.Split(",");
                        int id;
                        double amount;
                        if(int.TryParse(strings[0], out id)) {
                            if(double.TryParse(strings[4], out amount)) {
                                amount /= 100;
                                try
                                {
                                    usersInFile.Add(new User(id, strings[1], strings[2], strings[3], amount, strings[5]));
                                }
                                catch (Exception)
                                {
                                    
                                    throw;
                                }
                            }
                        }
                    }
                    else counter++;
                }
                return usersInFile;
            }
            throw new FileNotFoundException();
        }

        public IEnumerable<Product> ActiveProducts 
        {
            get {
                List<Product> activeProducts = new List<Product>();
                foreach (Product product in products)
                {
                    if(product.Active == true)
                        activeProducts.Add(product);
                }
                return activeProducts;
            }
        }

        public static List<Product> products = new List<Product>();
        public static List<User> users = new List<User>();
        public static List<Transaction> transactions = new List<Transaction>();
    }
}