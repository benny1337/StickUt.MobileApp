using Autofac;
using Microsoft.WindowsAzure.MobileServices;
using SQLite.Net.Interop;
using StickUt.Interface;
using StickUt.MobileApp.Views;
using StickUt.MobileApp.Views.SettingsView;
using StickUt.Model;
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
        }

        public static void Init()
        {
            var builder = new ContainerBuilder();
            builder.RegisterModule<Module>();
            Container = builder.Build();
            Builder = builder;

            Task.Factory.StartNew(() =>
            {
                using (var scope = Container.BeginLifetimeScope())
                {
                    var store = scope.Resolve<ILocalStorage>();
                    if (!store.Query<ExerciseType>((x) => { return true; }).Any())
                    {
                        //hämta från servern istället så småningom så man slipper blanda ihop ids
                        store.Insert<ExerciseType>(new ExerciseType()
                        {
                            Id = Guid.NewGuid(),
                            Name = "Bänkpress"
                        });
                        store.Insert<ExerciseType>(new ExerciseType()
                        {
                            Id = Guid.NewGuid(),
                            Name = "Marklyft"
                        });
                        store.Insert<ExerciseType>(new ExerciseType()
                        {
                            Id = Guid.NewGuid(),
                            Name = "Knäböj"
                        });
                    }
                }
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
