using System;
using System.Text.RegularExpressions;

namespace Stregsystemet {
    public class User : IComparable<User> {
        public User(string firstname, string lastname, string username, double balance, string email) {
            ID = nextId;
            nextId++;
            userrx = new Regex(@"^[a-z0-9_]+$");
            emailrx = new Regex(@"^[a-zA-Z0-9_.-]+@[a-zA-Z0-9_]{1}[a-zA-Z0-9_.-]*[.]+[a-zA-Z0-9_.-]*[a-zA-Z0-9_]{1}$");
            Firstname = firstname;
            Lastname = lastname;
            Username = username;
            Balance = balance;
            Email = email;
        }
        public User(int id, string firstname, string lastname, string username, double balance, string email) {
            ID = id;
            nextId++;
            userrx = new Regex(@"^[a-z0-9_]+$");
            emailrx = new Regex(@"^[a-zA-Z0-9_.-]+@[a-zA-Z0-9_]{1}[a-zA-Z0-9_.-]*[.]+[a-zA-Z0-9_.-]*[a-zA-Z0-9_]{1}$");
            Firstname = firstname;
            Lastname = lastname;
            Username = username;
            Balance = balance;
            Email = email;
        }

        public override string ToString()
        {
            return $"{Firstname} {Lastname} ({Email})";
        }

        public int CompareTo(User user)
        {
            if(user != null)
                return this.ID.CompareTo(user.ID);
            return 1;
        }
        public override bool Equals(object compareUser)
        {
            User user = (User)compareUser;
            if(this.ID == user.ID)
                return true;
            return false;
        }
        public override int GetHashCode()
        {
            return HashCode.Combine(ID, Firstname);
        }

        public int ID { get; }
        public double Balance { get; set; }
        
        public string Firstname 
        {
            get => _firstname;
            init => _firstname = value ?? throw new Exception("Username kan ikke være null");
        }
        public string Lastname 
        {
            get => _lastname;
            set => _lastname = value ?? throw new Exception("Efternavn kan ikke være null");
        }
        public string Username
        {
            get => _username;
            init {
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
        
        private string _firstname;
        private string _lastname;
        private string _username;
        private string _email;

        private static Regex userrx;
        private static Regex emailrx;

        private static int _nextId = 0;
        private static int nextId
        {
            get => _nextId;
            set {
                if(_nextId < value) {
                    _nextId = value;
                }
            }
        }
        
    }
}