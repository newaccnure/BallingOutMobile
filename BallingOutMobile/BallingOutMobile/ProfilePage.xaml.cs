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
using System.Collections.ObjectModel;
using BallingOutMobile.Models;

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

            //GenerateUserStats();

            GetUserStats();


            SpeedChart.Chart = new LineChart
            {
                Entries = averageSpeedEntries,
                LineMode = LineMode.Straight,
                LineSize = 8,
                PointMode = PointMode.Square,
                PointSize = 18
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
            RepetitionsChart.Chart = new LineChart
            {
                Entries = repsPerSecEntries,
                LineMode = LineMode.Straight,
                LineSize = 8,
                PointMode = PointMode.Square,
                PointSize = 18,
            };
            
        }

        private void GetUserStats() {
            List<UserStats> userStats = ProfileService.GetUserStatsById(Current_User.user.Id);
            if (userStats.Count > 0) {
                var accEntries = userStats.Select(x => new Entry(x.AverageAccuracy)
                {
                    Color = SKColor.Parse("#FF1166"),
                    Label = x.PracticeDay.Day.ToString() + "." + x.PracticeDay.Month
                }).ToList();
                ChangeEntries(ref accEntries);
                foreach (var e in accEntries)
                {
                    accuracyEntries.Add(e);
                }

                var avgSpeedEntries = userStats
                    .Select(x => new Entry(x.AverageSpeed)
                    {
                        Color = SKColor.Parse("#FF1166"),
                        Label = x.PracticeDay.Day.ToString() + "." + x.PracticeDay.Month
                    }).ToList();
                ChangeEntries(ref avgSpeedEntries);
                foreach (var e in avgSpeedEntries)
                {
                    averageSpeedEntries.Add(e);
                }

                var avgRepsEntries = userStats
                    .Select(x => new Entry(x.AverageRepsPerSec)
                    {
                        Color = SKColor.Parse("#FF1166"),
                        Label = x.PracticeDay.Day.ToString() + "." + x.PracticeDay.Month
                    }).ToList();
                ChangeEntries(ref avgRepsEntries);
                foreach (var e in avgRepsEntries)
                {
                    repsPerSecEntries.Add(e);
                }
            }
        }

        private void ChangeEntries(ref List<Entry> entries) {
            var newEntries = entries;
            var maxEntry = newEntries.Where(x => x.Value == newEntries.Select(y => y.Value).Max()).First();
            
            var maxIndex = newEntries.FindIndex(0, newEntries.Count, x => x.Value == maxEntry.Value);
            entries[maxIndex] = new Entry(maxEntry.Value)
            {
                Color = SKColor.Parse("#ff19ae"),
                ValueLabel = "Personal best at " + Math.Round(maxEntry.Value, 2),
                Label = maxEntry.Label
            };
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
            base.OnBackButtonPressed();
            return true;
        }
    }
}