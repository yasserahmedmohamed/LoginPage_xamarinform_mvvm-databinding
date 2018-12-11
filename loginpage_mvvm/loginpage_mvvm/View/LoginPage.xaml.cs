using loginpage_mvvm.Interfaces;
using loginpage_mvvm.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace loginpage_mvvm.ViewModel
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class LoginPage : ContentPage, LoginInterfaceResponce
    {
        public LoginPage()
        {
            InitializeComponent();
            BindingContext = new LoginViewModel(this);
        }

        public void loginerror(ErrorEnum error_message)
        {
            string message;
            switch (error_message)
            {
                case  ErrorEnum.invalid_password:
                    {
                        message = "Enter right password";
                        break;
                    }
                case ErrorEnum.invalid_username:
                    {
                        message = "Enter right Username";
                        break;
                    }
                case ErrorEnum.less_5:
                    {
                        message = "password is Less than 5";
                        break;
                    }
                case ErrorEnum.notin_email_format:
                    {
                        message = "Not Valid Format";
                        break;
                    }
                case ErrorEnum.password_nullorwhitespace:
                    {
                        message = "Enter Password";
                        break;
                    }
                case ErrorEnum.username_nullorwhitespace:
                    {
                        message = "Enter UserName";
                        break;
                    }
                default:
                    {
                        message = "Thank You";
                        break;
                    }       
            }
            DisplayAlert("Alert", message, "Ok");
        }
    }
}