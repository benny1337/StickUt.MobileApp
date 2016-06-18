using System;

using Android.App;
using Android.Content.PM;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;
using SQLite.Net.Platform.XamarinAndroid;
//using SQLite.Net.Interop;
using Autofac;

namespace StickUt.MobileApp.Droid
{
    [Activity(Label = "StickUt.MobileApp", Icon = "@drawable/icon", MainLauncher = true, ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation)]
    public class MainActivity : global::Xamarin.Forms.Platform.Android.FormsApplicationActivity
    {
        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);

            global::Xamarin.Forms.Forms.Init(this, bundle);

            //ISQLitePlatform _platform = new SQLitePlatformAndroid();

            //App.Platform = _platform;
            App.Init();
            
            //FFImaging initialization
            //CachedImageRenderer.Init();

            var newbuilder = new ContainerBuilder();            
            //newbuilder.RegisterInstance(_platform).As<ISQLitePlatform>().SingleInstance();
            //newbuilder.RegisterType<PlatformSpecifics.DatabaseConnectionProvider>().As<IDatabaseConnectionProvider>().SingleInstance();


            newbuilder.Update(App.Container);
            App.Builder = newbuilder;

            LoadApplication(new App());
        }
    }
}

