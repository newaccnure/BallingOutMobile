using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using BallingOutMobile.Services;

namespace BallingOutMobile
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MainMenuPage : MasterDetailPage
    {
        public ProfilePage ProfilePage { get; set; }
        public PracticePage PracticePage { get; set;}
        public SettingsPage SettingsPage { get; set; }

        public MainMenuPage()
        {
            InitializeComponent();

            ProfilePage = new ProfilePage();
            PracticePage = new PracticePage();
            SettingsPage = new SettingsPage();
            Detail = new NavigationPage(ProfilePage);
            IsPresented = false;

            TapGestureRecognizer tapGesture = new TapGestureRecognizer
            {
                NumberOfTapsRequired = 1
            };

            tapGesture.Tapped += ProfileButton_Clicked;

            Profile.GestureRecognizers.Add(tapGesture);

            tapGesture = new TapGestureRecognizer
            {
                NumberOfTapsRequired = 1
            };

            tapGesture.Tapped += PracticeButton_Clicked;

            Practice.GestureRecognizers.Add(tapGesture);

            tapGesture = new TapGestureRecognizer
            {
                NumberOfTapsRequired = 1
            };

            tapGesture.Tapped += SettingsButton_Clicked;

            Settings.GestureRecognizers.Add(tapGesture);

            tapGesture = new TapGestureRecognizer
            {
                NumberOfTapsRequired = 1
            };

            tapGesture.Tapped += LogOutButton_Clicked;

            Logout.GestureRecognizers.Add(tapGesture);
        }

        private void ProfileButton_Clicked(object sender, EventArgs e)
        {
            Detail = new NavigationPage(ProfilePage);
            IsPresented = false;
        }

        private void SettingsButton_Clicked(object sender, EventArgs e)
        {
            Detail = new NavigationPage(SettingsPage);
            IsPresented = false;
        }

        private void PracticeButton_Clicked(object sender, EventArgs e)
        {
            Detail = new NavigationPage(PracticePage);
            IsPresented = false;
        }

        private void LogOutButton_Clicked(object sender, EventArgs e)
        {
            CurrentUser.User = new Models.User();
            App.Current.MainPage = new LoginPage();
        }
    }
}