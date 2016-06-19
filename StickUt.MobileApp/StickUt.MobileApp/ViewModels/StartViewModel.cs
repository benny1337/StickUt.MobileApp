using Autofac;
using StickUt.Interface;
using StickUt.MobileApp.Views.SettingsView;
using StickUt.Model;
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
        public StartViewModel(ILocalStorage store)
        {
            _store = store;
        }

        private Command _buttoncmd;
        private ILocalStorage _store;

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
