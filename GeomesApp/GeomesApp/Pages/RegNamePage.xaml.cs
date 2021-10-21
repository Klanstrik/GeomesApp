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
    public partial class RegNamePage : ContentPage
    {
        public RegNamePage()
        {
            InitializeComponent();
        }

        private async void btnContinue_Clicked(object sender, EventArgs e)
        {
            string value = entryName.Text;
            App.Current.Properties["name"] = value;
            await Shell.Current.GoToAsync("//RegAgePage");
        }
    }
}