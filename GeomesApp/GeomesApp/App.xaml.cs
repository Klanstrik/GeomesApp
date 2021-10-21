using GeomesApp.Pages;
using System;
using System.IO;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace GeomesApp
{
    public partial class App : Application
    {
        string file = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "cache.txt");
        public App()
        {
            InitializeComponent();
            string text = "";
            if (File.Exists(file))
            {
                text = File.ReadAllText(file);
            }
            if (text != "")
            {
                MainPage = new UserProfilePage();
            }
            else
            {
                MainPage = new AppShell();
            }
            
        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
