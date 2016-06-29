using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StickUt.Interface
{
    public delegate void OnAuthorizationDone();
    public interface IAuthorize
    {
        Task StartAuthorizationAsync();        
    }
}
