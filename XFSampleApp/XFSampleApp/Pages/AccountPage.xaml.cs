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
            // WebAPI 呼叫器
            if(AccountEntry.Text.Equals("NCHU", StringComparison.CurrentCultureIgnoreCase) && PasswordEntry.Text == "123456")
            {
                await Navigation.PushAsync(new MainPage());
            }
            else
            {
                await DisplayAlert("通知","帳號密碼驗證有誤，請重新輸入一次","確認");
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