using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using XFSampleApp.models;

namespace XFSampleApp.Pages
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class DetailEditingPage : ContentPage
    {
        private SchoolInfo schoolInfo;
        private SchoolInfo originalSchoolInfo;

        public DetailEditingPage()
        {
            InitializeComponent();
        }

        public DetailEditingPage(SchoolInfo schoolInfo):this()
        {
            CloneSchoolInfo(schoolInfo);
            BindingContext = this.schoolInfo = schoolInfo;
        }

        private void CloneSchoolInfo(SchoolInfo schoolInfo)
        {
            originalSchoolInfo = new SchoolInfo()
            {
                Name = schoolInfo.Name,
                Tel = schoolInfo.Tel,
                Address = schoolInfo.Address,
                Email = schoolInfo.Email,
                Logo = schoolInfo.Logo,
            };
        }

        private async void FinishButton_Clicked(object sender, EventArgs e)
        {
            await Navigation.PopModalAsync(true);
        }

        private async void CancelButton_Clicked(object sender, EventArgs e)
        {
            var index = MainPage.schoolData.IndexOf(schoolInfo);
            MainPage.schoolData.Remove(schoolInfo);
            MainPage.schoolData.Insert(index, originalSchoolInfo);
            await Navigation.PopModalAsync(true);
        }
    }
}