using Autofac;
using Newtonsoft.Json;
using StickUt.Interface;
using StickUt.Model;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace StickUt.MobileApp.Data
{
    public class CommunicatorBase
    {
        protected ILocalStorage _store;

        public CommunicatorBase(ILocalStorage store)
        {
            _store = store;
        }       
    }
}
