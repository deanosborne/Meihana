using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Meihana.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using SQLite;
using Meihana.Services;
using Meihana.Models;
using Meihana.Helper;
using System.Diagnostics;

namespace Meihana.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class RegisterPage : ContentPage//, Behavior<Entry>
    {
        User users = new User();
        UserDB userDB = new UserDB();
        public RegisterPage()
        {
            InitializeComponent();
            NavigationPage.SetHasBackButton(this, false);
            userNameEntry.ReturnCommand = new Command(() => passwordEntry.Focus());
            passwordEntry.ReturnCommand = new Command(() => confirmpasswordEntry.Focus());
        }

        private async void Back_ButtonClicked(object sender, EventArgs e)
        {
            await Navigation.PopModalAsync();
        }
        private async void SignupValidation_ButtonClicked(object sender, EventArgs e)
        {
            if (!(!string.IsNullOrWhiteSpace(userNameEntry.Text) &&
             !string.IsNullOrWhiteSpace(passwordEntry.Text) &&
             !string.IsNullOrEmpty(userNameEntry.Text) &&
             !string.IsNullOrEmpty(passwordEntry.Text)))
            {
                await DisplayAlert("Oops", "Please enter all details", "OK");
            }
            else if (!string.Equals(passwordEntry.Text, confirmpasswordEntry.Text))
            {
                warningLabel.Text = "Password is not the same";
                passwordEntry.Text = string.Empty;
                confirmpasswordEntry.Text = string.Empty;
                warningLabel.TextColor = Color.IndianRed;
                warningLabel.IsVisible = true;
            }
            else
            {
                users.Email = userNameEntry.Text;
                users.Password = passwordEntry.Text;
                try
                {
                    var retrunvalue = userDB.AddUser(users);
                    if (retrunvalue == "Sucessfully Added")
                    {
                        await Navigation.PopModalAsync();
                    }
                    else
                    {
                        await DisplayAlert("Oops", "Try Again", "OK");
                        warningLabel.IsVisible = false;
                        userNameEntry.Text = string.Empty;
                        passwordEntry.Text = string.Empty;
                        confirmpasswordEntry.Text = string.Empty;
                    }
                }
                catch (Exception ex)
                {
                    Debug.WriteLine(ex);
                }
            }
        }
    }
}