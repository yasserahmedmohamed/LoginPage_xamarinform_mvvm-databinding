using System;
using System.Collections.Generic;
using System.Text;

namespace loginpage_mvvm.Model
{
    class UserData
    {

       private string username;
       private string password;
        public UserData() { }
        public UserData(string username, string password)
        {
            this.username = username;
            this.password = password;
        }
        public string UserName {
            get { return username; }
            set { username = value; }
        }
        public string Password {
            get { return password; }
            set { password = value; }
        }
    }
}
