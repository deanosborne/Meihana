using System;
using System.ComponentModel;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Meihana.Views
{
    public partial class AboutPage : ContentPage
    {
        public AboutPage()
        {
            InitializeComponent();
        }

        private async void nzno_Tapped(object sender, EventArgs e)
        {
            await Browser.OpenAsync("https://www.nzno.org.nz/Portals/0/Files/Documents/Groups/Gerontology/Conference%20and%20BGM/2018%20Presentations/Ashleigh%20Wiley%20-%20Meihana%20Model.pdf");
        }

        private async void interrai_Tapped(object sender, EventArgs e)
        {
            await Browser.OpenAsync("https://www.interrai.co.nz/assets/Documents/ESS-Quality-and-Standards/ee251150d6/Improving-Maori-health-through-clinical-assessment-NZ-Medical-Journal.pdf");
        }
    }
}