using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StickUt.Interface
{
    public interface IUserDialogService
    {
        void HideDialog();
        void ShowSpinner(Action onClick = null, string Title = "Arbetar");
        void Toast(string message, Action onClick = null);
    }
}
