﻿using StickUt.Interface;
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
    public partial class StartView : ContentPage, IViewWithViewModel
    {
        private IViewModel _vm;
        public StartView(StartViewModel vm)
        {         
            InitializeComponent();
            _vm = vm;
            this.BindingContext = vm;
        }

        public IViewModel GetViewModel()
        {
            return _vm;
        }
    }
}
