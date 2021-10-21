using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace GeomesApp.Pages
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class WellcomePage : ContentPage
    {
        public WellcomePage()
        {
            InitializeComponent();
        }

        private async void btnGoogle_Clicked(object sender, EventArgs e)
        {
            await Shell.Current.GoToAsync("//RegSexPage");
        }

        private async void btnVK_Clicked(object sender, EventArgs e)
        {
            await Shell.Current.GoToAsync("//RegSexPage");
        }

        private async void btnEmail_Clicked(object sender, EventArgs e)
        {
            await Shell.Current.GoToAsync("//LoginPage");
        }
    }
}