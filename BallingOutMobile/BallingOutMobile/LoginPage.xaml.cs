using BallingOutMobile.Services;
using System;
using Xamarin.Forms;

namespace BallingOutMobile
{
    public partial class LoginPage : ContentPage
    {

        public LoginPage()
        {
            InitializeComponent();

            Label label = (Label)FindByName("toSignUpPageLabel");

            TapGestureRecognizer tapGesture = new TapGestureRecognizer
            {
                NumberOfTapsRequired = 1
            };

            tapGesture.Tapped += ToSignUpPage;

            label.GestureRecognizers.Add(tapGesture);

        }
        private async void ToSignUpPage(object sender, EventArgs e)
        {
            await Navigation.PushModalAsync(new NavigationPage(new SignUpPage()));
        }
        private async void ToMainMenu(object sender, EventArgs e)
        {
            var email = emailEntry.Text;
            var password = passwordEntry.Text;

            var hasAccount = UserService.CheckUser(email, password);

            if (hasAccount)
            {
                var user = UserService.GetUserById(UserService.GetUserIdByEmail(email));
                Current_User.user = user;
                await Navigation.PushModalAsync(new MainMenuPage());
            }
            else
            {
                await DisplayAlert("Error", "Check your personal information, please.", "OK");
            }
        }
    }
}
