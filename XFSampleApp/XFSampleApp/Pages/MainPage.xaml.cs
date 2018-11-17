using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using System.Collections.ObjectModel;

namespace XFSampleApp.Pages
{
    public partial class MainPage : ContentPage
    {
        ObservableCollection<string> schoolData;

        public MainPage()
        {
            InitializeComponent();

            BuildSchoolData();

            SchoolListView.ItemsSource = schoolData;
        }

        private void BuildSchoolData()
        {
            schoolData = new ObservableCollection<string>()
            {
                "中興大學",
                "中正大學",
                "中山大學",
                "中央大學",
                "中華大學",
                "中原大學",
                "中國醫藥大學"
            };
        }

        private async void Button_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new DetailPage());
        }

        private async void ListView_Refreshing(object sender, EventArgs e)
        {
            await Task.Delay(5000);
            SchoolListView.IsRefreshing = false;
        }

        private async void SchoolListView_ItemTapped(object sender, ItemTappedEventArgs e)
        {
            await Navigation.PushAsync(new DetailPage());
            SchoolListView.SelectedItem = null;
        }
    }
}
