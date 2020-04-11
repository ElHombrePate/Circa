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
        public static AppUser admin = AdminConfig();
        public static AppUser AdminConfig()
        {
            var events = new List<CalendarEvent>();
            var admin = new AppUser(0, "Admin", events);

            var event1 = new CalendarEvent("Titulo1", "Descripción1", "Familia", admin, DateTime.UtcNow, new List<DateOption>());
            var event2 = new CalendarEvent("Titulo2", "Descripción2", "Trabajo", admin, DateTime.Now, new List<DateOption>());

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
