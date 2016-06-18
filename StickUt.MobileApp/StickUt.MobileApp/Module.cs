using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Autofac;
using StickUt.MobileApp.Views.SettingsView;
using StickUt.MobileApp.Views;

namespace StickUt.MobileApp
{
    class Module : Autofac.Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            base.Load(builder);

            //views
            builder.RegisterType<StartView>();

            //settings views
            builder.RegisterType<MainSettingsView>();
        }
    }
}
