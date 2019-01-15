using BallingOutMobile.Models;
using BallingOutMobile.Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
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

            PracticeWasStarted();
            ManageDrills();
        }

        private async void PracticeWasStarted() {
            IsLoading = true;
            var res = await PracticeService.PracticeWasStarted(CurrentUser.User.Id);
            if (res)
            {
                List<Drill> drills = await PracticeService.GetFullTrainingProgramById(CurrentUser.User.Id);
                foreach (var drill in drills)
                {
                    Drills.Add(drill);
                }
                ListView listView = (ListView)FindByName("DrillListView");
                listView.IsVisible = true;
            }
            else
            {
                StartButton.IsVisible = true;
            }
            IsLoading = false;

        }

        private void Button_Clicked(object sender, EventArgs e)
        {

        }

        private async void StartButton_Clicked(object sender, EventArgs e)
        {
            IsLoading = true;
            var user = CurrentUser.User;
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

        private async void ManageDrills() {
            while (true) {
                await Task.Delay(3000);
                CheckDrills();
            }
        }

        private void CheckDrills() {
            if (CompletedDrill.Drill.DrillId == 0) {
                return;
            }
            if (Drills.Count == 0) {
                return;
            }
            for (int i = 0; i < Drills.Count; i++)
            {
                if (!Drills[i].IsCompleted && Drills[i].DrillId == CompletedDrill.Drill.DrillId) {
                    Drills[i].IsCompleted = CompletedDrill.Drill.IsCompleted;
                    CompletedDrill.Drill = new Drill();
                    return;
                }
            }
        }

        private async void DrillListView_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            if (e.SelectedItem != null)
                await Navigation.PushAsync(new DrillPage((Drill)e.SelectedItem));
        }
    }
}