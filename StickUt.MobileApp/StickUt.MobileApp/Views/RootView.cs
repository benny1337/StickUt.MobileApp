using Autofac;
using StickUt.MobileApp.Views.SettingsView;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace StickUt.MobileApp.Views
{
    public class RootView : MasterDetailPage
    {
        public RootView()
        {
            using (var score = App.Container.BeginLifetimeScope())
            {
                var settings = score.Resolve<MainSettingsView>();
                Master = settings;

                var details = score.Resolve<StartView>();
                Master = settings;

                App.Context.Navigation = Detail.Navigation;
            }            
        }

        public async Task SetRootNavigation(Page detail, Page master)
        {
            await Detail.Navigation.PopToRootAsync(false);
            NavigationPage.SetHasBackButton(detail, false);
            await Detail.Navigation.PushAsync(detail);
            Detail.Navigation.RemovePage(Detail.Navigation.NavigationStack[0]);

            Master = master;
        }
    }
}
