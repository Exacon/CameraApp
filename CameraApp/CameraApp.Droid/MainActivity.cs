using System;

using Android.App;
using Android.Content;
using Android.Content.PM;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;
using Android.Provider;
using Java.IO;

namespace CameraApp.Droid
{
    [Activity(Label = "CameraApp", Icon = "@drawable/icon", MainLauncher = true, ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation)]
    public class MainActivity : global::Xamarin.Forms.Platform.Android.FormsApplicationActivity
    {
        static readonly File file =new File(Android.OS.Environment.GetExternalStoragePublicDirectory(Android.OS.Environment.DirectoryPictures),"tmp.jpg");


        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);

            global::Xamarin.Forms.Forms.Init(this, bundle);
            LoadApplication(new App());


            var app = Xamarin.Forms.Application.Current as App;
            if (app != null)
                app.TakeAPicture += () =>
                {
                    var intent = new Intent(MediaStore.ActionImageCapture);
                    intent.PutExtra(MediaStore.ExtraOutput, Android.Net.Uri.FromFile(file));
                    StartActivityForResult(intent,0);
                    
                };
            app.Update(file.Path);

            var o = Xamarin.Forms.Application.Current as App;
            if (o != null)
                o.ShowImage((file.Path));
        }
    }
}

