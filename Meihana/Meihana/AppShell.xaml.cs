using System;
using System.Collections.Generic;
using Meihana.ViewModels;
using Meihana.Views;
using Xamarin.Forms;

namespace Meihana
{
    public partial class AppShell : Xamarin.Forms.Shell
    {
        public AppShell()
        {
            InitializeComponent();
            Routing.RegisterRoute("itemdetailpage", typeof(ItemDetailPage));
            Routing.RegisterRoute("newitempage", typeof(NewItemPage));
            Routing.RegisterRoute(nameof(RegisterPage), typeof(RegisterPage));
        }

        private async void OnMenuItemClicked(object sender, EventArgs e)
        {
            await Shell.Current.GoToAsync("//LoginPage");
        }
    }
}
