using Autofac;
using Newtonsoft.Json;
using StickUt.Interface;
using StickUt.Model;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace StickUt.MobileApp.Data
{
    public class CommunicatorBase
    {
        protected ILocalStorage _store;
        private const string BASEPATH = "https://stickutapp.azurewebsites.net/api/";


        public CommunicatorBase(ILocalStorage store)
        {
            _store = store;
        }
        public HttpClient GetAuthedClient()
        {
            var dc = new HttpClient();
            dc.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", App.User.MobileServiceAuthenticationToken);
            return dc;
        }

        public async Task<IEnumerable<Workout>> Get(string path, bool showerror = true)
        {
            try
            {
                if (App.Client == null)
                    return new List<Workout>();

                var x = await App.Client.InvokeApiAsync<IEnumerable<Workout>>("workout");
                return x;
            } catch(Exception e)
            {
                if (showerror)
                {
                    using (var scope = App.Container.BeginLifetimeScope())
                    {
                        var dialog = scope.Resolve<IUserDialogService>();                        
                        dialog.Toast($"Ett fel uppstod: {e.Message}");
                    }
                }
                else
                    Debug.WriteLine(e.Message + e.StackTrace);

                return new List<Workout>();
            }
            
        }
    }
}
