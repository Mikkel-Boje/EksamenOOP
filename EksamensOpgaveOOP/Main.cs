using System;

namespace Stregsystemet {
    public class User {
        public void User(int id, string firstname, string lastname, string username, string email) {
            id = this.id;
            firstname = this.firstname;
            lastname = this.lastname;
            username = this.username;
            email = this.email;
        }

        private int _id;
        int id 
        { 
            get => _id;
            set {
                //Validation of id
            }
        }
    }
}