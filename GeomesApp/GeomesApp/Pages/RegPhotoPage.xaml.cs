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
    public partial class RegPhotoPage : ContentPage
    {
        public RegPhotoPage()
        {
            InitializeComponent();
        }

        private async void imagebtn_Clicked(object sender, EventArgs e)
        {
            await DisplayAlert("Attention", "Реализация контекстного меню камеры", "Have a nice day");
        }

        private async void btnContinue_Clicked(object sender, EventArgs e)
        {
            string value = "base64example";
            App.Current.Properties["photo"] = value;
            await Shell.Current.GoToAsync("//RegPasswordPage");
        }
    }
}