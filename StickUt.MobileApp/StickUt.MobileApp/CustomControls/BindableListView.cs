using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace StickUt.MobileApp.CustomControls
{
    public class BindableListView : ListView
    {
        public static BindableProperty ItemClickedCommandProperty = BindableProperty.Create<BindableListView, ICommand>(x => x.ItemClickedCommand, null);
        public static BindableProperty IsScrollableProperty = BindableProperty.Create<BindableListView, bool>(x => x.IsScrollable, true);

        public bool DestroyCache { get; set; }

        public BindableListView(ListViewCachingStrategy strategy)
            : base(strategy)
        {
            this.ItemTapped += this.OnItemTapped;
        }

        public BindableListView()
        {
            this.ItemTapped += this.OnItemTapped;
        }

        public void Destroy()
        {
            this.ItemTapped -= this.OnItemTapped;
            this.ItemsSource = null;
            this.BindingContext = null;
        }

        public bool IsScrollable
        {
            get { return (bool)this.GetValue(IsScrollableProperty); }
            set { this.SetValue(IsScrollableProperty, value); }
        }

        public ICommand ItemClickedCommand
        {
            get { return (ICommand)this.GetValue(ItemClickedCommandProperty); }
            set { this.SetValue(ItemClickedCommandProperty, value); }
        }

        private void OnItemTapped(object sender, ItemTappedEventArgs e)
        {
            if (this.IsEnabled)
            {
                this.IsEnabled = false;
                if (e.Item != null && this.ItemClickedCommand != null && this.ItemClickedCommand.CanExecute(e))
                {
                    this.ItemClickedCommand.Execute(e.Item);
                    this.SelectedItem = null;
                }
                else if (this.SelectedItem != null)
                {
                    this.SelectedItem = null;
                }
                this.IsEnabled = true;
            }


        }

        protected override void UnhookContent(Cell content)
        {
            base.UnhookContent(content);
        }


    }
}
