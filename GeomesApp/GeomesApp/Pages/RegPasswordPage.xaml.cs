using GeomesApp.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace GeomesApp.Pages
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class RegPasswordPage : ContentPage
    {
        string cache = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "cache.txt");
        public RegPasswordPage()
        {
            InitializeComponent();
        }

        private async Task<object> PostRequestAsyncReg()
        {
            try
            {
                Person person = new Person();
                object name = "";
                if (App.Current.Properties.TryGetValue("sex", out name))
                {
                    person.sex = (string)name;
                }
                if (App.Current.Properties.TryGetValue("name", out name))
                {
                    person.name = (string)name;
                }
                if (App.Current.Properties.TryGetValue("age", out name))
                {
                    person.age = (string)name;
                }
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
                Console.WriteLine(person.password);
                Console.WriteLine(message);

                byte[] messageBytes = System.Text.Encoding.UTF8.GetBytes(message);
                var content = new ByteArrayContent(messageBytes);
                content.Headers.ContentType = new System.Net.Http.Headers.MediaTypeHeaderValue("application/json");

                var response = client.PostAsync("https://lehaproject.herokuapp.com/api/auth/sign", content).Result;
                var result = response.Content.ReadAsStringAsync().Result;
                App.Current.Properties["cache"] = result;
                File.WriteAllText(cache, result);

                return result;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            return null;
        }

        private async void btnContinue_Clicked(object sender, EventArgs e)
        {
            string value = entryPassword.Text;
            App.Current.Properties["password"] = value;

            object response = await PostRequestAsyncReg();
            if (response.ToString().Contains("true"))
            {
                await Shell.Current.GoToAsync("//UserProfilePage");
                await DisplayAlert("Attention", "Регистрация пройдена успешно", "Have a nice day");
            }
            else
            {
               await DisplayAlert("Attention", (string)response, "Have a nice day");
            }
        }
    }
}