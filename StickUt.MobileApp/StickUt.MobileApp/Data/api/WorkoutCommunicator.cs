using StickUt.Interface;
using StickUt.Model;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StickUt.MobileApp.Data.api
{
    public class WorkoutCommunicator : CommunicatorBase
    {
        public WorkoutCommunicator(ILocalStorage store) :base(store) { }
        public async Task<IEnumerable<Workout>> ReadFromApiAsync()
        {
            return await App.Client.InvokeApiAsync<IEnumerable<Workout>>("workout");
        }

        public async Task<IEnumerable<Workout>> ReadFromLocalStoreAsync()
        {
            return await Task.Factory.StartNew(() => 
            {
                try {
                    return _store.GetItems<Workout>();
                } catch (Exception e)
                {
                    Debug.WriteLine(e.Message + e.StackTrace);
                    return new List<Workout>();
                }
            });
        }
    }
}
