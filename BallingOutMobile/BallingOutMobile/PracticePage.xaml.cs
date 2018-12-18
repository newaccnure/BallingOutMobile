using BallingOutMobile.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;
using BallingOutMobile.Services;

namespace BallingOutMobile
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class PracticePage : ContentPage
    {
        public ObservableCollection<Drill> Drills { get; set; }

        public PracticePage()
        {
            InitializeComponent();
            Drills = new ObservableCollection<Drill>();
            
            BindingContext = this;

        }

        private void Button_Clicked(object sender, EventArgs e)
        {

        }

        private void StartButton_Clicked(object sender, EventArgs e)
        {
            var user = Current_User.user;
            List<Drill> drills = DrillService.GetFullTrainingProgramById(user.Id);
            foreach (var drill in drills) {
                Drills.Add(drill);
            }
            (sender as Button).IsVisible = false;
            ListView listView = (ListView)FindByName("DrillListView");
            listView.IsVisible = true;

        }

        private async void DrillListView_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            if (e.SelectedItem != null)
                await Navigation.PushModalAsync(new DrillPage((Drill)e.SelectedItem));
        }
    }
}