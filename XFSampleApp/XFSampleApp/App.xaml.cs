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

            if(CheckIsAuth())
            {
                MainPage = new NavigationPage(new MainPage());
                return;
            }

           MainPage = new NavigationPage(new AccountPage());
        }

        private bool CheckIsAuth()
        {
            var cacheDir = Xamarin.Essentials.FileSystem.CacheDirectory;
            //var mainDir = Xamarin.Essentials.FileSystem.AppDirectory;

            System.Diagnostics.Debug.WriteLine(cacheDir);
            //System.Diagnostics.Debug.WriteLine(mainDir);

            var fullPath = cacheDir + "auth.log";
            //var fullPath = mainDir() + "auth.log";

            if(File.Exists(fullPath))
            {
                var result = File.ReadAllText(fullPath);
                result.StartsWith("Be Authorized,");
                return true;
            }
            return false;
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
