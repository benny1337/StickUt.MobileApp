using System;

using Android.App;
using Android.Content.PM;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;
using SQLite.Net.Platform.XamarinAndroid;
using Autofac;
using Xamarin.Forms.Platform.Android;
using SQLite.Net.Interop;
using StickUt.MobileApp.Data;
using StickUt.MobileApp.Droid.PlatformSpecifics;
using StickUt.Interface;
using Xamarin.Auth;

namespace StickUt.MobileApp.Droid
{
    [Activity(Label = "stickut", Icon = "@drawable/icon", MainLauncher = true, ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation)]
    public class MainActivity : FormsAppCompatActivity, IAuthorize
    {
        public void StartAuthorization()
        {
            var auth = new OAuth2Authenticator(
   clientId: "1729539360643718",   
   scope: "",
   authorizeUrl: new Uri("https://m.facebook.com/dialog/oauth/"),
   redirectUrl: new Uri("http://stickutweb20160619103903.azurewebsites.net/"));
            
            auth.Completed += Auth_Completed;            
            StartActivity(auth.GetUI(this));
        }

        private void Auth_Completed(object sender, AuthenticatorCompletedEventArgs e)
        {
            
        }

        protected override void OnCreate(Bundle bundle)
        {
            FormsAppCompatActivity.ToolbarResource = Resource.Layout.toolbars;
            FormsAppCompatActivity.TabLayoutResource = Resource.Layout.tabs;
            base.OnCreate(bundle);

            global::Xamarin.Forms.Forms.Init(this, bundle);

            var _platform = new SQLitePlatformAndroid();

            App.Platform = _platform;
            App.Init();

            //FFImaging initialization
            //CachedImageRenderer.Init();

            var newbuilder = new ContainerBuilder();
            newbuilder.RegisterInstance(_platform).As<ISQLitePlatform>().SingleInstance();
            newbuilder.RegisterType<PlatformSpecifics.DatabaseConnectionProvider>().As<ISQLiteConnectionProvider>().SingleInstance();
            newbuilder.RegisterType<UserDialogService>().As<IUserDialogService>();
            newbuilder.RegisterInstance(this).As<IAuthorize>().SingleInstance();
            newbuilder.Update(App.Container);            
            App.Builder = newbuilder;

            LoadApplication(new App());
        }
    }
}

