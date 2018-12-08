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

        public DetailEditingPage()
        {
            InitializeComponent();
        }

        public DetailEditingPage(SchoolInfo schoolInfo):this()
        {
            BindingContext = this.schoolInfo = schoolInfo;
        }

        private async void FinishButton_Clicked(object sender, EventArgs e)
        {
            await Navigation.PopModalAsync(true);
        }

        private async void CancelButton_Clicked(object sender, EventArgs e)
        {
            await Navigation.PopModalAsync(true);
        }
    }
}