using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Autofac;
using StickUt.MobileApp.Views.SettingsView;
using StickUt.MobileApp.Views;
using StickUt.MobileApp.ViewModels;
using Xamarin.Forms;
using StickUt.Interface;
using StickUt.MobileApp.Data;

namespace StickUt.MobileApp
{
    class Module : Autofac.Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            base.Load(builder);
            builder.RegisterType<ApplicationContext>().SingleInstance().PropertiesAutowired();
            builder.RegisterType<LocalStorage>().As<ILocalStorage>().SingleInstance();

            //viewmodels 
            builder.RegisterType<StartViewModel>();

            //views
            builder.RegisterType<RootView>().As<MasterDetailPage>().SingleInstance();
            builder.RegisterType<StartView>();

            //settings views
            builder.RegisterType<MainSettingsView>();
        }
    }
}
