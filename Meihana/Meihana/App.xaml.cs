using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Meihana.Services;
using Meihana.Views;

namespace Meihana
{
    public partial class App : Application
    {

        public App()
        {
            InitializeComponent();
            DependencyService.Register<MockDataStore>();
            DependencyService.Get<ISQLite>().GetConnection();
            MainPage = new AppShell();
            var isLogged = Xamarin.Essentials.SecureStorage.GetAsync("isLogged").Result;
            isLogged = "2";
            if (isLogged == "1")
            {
                MainPage = new AppShell();
            }
            else
            {
                MainPage = new LoginPage();
            }
        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
