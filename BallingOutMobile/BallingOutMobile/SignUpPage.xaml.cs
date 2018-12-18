using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

using BallingOutMobile.Services;
using BallingOutMobile.Models;

namespace BallingOutMobile
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class SignUpPage : ContentPage
	{
		public SignUpPage ()
		{
			InitializeComponent ();
		}

        private async void ToMainMenu(object sender, EventArgs e)
        {
            var email = emailEntry.Text;
            var password = passwordEntry.Text;

            var hasAccount = UserService.CheckUser(email, password);

            if (hasAccount)
            {
                var user = UserService.GetUserById(UserService.GetUserIdByEmail(email));
                await DisplayAlert("User ID", $"Your id: {user.Id}, your name: {user.Name}", "OK");
                await Navigation.PushModalAsync(new MainMenuPage());
            }
            else
            {
                await DisplayAlert("Error", "Check your personal information, please.", "OK");
            }
            await Navigation.PushModalAsync(new NavigationPage(new MainMenuPage()));
        }
    }
}