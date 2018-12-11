using loginpage_mvvm.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace loginpage_mvvm.Services
{
    class GetUserDataService
    {
        public UserData getuserdata() {
            return new UserData("tt@rt.com", "123456");

        }
    }
}
