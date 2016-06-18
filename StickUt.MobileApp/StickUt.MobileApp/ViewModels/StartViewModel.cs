using Autofac;
using StickUt.MobileApp.Views.SettingsView;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace StickUt.MobileApp.ViewModels
{
    public class StartViewModel
    {
        private Command _buttoncmd;
        public Command buttoncmd
        {
            get
            {
                return _buttoncmd ?? (_buttoncmd = new Command(() => 
                {   
                    using (var scope = App.Container.BeginLifetimeScope())
                    {
                        var view = scope.Resolve<MainSettingsView>();
                        Debug.WriteLine(view.GetType().ToString());
                        Device.BeginInvokeOnMainThread(async () => 
                        { await App.Context.Navigation.PushAsync(view); });                        
                    }                 
                }));
            }
        }
    }
}
