using BallingOutMobile.Services;
using System;
using System.Collections.Generic;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using BallingOutMobile.Models;

namespace BallingOutMobile
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class SignUpPage : ContentPage
    {
        public SignUpPage()
        {
            InitializeComponent();
            
            
            BindingContext = this;
        }

        private async void NextButton_Clicked(object sender, EventArgs e)
        {
            if (!String.IsNullOrWhiteSpace(emailEntry.Text) 
                && !String.IsNullOrWhiteSpace(passwordEntry.Text)
                && !String.IsNullOrWhiteSpace(confirmPasswordEntry.Text) 
                && passwordEntry.Text == confirmPasswordEntry.Text)
            {
                await Navigation.PushAsync(new SignUpAdditionalInfoPage(new User() {
                    Password = passwordEntry.Text,
                    Email = emailEntry.Text
                }));
            }
            else {
                await DisplayAlert("", "Check your personal information, please.", "OK");
            }
        }
    }
}