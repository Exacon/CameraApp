using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Xamarin.Forms;

namespace CameraApp
{
    public class App : Application
    {
        readonly Image image = new Image();


        public App()
        {
            MainPage = new ContentPage
            {
                Content = new StackLayout
                {
                    VerticalOptions = LayoutOptions.Center,
                    Children =
                    {
                        new Button
                        {
                            Text = "Ta et bilde",
                            Command = new Command(o => TakeAPicture()),
                        },
                        image,
                    },
                },
            };
        }

        public event Action TakeAPicture = () => { };

        public void ShowImage(string path)
        {
            Device.BeginInvokeOnMainThread(() =>
            {
                image.Source = ImageSource.FromFile(path);
            });

        }

        public void Update(string path)
        {
            Device.BeginInvokeOnMainThread(() =>
            {
                image.Source = ImageSource.FromFile(path);
            });
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
