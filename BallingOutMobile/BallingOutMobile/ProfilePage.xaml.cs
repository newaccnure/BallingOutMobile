using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Microcharts;
using Entry = Microcharts.Entry;
using SkiaSharp;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using BallingOutMobile.Services;

namespace BallingOutMobile
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ProfilePage : ContentPage
    {
        private static List<Entry> accuracyEntries = new List<Entry>();
        private static List<Entry> averageSpeedEntries = new List<Entry>();
        private static List<Entry> repsPerSecEntries = new List<Entry>();

        public ProfilePage()
        {
            InitializeComponent();

            GenerateUserStats();

            SpeedChart.Chart = new LineChart
            {
                Entries = averageSpeedEntries,
                LineMode = LineMode.Straight,
                LineSize = 8,
                PointMode = PointMode.Square,
                PointSize = 18,
            };
            AccuracyChart.Chart = new LineChart
            {
                Entries = accuracyEntries,
                LineMode = LineMode.Straight,
                LineSize = 8,
                MaxValue = 1,
                MinValue = 0,
                PointMode = PointMode.Square,
                PointSize = 18,
            };
            RepeatitionsChart.Chart = new LineChart
            {
                Entries = repsPerSecEntries,
                LineMode = LineMode.Straight,
                LineSize = 8,
                PointMode = PointMode.Square,
                PointSize = 18,
            };

            Display();
        }
        private async void Display()
        {
            var user = Current_User.user;
            await DisplayAlert("User ID", $"Your id: {user.Id}, your name: {user.Name}", "OK");
        }
        private void GenerateUserStats() {
            var startAccuracy = 0.7;
            var endAccuracy = 0.9;

            var startAverageSpeed = 10;
            var endAverageSpeed = 20;

            var startRepetitionsPerSecond = 0.7;
            var endRepetitionsPerSecond = 1;

            SKColor startColor = SKColor.Parse("#FF1166");
            SKColor endColor = SKColor.Parse("#6173AB");

            var startColorRed = startColor.Red;
            var startColorBlue = startColor.Blue;
            var startColorGreen = startColor.Green;

            DateTime currentDay = DateTime.Now.AddDays(-10);
            accuracyEntries = new List<Entry>();
            averageSpeedEntries = new List<Entry>();
            repsPerSecEntries = new List<Entry>();
            Random r = new Random();
            for (int i = 1; i <= 10; i++)
            {
                var avgSpeed = (float)Math.Sqrt(startAverageSpeed * startAverageSpeed
                    + (endAverageSpeed * endAverageSpeed - startAverageSpeed * startAverageSpeed) / 10 * (i + r.NextDouble()));

                var accuracy = (float)Math.Sqrt(startAccuracy * startAccuracy
                        + (endAccuracy * endAccuracy - startAccuracy * startAccuracy) / 10 * (i + r.NextDouble()));

                var repeationsPerSecond = (float)Math.Sqrt(startRepetitionsPerSecond * startRepetitionsPerSecond
                    + (endRepetitionsPerSecond * endRepetitionsPerSecond
                    - startRepetitionsPerSecond * startRepetitionsPerSecond) / 10 * (i + r.NextDouble()));

                var difRed = endColor.Red - startColor.Red;
                var difGreen = endColor.Green - startColor.Green;
                var difBlue = endColor.Blue - startColor.Blue;

                var color =
                    startColor
                    .WithRed((byte)(startColorRed + difRed * i / 10))
                    .WithBlue((byte)(startColorBlue + difBlue * i / 10))
                    .WithGreen((byte)(startColorGreen + difGreen * i / 10));

                averageSpeedEntries.Add(new Entry(avgSpeed)
                {
                    Color = color,
                    Label = currentDay.Day.ToString() + "." + currentDay.Month
                });
                accuracyEntries.Add(new Entry(accuracy)
                {
                    Color = color,
                    Label = currentDay.Day.ToString() + "." + currentDay.Month
                });
                repsPerSecEntries.Add(new Entry(repeationsPerSecond)
                {
                    Color = color,
                    Label = currentDay.Day.ToString() + "." + currentDay.Month
                });

                currentDay = currentDay.AddDays(1);
            }
        }
        protected override bool OnBackButtonPressed()
        {
            //if (_canClose)
            //{
            //    ShowExitDialog();
            //}
            //return _canClose;
            base.OnBackButtonPressed();
            return true;
        }
        //private async void ShowExitDialog()
        //{

        //    var answer = await DisplayAlert("Exit", "Do you wan't to exit the App?", "Yes", "No");
        //    if (answer) {
        //        _canClose = false;
        //        base.OnBackButtonPressed();
        //    }
        //}
        //private bool _canClose = true;
    }
}