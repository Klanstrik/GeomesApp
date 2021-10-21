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
    public partial class RegSexPage : ContentPage
    {
        public RegSexPage()
        {
            InitializeComponent();
        }

        private async void btnMale_Clicked(object sender, EventArgs e)
        {
            App.Current.Properties["sex"] = "М";
            await Shell.Current.GoToAsync("//RegNamePage");
        }

        private async void btnFemale_Clicked(object sender, EventArgs e)
        {
            App.Current.Properties["sex"] = "Ж";
            await Shell.Current.GoToAsync("//RegNamePage");
        }
    }
}