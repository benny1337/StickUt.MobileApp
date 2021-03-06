using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using StickUt.Interface;
using AndroidHUD;

namespace StickUt.MobileApp.Droid.PlatformSpecifics
{
    public class UserDialogService : IUserDialogService
    {
        public void HideDialog()
        {
            AndHUD.Shared.Dismiss(Xamarin.Forms.Forms.Context);
        }

        public void ShowSpinner(Action onClick = null, string Title = "Arbetar")
        {
            try
            {
                AndHUD.Shared.Show(Xamarin.Forms.Forms.Context, Title, -1, MaskType.Clear, null, onClick);
            } catch (Exception e)
            {

            }
        }

        public void Toast(string message, Action onClick = null)
        {
            if (onClick == null)
            {
                onClick = new Action(() => {
                    this.HideDialog();
                });
            }
            AndHUD.Shared.ShowToast(Xamarin.Forms.Forms.Context, message, clickCallback: onClick);
        }
    }
}