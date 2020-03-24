using Circa.Models;
using Circa.Views;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

//Posible error en el UWP por falta de inicialización
//https://help.syncfusion.com/xamarin/calendar/getting-started

namespace Circa
{ 
    public partial class App : Application
    {
        public static User admin = AdminConfig();
        public static User AdminConfig()
        {
            var events = new ObservableCollection<CalendarEvent>();
            var admin = new User(0, "Admin", events);

            var event1 = new CalendarEvent("Titulo1", "Descripción1", "Familia", admin, DateTimeOffset.UtcNow);
            var event2 = new CalendarEvent("Titulo2", "Descripción2", "Trabajo", admin, DateTimeOffset.Now);

            admin.Events.Add(event1);
            admin.Events.Add(event2);

            return admin;
        }

        public App()
        {
            Syncfusion.Licensing.SyncfusionLicenseProvider.RegisterLicense("MjIxNzU1QDMxMzcyZTM0MmUzMEZpQTRvWlpnei9nTUNZeTNWRHd3T244dlF4NjF6RGl0WjhYVjlXMTVRZHc9");

            InitializeComponent();

            MainPage = new NavigationPage(new MainPage());
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
