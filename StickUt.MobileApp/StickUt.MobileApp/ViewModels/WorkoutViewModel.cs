using StickUt.Interface;
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
        private IUserDialogService _dialog;
        private ILocalStorage _store;
        private Workout _workout;
        public List<ExerciseType> Types {get;set;}

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

        public WorkoutViewModel(IUserDialogService dialog, ILocalStorage store)
        {
            _dialog = dialog;
            _store = store;
            Task.Factory.StartNew(() => 
            {
                Types = store.GetItems<ExerciseType>().ToList();
                OnPropertyChanged("Types");
            });
            
            MessagingCenter.Subscribe<ViewModelBase, Workout>(this, "WorkoutWasSelected", (sender, w) => 
            {
                _workout = w;
                _dialog.HideDialog();
            });
        }

        public override void ViewIsDisposing()
        {
            MessagingCenter.Unsubscribe<ViewModelBase, Workout>(this, "WorkoutWasSelected");
        }
    }
}
