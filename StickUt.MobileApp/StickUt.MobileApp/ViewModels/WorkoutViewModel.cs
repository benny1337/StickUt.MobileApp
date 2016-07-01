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

        public WorkoutViewModel(IUserDialogService dialog, ILocalStorage store)
        {
            _dialog = dialog;
            _store = store;

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
