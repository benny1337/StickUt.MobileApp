using StickUt.Interface;
using StickUt.MobileApp.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace StickUt.MobileApp.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class WorkoutView : ContentPage, IViewWithViewModel
    {
        private IViewModel _vm;

        public WorkoutView(WorkoutViewModel vm)
        {
            _vm = vm;
            InitializeComponent();
            BindingContext = vm;
        }

        public IViewModel GetViewModel()
        {
            return _vm;
        }
    }
}
