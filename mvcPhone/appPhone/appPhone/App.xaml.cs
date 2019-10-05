﻿using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using appPhone.Views;

[assembly: XamlCompilation(XamlCompilationOptions.Compile)]
namespace appPhone
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            //MainPage = new MainPage();
            MainPage = new PhoneBookPage();
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
