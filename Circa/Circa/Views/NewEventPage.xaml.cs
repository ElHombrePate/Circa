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

            fieldEntry.ItemsSource = CalendarEvent.eventFieldList;
            
            /*
            List<string> auxList = CalendarEvent.eventFieldList;
            foreach (string str in auxList)
            {
                System.Diagnostics.Debug.WriteLine(str);
            }
            */

        }

        private async void ConfirmNewEvent_Clicked(object sender, EventArgs e)
        {
            var voteLimit = new DateTimeOffset();
            System.Diagnostics.Debug.WriteLine(voteLimit);

            voteLimit = endEventDatePicker.Date;
            System.Diagnostics.Debug.WriteLine(voteLimit);

            //voteLimit.AddMinutes(endEventTimePicker.Time.TotalMinutes);
            voteLimit.Add(endEventTimePicker.Time);
            System.Diagnostics.Debug.WriteLine(endEventTimePicker.Time);

            //TimePicker endEventTime = endEventTimePicker;
            //DatePicker endEventDate = endEventDatePicker;

            CalendarEvent inCreationEvent = new CalendarEvent(
                titleEntry.Text,
                descriptionEntry.Text,
                fieldEntry.SelectedItem.ToString(),
                //fieldEntry.Items.ToString(),
                App.admin,
                voteLimit);

            System.Diagnostics.Debug.WriteLine(voteLimit);

            App.admin.Events.Add(inCreationEvent);

            await Navigation.PopModalAsync().ConfigureAwait(false);
        }

        private async void CancelNewEvent_Clicked(object sender, EventArgs e)
        {
            await Navigation.PopModalAsync().ConfigureAwait(false);
        }
    }
}