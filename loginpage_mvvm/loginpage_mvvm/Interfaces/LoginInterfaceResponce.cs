using loginpage_mvvm.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace loginpage_mvvm.Interfaces
{
    interface LoginInterfaceResponce
    {
         void loginerror(ErrorEnum error_message);
    }
}
