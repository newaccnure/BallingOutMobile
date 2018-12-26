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
	public partial class SignUpAdditionalInfoPage : ContentPage
    {
        public bool IsLoading { get; set; }

        private Dictionary<string, int> keyValuePairs = new Dictionary<string, int>();

        private List<int> chosenDaysOfTheWeek = new List<int>();

        public User User { get; set; }

        public SignUpAdditionalInfoPage(User user)
		{
			InitializeComponent();
            User = user;
            keyValuePairs.Add("Sun", 0);
            keyValuePairs.Add("Mon", 1);
            keyValuePairs.Add("Tue", 2);
            keyValuePairs.Add("Wed", 3);
            keyValuePairs.Add("Thu", 4);
            keyValuePairs.Add("Fri", 5);
            keyValuePairs.Add("Sat", 6);
        }
        private void DayOfWeekButton_Clicked(object sender, EventArgs e)
        {
            Button b = (sender as Button);
            Color c = b.BackgroundColor;
            if (c != Color.Gray)
            {
                chosenDaysOfTheWeek.Add(keyValuePairs[b.Text]);
                b.BackgroundColor = Color.LightGreen;
            }
            else
            {
                chosenDaysOfTheWeek.Remove(keyValuePairs[b.Text]);
                b.BackgroundColor = Color.Gray;
            }
        }
        private async void ToMainMenu(object sender, EventArgs e)
        {
            IsLoading = true;
            var name = nameEntry.Text;

            if (chosenDaysOfTheWeek.Count >= 2 || String.IsNullOrWhiteSpace(name))
            {
                var user = await UserService.AddUser(name, User.Email, User.Password, User.Password, chosenDaysOfTheWeek);

                if (user.Id != 0)
                {
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
            else
            {
                await DisplayAlert("", "Choose at least two practice days.", "OK");
            }
        }
    }
}