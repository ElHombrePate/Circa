using Circa.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


using Syncfusion.SfCalendar.XForms;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Circa.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class NewEventPage : TabbedPage
    {
        private static List<DateTime> inCreationVotedDates = new List<DateTime>();
        //private static List<VotedDate> inCreationVotedDates = new List<VotedDate>();
        //private CalendarEventCollection CalendarInlineEvents { get; set; } = new CalendarEventCollection();
        public NewEventPage()
        {
            InitializeComponent();

            fieldEntry.ItemsSource = CalendarEvent.eventFieldArray;

            //inCreationVotedDates = new ObservableCollection<DateTime>(inCreationVotedDates.Distinct());
            //votedDatesListView.ItemsSource = inCreationVotedDates;

            
            //CalendarEventCollection CalendarInlineEvents = CalendarInlineEvents.Distinct().To;
            //votedDatesListView.ItemsSource = CalendarInlineEvents;

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
            var voteLimit = endEventDatePicker.Date;
            voteLimit = voteLimit.Add(endEventTimePicker.Time);

            var fieldString = "";
            if (fieldEntry.SelectedItem != null)
            {
                fieldString = fieldEntry.SelectedItem.ToString();
            }

            CalendarEvent inCreationEvent = new CalendarEvent(
                titleEntry.Text,
                descriptionEntry.Text,
                fieldString,
                App.admin,
                voteLimit,
                //new VotedDate(voteLimit, App.admin),
                CalendarEvent.createUserDatesList(inCreationVotedDates, App.admin));

            System.Diagnostics.Debug.WriteLine(voteLimit);

            App.admin.Events.Add(inCreationEvent);

            await Navigation.PopModalAsync().ConfigureAwait(false);
        }

        private async void CancelNewEvent_Clicked(object sender, EventArgs e)
        {
            await Navigation.PopModalAsync().ConfigureAwait(false);
        }

        private void Calendar_OnCalendarTapped(object sender, Syncfusion.SfCalendar.XForms.CalendarTappedEventArgs e)
        {
            /*
            inCreationVotedDates.Add(calendar.SelectedDate.Value);
            var votedEventDate = new CalendarInlineEvent();
            votedEventDate.IsAllDay = true;
            CalendarInlineEvents.Add(votedEventDate);
            */

            //inCreationVotedDates.Add(calendar.SelectedDate.Value);
        }

        void Handle_SelectionChanged(object sender, Syncfusion.SfCalendar.XForms.SelectionChangedEventArgs e)
        {
            if (e.DateAdded != null)
            {
                inCreationVotedDates = new List<DateTime>(e.DateAdded);
                inCreationVotedDates.Sort();
                votedDatesListView.ItemsSource = inCreationVotedDates;
            }
            else
            {
                votedDatesListView.ItemsSource = new string[1] { "<Sin fechas seleccionadas>" };
            }

            //inCreationVotedDates = new ObservableCollection<DateTime>(e.DateAdded);
            //votedDatesListView.ItemsSource = inCreationVotedDates;
            //IList<DateTime> deselectedDates = e.DateRemoved;
            //new VotedDate(voteLimit, new User(App.admin.Id, App.admin.Nickname)),
        }


    }
}