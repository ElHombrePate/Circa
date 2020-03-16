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

        private void ConfirmNewEvent_Clicked(object sender, EventArgs e)
        {

        }

        private async void CancelNewEvent_Clicked(object sender, EventArgs e)
        {
            await Navigation.PopModalAsync ();
        }
    }
}