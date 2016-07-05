using Autofac;
using Microsoft.WindowsAzure.MobileServices;
using StickUt.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace StickUt.MobileApp
{
    public class ApplicationContext
    {
        public INavigation Navigation { get; set; }
        private MobileServiceUser _user;
        public async Task<MobileServiceUser> GetUser()
        {
            if(_user == null)
            {
                await Task.Factory.StartNew(async () =>
                {
                    using (var scope = App.Container.BeginLifetimeScope())
                    {
                        var auth = scope.Resolve<IAuthorize>();
                        await auth.StartAuthorizationAsync();
                        _user = App.User;
                    };
                });
            }

            return _user;
        }
    }
}
