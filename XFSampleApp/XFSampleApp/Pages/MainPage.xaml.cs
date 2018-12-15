using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using System.Collections.ObjectModel;
using XFSampleApp.models;

namespace XFSampleApp.Pages
{
    public partial class MainPage : ContentPage
    {
        public static ObservableCollection<SchoolInfo> schoolData;

        public MainPage()
        {
            InitializeComponent();

            BuildSchoolData();

            SchoolListView.ItemsSource = schoolData;
        }

        private void BuildSchoolData()
        {
            schoolData = new ObservableCollection<SchoolInfo>()
            {
                new SchoolInfo(){Name="中興大學",Logo="nchu",Address="402 台中市中興路",Tel="01-1234567",Email="中興@service.edu.tw"},
                new SchoolInfo(){Name="中正大學",Logo="nccu",Address="402 台中市中正路",Tel="02-1234567",Email="中正@service.edu.tw"},
                new SchoolInfo(){Name="中山大學",Logo="nsyu",Address="402 台中市中山路",Tel="03-1234567",Email="中山@service.edu.tw"},
                new SchoolInfo(){Name="中原大學",Logo="cycu",Address="402 台中市中原路",Tel="04-1234567",Email="中原@service.edu.tw"},
            };
        }

        private async void ListView_Refreshing(object sender, EventArgs e)
        {
            await Task.Delay(5000);
            SchoolListView.IsRefreshing = false; //SchoolListView.EndRefresh();
        }

        private async void SchoolListView_ItemTapped(object sender, ItemTappedEventArgs e)
        {
            var schoolInfo = SchoolListView.SelectedItem as SchoolInfo;
            await Navigation.PushAsync(new DetailPage(schoolInfo));
            SchoolListView.SelectedItem = null;
        }

        private async void CallButton_Clicked(object sender, EventArgs e)
        {
            var isConfirm = await DisplayAlert("通知", "是否撥打電話?", "確定", "取消");
            if (isConfirm)
            {
                var callButton = sender as Button;
                var callSchoolInfo = (callButton.BindingContext as SchoolInfo);
                var callTel = callSchoolInfo.Tel;
                Device.OpenUri(new Uri($"tel:{callTel}"));
            }
        }

        private async void EditMenuItem_Clicked(object sender, EventArgs e)
        {
            var menuItem = sender as MenuItem;
            var schoolInfo = menuItem.BindingContext as SchoolInfo;

            await Navigation.PushModalAsync(new DetailEditingPage(schoolInfo));
        }

        private async void DeleteMenuItem_Clicked(object sender, EventArgs e)
        {
            var menuItem = sender as MenuItem;
            var schoolInfo = menuItem.BindingContext as SchoolInfo;
            var name = schoolInfo.Name;
            var isConfirm = await DisplayAlert("通知", $"是否刪除 {name} 此項目?", "確定", "取消");

            if (isConfirm)
            {
                schoolData.Remove(schoolInfo);
            }
        }
    }
}
