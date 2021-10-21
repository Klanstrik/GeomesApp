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
    public partial class UserProfilePage : ContentPage
    {
        string cache = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "cache.txt");
        public UserProfilePage()
        {
            InitializeComponent();
        }
        private async void btnYes_Clicked(object sender, EventArgs e)
        {
            File.WriteAllText(cache, "");
            await DisplayAlert("Attention", "Лайк", "Have a nice day");
        }

        private async void btnNo_Clicked(object sender, EventArgs e)
        {
            await DisplayAlert("Attention", "Следующий", "Have a nice day");
        }
    }
}