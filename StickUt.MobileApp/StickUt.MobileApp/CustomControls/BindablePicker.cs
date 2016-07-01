using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace StickUt.MobileApp.CustomControls
{
    public class BindablePicker : Picker
    {
        public BindablePicker()
        {
            this.SelectedIndexChanged += OnSelectedIndexChanged;
        }
        //public static BindableProperty ItemsSourceProperty =
        //    BindableProperty.Create<BindablePicker, IEnumerable>(o => o.ItemsSource, default(IEnumerable), propertyChanged: OnItemsSourceChanged);

        public static readonly BindableProperty ItemsSourceProperty = BindableProperty.Create("ItemsSource", typeof(List<string>), typeof(BindablePicker), null, BindingMode.OneWay, null, propertyChanged: OnItemsSourceChanged);


        //public static BindableProperty SelectedItemProperty =
        //    BindableProperty.Create<BindablePicker, object>(o => o.SelectedItem, default(object), propertyChanged: OnSelectedItemChanged);

        public static readonly BindableProperty SelectedItemProperty = BindableProperty.Create("SelectedItem", typeof(List<string>), typeof(BindablePicker), null, BindingMode.OneWay, null, propertyChanged: OnSelectedItemChanged);

        public IEnumerable ItemsSource
        {
            get { return (IEnumerable)GetValue(ItemsSourceProperty); }
            set { SetValue(ItemsSourceProperty, value); }
        }

        public object SelectedItem
        {
            get { return (object)GetValue(SelectedItemProperty); }
            set { SetValue(SelectedItemProperty, value); }
        }

        private static void OnItemsSourceChanged(BindableObject bindable, object oldValue, object newValue)
        {
            var picker = bindable as BindablePicker;
            picker.Items.Clear();
            if ((List<string>)newValue != null)
            {
                //now it works like "subscribe once" but you can improve
                foreach (var item in (List<string>)newValue)
                {
                    picker.Items.Add(item.ToString());
                }
            }
        }

        private void OnSelectedIndexChanged(object sender, EventArgs eventArgs)
        {
            if (SelectedIndex < 0 || SelectedIndex > Items.Count - 1)
            {
                SelectedItem = null;
            }
            else
            {
                SelectedItem = Items[SelectedIndex];
            }
        }

        private static void OnSelectedItemChanged(BindableObject bindable, object oldvalue, object newvalue)
        {
            var picker = bindable as BindablePicker;
            if (newvalue != null)
            {
                picker.SelectedIndex = picker.Items.IndexOf(newvalue.ToString());
            }
        }
    }
}
