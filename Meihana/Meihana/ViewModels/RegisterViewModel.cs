using Meihana.Models;
using Meihana.Views;
using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;
using Meihana.Infrastructure;
namespace Meihana.ViewModels
{
    public class RegisterViewModel : BaseViewModel
    {
        public Command RegisterCommand { get; }
        public RegisterViewModel()
        {
            RegisterCommand = new Command(OnRegisterClicked);
        }

        private async void OnRegisterClicked(object obj)
        {
            // Prefixing with `//` switches to a different navigation stack instead of pushing to the active one
            await Shell.Current.GoToAsync("..");
        }
    }
}
