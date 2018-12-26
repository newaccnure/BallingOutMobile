using BallingOutMobile.Models;
using BallingOutMobile.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace BallingOutMobile
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class SettingsPage : ContentPage
	{
        public User User { get; set; }
		public SettingsPage()
		{
            InitializeComponent();
            User = CurrentUser.User;
            BindingContext = this;
		}

        private async void SaveButton_Clicked(object sender, EventArgs e)
        {
            var res = await UserService.ChangeName(User.Email, User.Name);
            if (res)
            {
                CurrentUser.User = User;
            }
            else {
                await DisplayAlert(":(", "Something went wrong", "Ok");
            }
        }

        private void ChangePasswordButton_Clicked(object sender, EventArgs e)
        {

        }
    }
}