using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace StickUt.MobileApp.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ApplicationView : NavigationPage
    {
        public ApplicationView(Page root):base(root)
        {
            InitializeComponent();
            Popped += ApplicationView_Popped;
        }

        private void ApplicationView_Popped(object sender, NavigationEventArgs e)
        {
            Debug.WriteLine($"{e.Page.GetType().Name} was popped");
        }
    }
}
