using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Meihana.Helper;
using Meihana.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Meihana.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class LoginPage : ContentPage
    {
        UserDB userData;
        public LoginPage()
        {
            InitializeComponent();
            userData = new UserDB();
            NavigationPage.SetHasBackButton(this, false);
            userNameEntry.ReturnCommand = new Command(() => passwordEntry.Focus());
            firstPassword.ReturnCommand = new Command(() => secondPassword.Focus());
        }

        string logesh;
        private async void userIdCheckEvent(object sender, EventArgs e)
        {
            if ((string.IsNullOrWhiteSpace(useridValidationEntry.Text)) || (string.IsNullOrWhiteSpace(useridValidationEntry.Text)))
            {
                await DisplayAlert("Oops", "Please enter all details", "OK");
            }
            else
            {
                logesh = useridValidationEntry.Text;
                var textresult = userData.updateUserValidation(useridValidationEntry.Text);
                if (textresult)
                {
                    popupLoadingView.IsVisible = false;
                    passwordView.IsVisible = true;
                }
                else
                {
                    await DisplayAlert("Oops", "Please enter all details", "OK");
                }
            }
        }
        private async void Password_ClickedEvent(object sender, EventArgs e)
        {
            if (!string.Equals(firstPassword.Text, secondPassword.Text))
            {
                warningLabel.Text = "Enter password again";
                warningLabel.TextColor = Color.IndianRed;
                warningLabel.IsVisible = true;
            }
            else if ((string.IsNullOrWhiteSpace(firstPassword.Text)) || (string.IsNullOrWhiteSpace(secondPassword.Text)))
            {
                await DisplayAlert("Oops", " Enter Password", "OK");
            }
            else
            {
                try
                {
                    var return1 = userData.updateUser(logesh, firstPassword.Text);
                    passwordView.IsVisible = false;
                    if (return1)
                    {
                        await DisplayAlert("Password Updated", "User Data updated", "OK");
                    }
                }
                catch (Exception)
                {
                    throw;
                }
            }
        }
        private async void LoginValidation_ButtonClicked(object sender, EventArgs e)
        {
            if (userNameEntry.Text != null && passwordEntry.Text != null)
            {
                var validData = userData.LoginValidate(userNameEntry.Text, passwordEntry.Text);
                if (validData)
                {
                    popupLoadingView.IsVisible = false;
                    await Xamarin.Essentials.SecureStorage.SetAsync("isLogged", "1");
                    Application.Current.MainPage = new AppShell();
                    await Shell.Current.GoToAsync($"//{nameof(AboutPage)}");
                }
                else
                {
                    popupLoadingView.IsVisible = false;
                    await DisplayAlert("Login Failed", "Username or Password Incorrect", "OK");
                }
            }
            else
            {
                popupLoadingView.IsVisible = false;
                await DisplayAlert("Oops", "Please enter all details", "OK");
            }
        }

        private async void Register_ButtonClicked(object sender, EventArgs e)
        {
            await Navigation.PushModalAsync(new RegisterPage());
        }
    }
}