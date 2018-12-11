using System;
using System.Collections.Generic;
using System.Text;

namespace loginpage_mvvm.Model
{
  public  enum ErrorEnum
    {
        //user name value is null or its spaces
        username_nullorwhitespace,
        //user name value is not in format
        notin_email_format,
        // password is  null or its spaces
        password_nullorwhitespace,
        // password is less than 5
        less_5,
        invalid_username,
        invalid_password,
        done

    }
}
