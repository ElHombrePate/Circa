using Circa.Models;
using Circa.ViewModels;
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
    public partial class VotingEventPage : TabbedPage
    {
        private MainPage listener;
        public MainPage Listener { get => listener; set => listener = value; }

        /*
        public VotingEventPage()
        {
            InitializeComponent();

            //this.BindingContext = new VotingEventViewModel();

            FieldPicker.ItemsSource = GenericEvent.eventFieldArray;
            MaxPropositionsPerUserPicker.ItemsSource = GenericEvent.maxPropositionsPerUserArray;
        }
        */

        public VotingEventPage(DateEvent dateEvent)
        {
            InitializeComponent();

            this.BindingContext = new VotingEventViewModel(dateEvent);

            FieldPicker.ItemsSource = GenericEvent.eventFieldArray;
            MaxPropositionsPerUserPicker.ItemsSource = GenericEvent.maxPropositionsPerUserArray;

            //TODO ESTO DEBE LLEVARSE AL VIEWMODEL

            var vm = BindingContext as VotingEventViewModel;
            vm.DateEvent = dateEvent;

            TitleEntry.Text = vm.DateEvent.Title;
            DescriptionEntry.Text = vm.DateEvent.Description;
            UbicationEntry.Text = vm.DateEvent.Ubication;
            FieldPicker.SelectedItem = vm.DateEvent.Field;
            VotingDeadlineDatePicker.Date = vm.DateEvent.VotingDeadline.Date;
            VotingDeadlineTimePicker.Time = vm.DateEvent.VotingDeadline.TimeOfDay;

            //Bloqueamos TODOS los elementos (Bloquearlos todos desde ResourceDictionary)
            TitleEntry.IsEnabled = false;
            DescriptionEntry.IsEnabled = false;
            UbicationEntry.IsEnabled = false;
            FieldPicker.IsEnabled = false;
            VotingDeadlineDatePicker.IsEnabled = false;
            VotingDeadlineTimePicker.IsEnabled = false;

            ProposingIsEnabledSwitch.IsEnabled = false;
            ProposingUsersBlock.IsVisible = false;

            MaxPropositionsPerUserPicker.IsEnabled = false;
            ProposingDeadlineDatePicker.IsEnabled = false;
            ProposingDeadlineTimePicker.IsEnabled = false;


            //Si ProposingIsEnabled, se puede ver la configuración
            if (vm.DateEvent.ProposingIsEnabled)
            {
                ProposingUsersBlock.IsVisible = true;

                MaxPropositionsPerUserPicker.SelectedItem = vm.DateEvent.MaxPropositionsPerUser;
                ProposingDeadlineDatePicker.Date = vm.DateEvent.ProposingDeadline.Date;
                ProposingDeadlineTimePicker.Time = vm.DateEvent.ProposingDeadline.TimeOfDay;
            }

            //Si somos Admin, podemos cambiar ALGUNOS
            if (vm.DateEvent.Admin.Equals(App.myUser))
            {
                DescriptionEntry.IsEnabled = true;
                UbicationEntry.IsEnabled = true;
                FieldPicker.IsEnabled = true;
            }
        }

        private async void ConfirmNewEvent_Clicked(object sender, EventArgs e)
        {
            var votingDeadline = VotingDeadlineDatePicker.Date;
            votingDeadline = votingDeadline.Add(VotingDeadlineTimePicker.Time);

            var fieldString = "";
            if (FieldPicker.SelectedItem != null)
            {
                fieldString = FieldPicker.SelectedItem.ToString();
            }

            var vm = BindingContext as VotingEventViewModel;

            //Añadimos los votos
            var selectedDateOptions = new List<DateOption>(vm.SelectedDateOptions);
            foreach (DateOption i in selectedDateOptions)
            {
                foreach(DateOption j in vm.DateEvent.DateOptions)
                {
                    if (j.Equals(i))
                    {
                        //El voto siempre es "Me viene bien"
                        j.AddVote(new OptionVote(App.myUser, 1));
                    }
                }
                //System.Diagnostics.Debug.WriteLine(i + ") " + dT);
            }


            //Si somos Admin, introducimos los cambios de los Entry realizados
            if (vm.DateEvent.Admin.Equals(App.myUser))
            {
                vm.DateEvent.Description = DescriptionEntry.Text;
                vm.DateEvent.Ubication = UbicationEntry.Text;
                vm.DateEvent.Field = FieldPicker.SelectedItem.ToString();
            }


            //Notify listener
            if (Listener != null)
            {
                Listener.OnNewUserEvent(vm.DateEvent);
            }

            await Navigation.PopModalAsync().ConfigureAwait(false);
        }

        private async void CancelNewEvent_Clicked(object sender, EventArgs e)
        {
            await Navigation.PopModalAsync().ConfigureAwait(false);
        }


        private void ProposingIsEnabledSwitch_Toggled(object sender, ToggledEventArgs e)
        {
            ProposingUsersBlock.IsVisible = !ProposingUsersBlock.IsVisible;
        }
    }
}