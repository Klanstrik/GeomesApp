using GeomesApp.Pages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace GeomesApp
{
    public partial class AppShell : Shell
    {
        public Dictionary<string, Type> Routes { get; private set; } = new Dictionary<string, Type>();
        public AppShell()
        {
            InitializeComponent();
            //Routing.RegisterRoute(nameof(WellcomePage), typeof(WellcomePage));
            //Routing.RegisterRoute(nameof(LoginPage), typeof(LoginPage));
            RegisterRoutes();
        }

        void RegisterRoutes()
        {
            Routes.Add("WellcomePage", typeof(WellcomePage));
            Routes.Add("LoginPage", typeof(LoginPage));
            Routes.Add("RegSexPage", typeof(RegSexPage));
            Routes.Add("RegNamePage", typeof(RegNamePage));
            Routes.Add("RegAgePage", typeof(RegAgePage));
            Routes.Add("RegEmailPage", typeof(RegEmailPage));
            Routes.Add("RegPhotoPage", typeof(RegPhotoPage));
            Routes.Add("RegPasswordPage", typeof(RegPasswordPage));
            Routes.Add("UserProfilePage", typeof(UserProfilePage));


            foreach (var item in Routes)
            {
                Routing.RegisterRoute(item.Key, item.Value);
            }
        }
    }
}