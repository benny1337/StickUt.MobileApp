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
        public List<WorkoutType> Types {get;set;}
        public WorkoutType SelectedType { get; set; }

        public WorkoutViewModel(IUserDialogService dialog, ILocalStorage store)
        {
            _dialog = dialog;
            _store = store;
            Types = new List<WorkoutType>()
            {
                WorkoutType.Planned,
                WorkoutType.Unplanned
            };

            MessagingCenter.Subscribe<ViewModelBase, Workout>(this, "WorkoutWasSelected", (sender, w) => 
            {
                _workout = w;
                _dialog.HideDialog();
            });
        }

        public override void ViewIsDisposing()
        {
            
        }
    }
}
