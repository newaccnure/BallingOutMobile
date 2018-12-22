using BallingOutMobile.Services;
using System;
using System.Collections.Generic;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace BallingOutMobile
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class SignUpPage : ContentPage
    {
        public bool IsLoading { get; set; }
        public SignUpPage()
        {
            InitializeComponent();
            BindingContext = this;
        }

        private async void ToMainMenu(object sender, EventArgs e)
        {
            IsLoading = true;
            var email = emailEntry.Text;
            var password = passwordEntry.Text;
            var name = nameEntry.Text;
            var confirmPassword = confirmPasswordEntry.Text;
            
            var user = await UserService.AddUser(name, email, password, confirmPassword, new List<int> { 1, 2, 3 });

            if (user.Id != 0)
            {
                Current_User.user = user;
                IsLoading = false;
                await Navigation.PushModalAsync(new MainMenuPage());
            }
            else
            {
                IsLoading = false;
                await DisplayAlert("Error", "Check your personal information, please.", "OK");
            }
        }
    }
}