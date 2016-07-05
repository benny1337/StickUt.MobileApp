using StickUt.Interface;
using StickUt.MobileApp.Data.api;
using StickUt.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace StickUt.MobileApp.ViewModels
{
    public class WorkoutViewModel : ViewModelBase
    {
        public WorkoutViewModel(IUserDialogService dialog, ILocalStorage store, ExerciseCommunicator comm)
        {
            _dialog = dialog;
            _store = store;
            _comm = comm;
            Task.Factory.StartNew(() => 
            {
                Types = store.GetItems<ExerciseType>().ToList();
                OnPropertyChanged("Types");
            });
            
            MessagingCenter.Subscribe<ViewModelBase, Workout>(this, "WorkoutWasSelected", (sender, w) => 
            {
                _workout = w;
                Task.Factory.StartNew(async() => 
                {
                    var exercises = await _comm.LoadExercisesAsync(w.Id);
                    Exercises = exercises.ToList();   
                    _dialog.HideDialog();
                });                
            });
        }

        private IUserDialogService _dialog;
        private ILocalStorage _store;
        private Workout _workout;
        public List<ExerciseType> Types { get; set; }

        private ExerciseType selectedType;
        public ExerciseType SelectedType
        {
            get
            {
                return selectedType;
            }

            set
            {
                selectedType = value;
                OnPropertyChanged();
            }
        }

        private Command addExercise;

        public List<Exercise> Exercises
        {
            get
            {
                return exercises;
            }

            set
            {
                exercises = value;
                OnPropertyChanged();
            }
        }

        public Command AddExercise
        {
            get
            {
                return addExercise ?? (addExercise = new Command(() => 
                {
                    var e = new Exercise()
                    {
                        ExerciseType = SelectedType,
                        WorkoutId = _workout.Id,
                        Id = Guid.NewGuid()
                    };
                    _store.Insert<Exercise>(e);
                    Exercises.Add(e);
                    OnPropertyChanged("Exercises");
                }));
            }            
        }

        private List<Exercise> exercises;
        private ExerciseCommunicator _comm;

        public override void ViewIsDisposing()
        {
            MessagingCenter.Unsubscribe<ViewModelBase, Workout>(this, "WorkoutWasSelected");
        }
    }
}
