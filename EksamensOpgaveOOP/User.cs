using System;
using System.Linq;
using System.Text.RegularExpressions;

namespace Stregsystemet {
    public class User {
        public User(string firstname, string lastname, string username, string email) {
            ID = nextId;
            nextId++;
            userrx = new Regex(@"^[a-z0-9_]+$");
            emailrx = new Regex(@"^[a-zA-Z0-9_.-]+@[a-zA-Z0-9_]{1}[a-zA-Z0-9_.-]*[.]+[a-zA-Z0-9_.-]*[a-zA-Z0-9_]{1}$");
            Firstname = firstname;
            Lastname = lastname;
            Username = username;
            Email = email;
        }

        public override string ToString()
        {
            return $"{ID} {Firstname} {Lastname} {Username} {Email} {Balance}";
        }

        public int ID { get; init; }
        public double Balance 
        {
            get => _balance;
            set {
                _balance = value;
                if(_balance <= 50) {
                    //UserBalanceNotification(User user, double balance)
                }
            }
        }
        public string Firstname 
        {
            get => _firstname;
            set => _firstname = value ?? throw new Exception();
        }
        public string Lastname 
        {
            get => _lastname;
            set => _lastname = value ?? throw new Exception();
        }
        public string Username
        {
            get => _username;
            set {
                MatchCollection match = userrx.Matches(value);
                if(match.Count != 0) {
                    _username = value;
                }
                else throw new Exception();
            }
        }
        public string Email
        {
            get => _email;
            set {
                MatchCollection match = emailrx.Matches(value);
                if(match.Count != 0) {
                    _email = value;
                }
                else throw new Exception();
            }
        }
        
        private double _balance;
        private string _firstname;
        private string _lastname;
        private string _username;
        private string _email;

        private static Regex userrx;
        private static Regex emailrx;

        private static int nextId = 0;
    }
}