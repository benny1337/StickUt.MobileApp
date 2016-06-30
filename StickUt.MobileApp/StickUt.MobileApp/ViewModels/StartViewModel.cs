using Autofac;
using StickUt.Interface;
using StickUt.MobileApp.Data;
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
    public class StartViewModel:ViewModelBase
    {
        public StartViewModel(ILocalStorage store, IUserDialogService dialog, CommunicatorBase comm)
        {
            _store = store;
            _dialog = dialog;
            _comm = comm;
        }

        private Command _buttoncmd;
        private ILocalStorage _store;        
        private IUserDialogService _dialog;
        private CommunicatorBase _comm;

        private List<Workout> _workouts;
        public List<Workout> Workouts
        {
            get
            {
                return _workouts;
            }
            set
            {
                _workouts = value;
                OnPropertyChanged();
            }
        }

        public Command buttoncmd
        {
            get
            {
                return _buttoncmd ?? (_buttoncmd = new Command(() =>
                {
                    _dialog.ShowSpinner();
                    Task.Factory.StartNew(async () =>
                    {                        
                        var res = await _comm.Get("workout");
                        Workouts = res.ToList();
                        _dialog.HideDialog();
                    });
                }));
            }
        }

    }
}
