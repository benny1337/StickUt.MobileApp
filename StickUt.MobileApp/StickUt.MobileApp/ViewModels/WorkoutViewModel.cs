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
        private ExerciseType _selectedType;

        private int _selectedTypeIndex;        
        public int SelectedTypeIndex
        {
            get
            {
                return _selectedTypeIndex;
            }

            set
            {
                _selectedTypeIndex = value;
                if (_selectedTypeIndex == -1)
                    _selectedType = null;
                else
                    _selectedType = Types[value];         
                OnPropertyChanged();
            }
        }

        private Command<Exercise> removeExerciseCommand;
        private Command<Exercise> exerciseSelectedCommand;
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
                    if(_selectedType == null)
                    {
                        _dialog.Toast("Typ av övning måste väljas");
                        return;
                    }
                    var e = new Exercise()
                    {
                        ExerciseTypeId = _selectedType.Id,
                        WorkoutId = _workout.Id,
                        Id = Guid.NewGuid()
                    };
                    _store.Insert<Exercise>(e);
                    Exercises.Add(e);
                    Exercises = Exercises;
                    SelectedTypeIndex = -1;                    
                }));
            }            
        }

        public Command<Exercise> RemoveExerciseCommand
        {
            get
            {
                return removeExerciseCommand ?? (removeExerciseCommand = new Command<Exercise>((e) => 
                {

                }));
            }            
        }

        public Command<Exercise> ExerciseSelectedCommand
        {
            get
            {
                return exerciseSelectedCommand ?? (exerciseSelectedCommand = new Command<Exercise>((e) => 
                {

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
