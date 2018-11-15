using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Entry = Microcharts.Entry;
using SkiaSharp;
using Microcharts.Forms;
using Microcharts;

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
            await Navigation.PushModalAsync(new MainMenuPage());
        }
    }
}
