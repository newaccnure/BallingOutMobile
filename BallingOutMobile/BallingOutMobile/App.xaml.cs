﻿using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

[assembly: XamlCompilation(XamlCompilationOptions.Compile)]
namespace BallingOutMobile
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();
            //var loginPage = new LoginPage();
            //NavigationPage.SetHasNavigationBar(loginPage, false);
            //MainPage = new NavigationPage(loginPage);
            MainPage = new LoginPage();
        }

        protected override void OnStart()
        {
            // Handle when your app starts
        }

        protected override void OnSleep()
        {
            // Handle when your app sleeps
        }

        protected override void OnResume()
        {
            // Handle when your app resumes
        }
    }
}
