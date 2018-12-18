using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using BallingOutMobile.Models;

namespace BallingOutMobile
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class DrillPage : ContentPage
	{
        public Drill Drill { get; set; }
		public DrillPage (Drill drill)
		{
			InitializeComponent ();
            Drill = drill;
            BindingContext = this;
		}

        private void Button_Clicked(object sender, EventArgs e)
        {

        }
    }
}