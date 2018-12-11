using loginpage_mvvm.Interfaces;
using loginpage_mvvm.Model;
using loginpage_mvvm.Services;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Globalization;
using System.Runtime.CompilerServices;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows.Input;
using Xamarin.Forms;

namespace loginpage_mvvm.ViewModel
{
    class LoginViewModel : INotifyPropertyChanged
    {
       public LoginPage loginPage { get; set; }
      private  UserData _user;
        
        public UserData user {
            get { return _user; }
            set { _user = value;  }
        }

        private string username;
        public string Username {

            get { return username; }
            set { username = value;
                onPropertyChanged();
            }
        }
        private string password;
        public string Password
        {

            get { return password; }
            set
            {
                password = value;
                onPropertyChanged();
            }
        }
       public ICommand loginbuttoncommand { get; set; }
        public LoginViewModel(LoginPage loginPage)
        {
            this.loginPage = loginPage;
            var userdata = new GetUserDataService();
            user = userdata.getuserdata();
            loginbuttoncommand = new Command(loginclicked);
        }


        public void loginclicked()
        {
            if (string.IsNullOrEmpty(Username) || string.IsNullOrWhiteSpace(username))
            {
                loginPage.loginerror(ErrorEnum.username_nullorwhitespace);
            }
            else if (!IsValidEmail(Username))
            {
                loginPage.loginerror(ErrorEnum.notin_email_format);

            }
            else if (string.IsNullOrEmpty(Password) || string.IsNullOrWhiteSpace(Password))
            {
                loginPage.loginerror(ErrorEnum.password_nullorwhitespace);

            }
            else if (Password.Length < 5)
            {
                loginPage.loginerror(ErrorEnum.less_5);

            }
            else if (!Username.Equals(user.UserName))
            {
                loginPage.loginerror(ErrorEnum.invalid_username);

            }
            else if (!Password.Equals(user.Password))
            {
                loginPage.loginerror(ErrorEnum.invalid_password);

            }
            else {
                loginPage.loginerror(ErrorEnum.done);

            }

        }
        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void onPropertyChanged([CallerMemberName]string propertyname = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyname));
        }
        public static bool IsValidEmail(string email)
        {
            if (string.IsNullOrWhiteSpace(email))
                return false;

            try
            {
                // Normalize the domain
                email = Regex.Replace(email, @"(@)(.+)$", DomainMapper,
                                      RegexOptions.None, TimeSpan.FromMilliseconds(200));

                // Examines the domain part of the email and normalizes it.
                string DomainMapper(Match match)
                {
                    // Use IdnMapping class to convert Unicode domain names.
                    var idn = new IdnMapping();

                    // Pull out and process domain name (throws ArgumentException on invalid)
                    var domainName = idn.GetAscii(match.Groups[2].Value);

                    return match.Groups[1].Value + domainName;
                }
            }
            catch (RegexMatchTimeoutException e)
            {
                return false;
            }
            catch (ArgumentException e)
            {
                return false;
            }

            try
            {
                return Regex.IsMatch(email,
                    @"^(?("")("".+?(?<!\\)""@)|(([0-9a-z]((\.(?!\.))|[-!#\$%&'\*\+/=\?\^`\{\}\|~\w])*)(?<=[0-9a-z])@))" +
                    @"(?(\[)(\[(\d{1,3}\.){3}\d{1,3}\])|(([0-9a-z][-0-9a-z]*[0-9a-z]*\.)+[a-z0-9][\-a-z0-9]{0,22}[a-z0-9]))$",
                    RegexOptions.IgnoreCase, TimeSpan.FromMilliseconds(250));
            }
            catch (RegexMatchTimeoutException)
            {
                return false;
            }
        }
    }
}
