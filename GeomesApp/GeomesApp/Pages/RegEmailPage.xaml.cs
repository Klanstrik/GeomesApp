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
    public partial class RegEmailPage : ContentPage
    {
        public RegEmailPage()
        {
            InitializeComponent();
        }

        private async void btnContinue_Clicked(object sender, EventArgs e)
        {
            string value = entryEmail.Text;
            App.Current.Properties["email"] = value;
            await Shell.Current.GoToAsync("//RegPhotoPage");
        }
    }
}