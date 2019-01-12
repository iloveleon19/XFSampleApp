using System;
using System.IO;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using XFSampleApp.Pages;

[assembly: XamlCompilation(XamlCompilationOptions.Compile)]
namespace XFSampleApp
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            if(Services.AuthStatusFileService.CheckIsAuth())
            {
                MainPage = new NavigationPage(new MainPage());
                return;
            }

           MainPage = new NavigationPage(new AccountPage());
        }

        protected override void OnStart()
        {
            // Handle when your app starts
        }

        protected override void OnSleep()
        {
            // Handle when your app sleeps
        }

        protected override void OnResume()
        {
            // Handle when your app resumes
        }
    }
}
