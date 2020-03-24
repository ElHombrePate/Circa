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
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();

            EventListView.ItemsSource = App.admin.Events;
        }
        async void NewEventCreation_Clicked(object sender, EventArgs e)
        {
            //if (listView.SelectedItem != null){}

            var NewEventPage = new NavigationPage(new NewEventPage());

            await Navigation.PushModalAsync(NewEventPage).ConfigureAwait(false);
        }
    }
}