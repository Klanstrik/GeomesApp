using GeomesApp.Pages;
using GeomesApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using System.Net.Http;
using System.Text.Json;

namespace GeomesApp.Pages
{
    public partial class LoginPage : ContentPage
    {
        string cache = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "cache.txt");
        public LoginPage()
        {
            InitializeComponent();

            


        }
        protected override void OnAppearing()
        {
            base.OnAppearing();
        }
        private async Task<object> PostRequestAsyncLogin()
        {
            Person person = null;
            object name = "";
            if (App.Current.Properties.TryGetValue("email", out name))
            {
                person.email = (string)name;
            }
            if (App.Current.Properties.TryGetValue("password", out name))
            {
                person.password = (string)name;
            }
            if (person is null)
            {
                throw new ArgumentNullException(nameof(person));
            }

            var client = new HttpClient();
            client.DefaultRequestHeaders.Clear();
            client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
            client.DefaultRequestHeaders.TryAddWithoutValidation("Content-Type", "application/json");


            string message = JsonSerializer.Serialize<Person>(person);
            byte[] messageBytes = System.Text.Encoding.UTF8.GetBytes(message);
            var content = new ByteArrayContent(messageBytes);
            content.Headers.ContentType = new System.Net.Http.Headers.MediaTypeHeaderValue("application/json");

            var response = client.PostAsync("https://lehaproject.herokuapp.com/api/auth/login", content).Result;
            var result = response.Content.ReadAsStringAsync().Result;
            Console.WriteLine(result);

            return null;
        }
        private async void btnLogin_Clicked(object sender, EventArgs e)
        {
            await PostRequestAsyncLogin();
            await Shell.Current.GoToAsync("/UserProfilePage");
        }
        private async void btnReg_Clicked(object sender, EventArgs e)
        {
            File.WriteAllText(cache, "");
            await Shell.Current.GoToAsync("/RegSexPage");
        }
    }
}