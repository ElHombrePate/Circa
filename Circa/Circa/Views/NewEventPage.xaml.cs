using Circa.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Circa.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class NewEventPage : TabbedPage
    {
        
        public NewEventPage()
        {
            InitializeComponent();
        }

        private async void ConfirmNewEvent_Clicked(object sender, EventArgs e)
        {
            User admin = App.admin;
            CalendarEvent inCreationEvent = new CalendarEvent("Titulo3", "Descripcion3", "Familia", admin, DateTimeOffset.Now);

            App.admin.Events.Add(inCreationEvent);

            await Navigation.PopModalAsync().ConfigureAwait(false);
        }

        private async void CancelNewEvent_Clicked(object sender, EventArgs e)
        {
            await Navigation.PopModalAsync().ConfigureAwait(false);
        }
    }
}