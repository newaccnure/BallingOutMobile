using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using BallingOutMobile.Models;
using System.Timers;

namespace BallingOutMobile
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class DrillPage : ContentPage
	{
        public Drill Drill { get; set; }
        private Timer timer;
        public int CurrentTime { get; set; }
		public DrillPage (Drill drill)
		{
			InitializeComponent ();
            Drill = drill;
            BindingContext = this;
            timer = new Timer()
            {
                Interval = 10
            };
            timer.Elapsed += TimedEvent;

		}

        private void StartDrill_Clicked(object sender, EventArgs e)
        {
            CurrentTime = Drill.SecondsForExercise * 1000;
            TimeTextLabel.IsVisible = true;
            TimeLabel.IsVisible = true;
            StartDrillButton.IsVisible = false;
            timer.Enabled = true;
            
        }
        private void TimedEvent(object sender, ElapsedEventArgs e)
        {
            CurrentTime-=10;
            if (CurrentTime <= 0)
            {
                TimeLabel.IsVisible = false;
                TimeTextLabel.IsVisible = false;
                ViewResultButton.IsVisible = true;
                timer.Stop();
            }
        }
    }
}