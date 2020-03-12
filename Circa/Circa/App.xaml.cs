using Circa.Views;
using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

//Posible error en el UWP por falta de inicialización
//https://help.syncfusion.com/xamarin/calendar/getting-started

namespace Circa
{ 
    public partial class App : Application
    {
        public App()
        {
            Syncfusion.Licensing.SyncfusionLicenseProvider.RegisterLicense("MjIxNzU1QDMxMzcyZTM0MmUzMEZpQTRvWlpnei9nTUNZeTNWRHd3T244dlF4NjF6RGl0WjhYVjlXMTVRZHc9");

            InitializeComponent();

            MainPage = new NewEventPage();
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
