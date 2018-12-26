using BallingOutMobile.Services;
using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace BallingOutMobile
{
    public partial class LoginPage : ContentPage
    {
        
        public bool IsLoading { get; set; }

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
            BindingContext = this;
        }

        private void ToSignUpPage(object sender, EventArgs e)
        {
            App.Current.MainPage = new NavigationPage(new SignUpPage());
        }

        private async void ToMainMenu(object sender, EventArgs e)
        {
            var email = emailEntry.Text;
            var password = passwordEntry.Text;


            IsLoading = true;
            var hasAccount = await UserService.CheckUser(email, password);

            if (hasAccount)
            {
                var user = await UserService.GetUserByEmail(email);
                CurrentUser.User = user;
                IsLoading = false;
                //await Navigation.PushModalAsync(new MainMenuPage());
                App.Current.MainPage = new MainMenuPage();
            }
            else
            {
                IsLoading = false;
                await DisplayAlert("Error", "Check your personal information, please.", "OK");
            }
        }
        
    }
}
