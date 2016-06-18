﻿using StickUt.MobileApp.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;

namespace StickUt.MobileApp.Views
{
    public partial class StartView : ContentPage
    {
        public StartView(StartViewModel vm)
        {         
            InitializeComponent();
            this.BindingContext = vm;
        }
    }
}
