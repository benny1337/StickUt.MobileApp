using Autofac;
using Microsoft.WindowsAzure.MobileServices;
using SQLite.Net.Interop;
using StickUt.Interface;
using StickUt.MobileApp.Views;
using StickUt.MobileApp.Views.SettingsView;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace StickUt.MobileApp
{
    public class App : Application
    {
        public static IContainer Container { get; set; }
        public static ContainerBuilder Builder { get; set; }
        public static ISQLitePlatform Platform { get; set; }
        public static ApplicationContext Context { get; set; }
        public static MobileServiceClient Client { get; set; }
        public static MobileServiceUser User { get; set; }
        public App()
        {     
            Context = Container.Resolve<ApplicationContext>();                
            MainPage = Container.Resolve<MasterDetailPage>();
            Client = new MobileServiceClient("http://stickutapp.azurewebsites.net");

            if(User == null)
            {
                Task.Factory.StartNew(() => 
                {
                    using (var scope = Container.BeginLifetimeScope())
                    {
                        var auth = scope.Resolve<IAuthorize>();
                        auth.StartAuthorizationAsync();
                    };
                });
            }
        }

        public static void Init()
        {
            var builder = new ContainerBuilder();
            builder.RegisterModule<Module>();
            Container = builder.Build();
            Builder = builder;
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
