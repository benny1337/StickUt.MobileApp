using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StickUt.Interface
{
    public interface ILocalStorage
    {
        IEnumerable<T> GetItems<T>() where T : class, new();
        void Insert<T>(T obj) where T : class, new();
        void Update<T>(T obj) where T : class, new();
        void Upsert<T>(T obj) where T : class, new();
        IEnumerable<T> Query<T>(Func<T, bool> query) where T : class, new();
        void Delete<T>(Guid id) where T : class, new();
    }
}
