using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SQLite.Net;
using StickUt.Model;
using StickUt.Interface;
using System.Reflection;
using SQLite.Net.Attributes;

namespace StickUt.MobileApp.Data
{
    public class LocalStorage : ILocalStorage
    {
        private readonly SQLiteConnectionWithLock _dataConnection;

        public LocalStorage(ISQLiteConnectionProvider provider)
        {
            _dataConnection = provider.GetConnection();
            _dataConnection.CreateTable<Workout>();            
        }

        public IEnumerable<T> GetItems<T>() where T : class, new()
        {
            using (_dataConnection.Lock())
            {
                return _dataConnection.Table<T>();
            }
        }

        public void Insert<T>(T obj) where T :class, new()
        {
            using (_dataConnection.Lock())
            {
                _dataConnection.Insert(obj);
            }
        }

        public void Update<T>(T obj) where T :class, new()
        {
            using (_dataConnection.Lock())
            {
                _dataConnection.Update(obj);
            }
        }

        public void Upsert<T>(T obj) where T : class, new()
        {
            var key = typeof(T).GetTypeInfo().DeclaredProperties.FirstOrDefault(attr => attr.CustomAttributes.Any(a => a.AttributeType == typeof(PrimaryKeyAttribute)));
            var id = key.GetValue(obj);
            using (_dataConnection.Lock())
            {
                var existing = this.Query<T>((o) => key.GetValue(o).Equals(id)).Count() == 1;
                if (existing)
                    _dataConnection.Update(obj);
                else
                    _dataConnection.Insert(obj);
            }
        }

        public void Delete<T>(Guid id) where T: class, new()
        {
            using (_dataConnection.Lock())
            {
                _dataConnection.Delete<T>(id);
            }
        }


        public IEnumerable<T> Query<T>(Func<T, bool> query) where T :class, new()
        {
            using (_dataConnection.Lock())
            {
                return _dataConnection.Table<T>().Where(query);
            }
        }
    }
}
