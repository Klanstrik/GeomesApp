using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace GeomesApp.Pages
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class RegAgePage : ContentPage
    {
        public RegAgePage()
        {
            InitializeComponent();
        }

        private void DatePicker_DateSelected(object sender, DateChangedEventArgs e)
        {
            string value = e.NewDate.ToString("dd/MM/yyyy");
            App.Current.Properties["age"] = value;
        }

        private async void btnContinue_Clicked(object sender, EventArgs e)
        {
            
            await Shell.Current.GoToAsync("//RegEmailPage");
        }
    }
}