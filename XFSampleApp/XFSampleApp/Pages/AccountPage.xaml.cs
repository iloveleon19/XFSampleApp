using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace XFSampleApp.Pages
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class AccountPage : ContentPage
	{
		public AccountPage ()
		{
			InitializeComponent ();
		}

        private async void Button_Clicked(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(AccountEntry.Text))
            {
                await DisplayAlert("通知", "請輸入帳號資料!", "Ok");
                return;
            }

            if (string.IsNullOrEmpty(PasswordEntry.Text))
            {
                await DisplayAlert("通知", "請輸入密碼資訊!", "Ok");
                return;
            }

            //實務上應是 WebAPI 呼叫帳號資訊的驗證邏輯
            if (AccountEntry.Text.Equals("NCHU", StringComparison.CurrentCultureIgnoreCase) &&
                PasswordEntry.Text == "123456")
            {
                await Navigation.PushAsync(new MainPage());
            }
            else
            {
                await DisplayAlert("通知", "帳號密碼驗證有誤，請重新輸入一次!", "Ok");
                AccountEntry.Text = "";
                PasswordEntry.Text = "";
            }
        }

        private void CancelButton_Clicked(object sender, EventArgs e)
        {
            AccountEntry.Text = "";
            PasswordEntry.Text = "";
        }
    }
}