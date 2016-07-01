using Autofac;
using StickUt.Interface;
using StickUt.MobileApp.Data.api;
using StickUt.MobileApp.Views;
using StickUt.MobileApp.Views.SettingsView;
using StickUt.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace StickUt.MobileApp.ViewModels
{
    public class StartViewModel : ViewModelBase
    {
        public StartViewModel(ILocalStorage store, IUserDialogService dialog, WorkoutCommunicator comm)
        {
            _store = store;
            _dialog = dialog;
            _comm = comm;            
            LoadWorkouts();

            MessagingCenter.Subscribe<Workout, ViewModelBase>(this, "WorkoutWasEdited", (w, sender) =>
            {
                var existing = Workouts.Where(x => x.Id == w.Id).FirstOrDefault();
                if (existing != null)
                {
                    existing = w;
                }
            });
        }

        private void LoadWorkouts()
        {
            Workouts = new ObservableCollection<Workout>();
            _dialog.ShowSpinner();
            Task.Factory.StartNew(async () =>
            {
                var ws = await _comm.ReadFromLocalStoreAsync();
                Workouts = ws.ToObservableCollection();
                OnPropertyChanged("Workouts");
                _dialog.HideDialog();
            });
        }

        private Command _addWorkout;
        private ILocalStorage _store;
        private IUserDialogService _dialog;
        private WorkoutCommunicator _comm;        
        public ObservableCollection<Workout> Workouts { get; set; }

        private Workout _selectedWorkout;
        public Workout SelectedWorkout
        {
            get
            {
                return _selectedWorkout;
            }
            set
            {
                _selectedWorkout = value;
                if (_selectedWorkout == null)
                    return;

                _dialog.ShowSpinner();
                Task.Factory.StartNew(() =>
                {
                    using (var scope = App.Container.BeginLifetimeScope())
                    {
                        var view = scope.Resolve<WorkoutView>();
                        MessagingCenter.Send<ViewModelBase, Workout>(this, "WorkoutWasSelected", _selectedWorkout);
                        Device.BeginInvokeOnMainThread(async () => { await App.Context.Navigation.PushAsync(view); });
                    }
                });
            }
        }

        public Command AddWorkout
        {
            get
            {
                return _addWorkout ?? (_addWorkout = new Command(() =>
                {                   
                    var w = new Workout()
                    {
                        Id = Guid.NewGuid()
                    };
                    Workouts.Add(w);

                    Task.Factory.StartNew(() =>
                    {
                        _store.Insert<Workout>(w);
                    });
                }));
            }
        }


        public override void ViewIsDisposing()
        {
            MessagingCenter.Unsubscribe<Workout, ViewModelBase>(this, "WorkoutWasEdited");
        }


    }
}
