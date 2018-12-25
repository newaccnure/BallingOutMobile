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
        
		public DrillPage(Drill drill)
		{
			InitializeComponent();

            Drill = drill;

            BindingContext = this;
        }

        private void StartDrill_Clicked(object sender, EventArgs e)
        {
            TimeTextLabel.IsVisible = true;
            TimeLabel.IsVisible = true;
            StartDrillButton.IsVisible = false;

            CurrentTime = 5000;
            DisplayTime();
        }

        private async void DisplayTime()
        {
            while (CurrentTime > 0)
            {
                await Task.Delay(100);
                CurrentTime -= 100;
            }

            Drill.IsCompleted = await PracticeService.AddDrillToCompleted(Current_User.user.Id, Drill.DrillId);
            TimeTextLabel.IsVisible = false;
            TimeLabel.IsVisible = false;
        }
    }
}