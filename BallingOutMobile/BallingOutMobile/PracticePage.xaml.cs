using BallingOutMobile.Models;
using BallingOutMobile.Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace BallingOutMobile
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class PracticePage : ContentPage
    {
        public ObservableCollection<Drill> Drills { get; set; }
        public bool IsLoading { get; set; }

        public PracticePage()
        {
            InitializeComponent();

            Drills = new ObservableCollection<Drill>();

            BindingContext = this;
        }

        private void Button_Clicked(object sender, EventArgs e)
        {

        }

        private async void StartButton_Clicked(object sender, EventArgs e)
        {
            IsLoading = true;
            var user = Current_User.user;
            var hasPractice = await PracticeService.CheckDayOfPractice(user.Id);
            if (hasPractice) {
                List<Drill> drills = await PracticeService.GetFullTrainingProgramById(user.Id);
                foreach (var drill in drills)
                {
                    Drills.Add(drill);
                }
                (sender as Button).IsVisible = false;
                ListView listView = (ListView)FindByName("DrillListView");
                listView.IsVisible = true;
                IsLoading = false;
            }
            else {
                (sender as Button).IsVisible = false;
                IsLoading = false;
                await DisplayAlert("", "Today is not your practice day.", "OK");
            }


        }

        private async void DrillListView_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            if (e.SelectedItem != null)
                await Navigation.PushAsync(new DrillPage((Drill)e.SelectedItem));
        }

        protected override bool OnBackButtonPressed() { return true; }
    }
}