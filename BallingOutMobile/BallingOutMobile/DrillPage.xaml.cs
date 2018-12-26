using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using BallingOutMobile.Models;
using BallingOutMobile.Services;

namespace BallingOutMobile
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class DrillPage : ContentPage
	{
        public Drill Drill { get; set; }

        public bool DrillStarted { get; set; }

        public int CurrentTime { get; set; }

        private List<string> tips = new List<string>() {
            "Dribble the ball as hard as you can.",
            "Don’t be discouraged if you mess up. It means you’re pushing yourself!",
            "Make sure you change which way you’re wrapping the ball.",
            "Perform every drill as fast as you can."
        };
		public DrillPage(Drill drill)
		{
			InitializeComponent();

            Drill = drill;
            CurrentTime = drill.SecondsForExercise * 1000;
            BindingContext = this;
        }

        private void StartDrill_Clicked(object sender, EventArgs e)
        {
            TimeTextLabel.IsVisible = true;
            TimeLabel.IsVisible = true;
            StartDrillButton.IsVisible = false;
            DisplayTime();
        }

        private async void DisplayTime()
        {
            while (CurrentTime > 0)
            {
                await Task.Delay(100);
                CurrentTime -= 100;
            }

            var res = await PracticeService.AddDrillToCompleted(CurrentUser.User.Id, Drill.DrillId);
            if (res) {
                Drill.IsCompleted = true;
                CompletedDrill.Drill = Drill;
                TimeTextLabel.IsVisible = false;
                TimeLabel.IsVisible = false;
            }
        }

        private async void ViewResultButton_Clicked(object sender, EventArgs e)
        {
            var res = await PracticeService.GetDrillStatsById(CurrentUser.User.Id, Drill.DrillId);
            
            //TODO
            var randomTip = tips[new Random().Next() % tips.Count];
            await DisplayAlert(
                "Your result:", 
                $"Average speed: {Math.Round(res.AverageSpeed, 2)}\n" +
                $"Repetitions per sec: {Math.Round(res.RepsPerSec, 2)}\n" +
                $"Your grade: {Math.Round(res.Accuracy, 2)}\n" +
                $"Tips: {randomTip}", 
                "Ok");
        }
    }
}