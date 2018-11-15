using BallingOutMobile.Models;
using System;
using System.Collections.Generic;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace BallingOutMobile
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class PracticePage : ContentPage
    {
        public List<Drill> Drills { get; set; }

        public PracticePage()
        {
            InitializeComponent();
            Drills = new List<Drill>()
            {
                new Drill() {
                    IsCompleted = true,
                    Description = "This is your first drill.",
                    Name = "First drill",
                    SecondsForExercise = 30
                },
                new Drill() {
                    IsCompleted = false,
                    Description = "This is your second drill.",
                    Name = "Second drill",
                    SecondsForExercise = 40
                },
                new Drill() {
                    IsCompleted = false,
                    Description = "This is your third drill.",
                    Name = "Third drill",
                    SecondsForExercise = 50
                },
            };
            BindingContext = this;

        }

        private void Button_Clicked(object sender, EventArgs e)
        {

        }

        private void StartButton_Clicked(object sender, EventArgs e)
        {
            (sender as Button).IsVisible = false;
            ListView listView = (ListView)FindByName("DrillListView");
            listView.IsVisible = true;
        }

        private void DrillListView_ItemTapped(object sender, ItemTappedEventArgs e)
        {

        }
    }
}