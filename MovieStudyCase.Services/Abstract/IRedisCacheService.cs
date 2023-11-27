using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieStudyCase.Services.Abstract
{
    public interface IRedisCacheService
    {
        T Get<T>(string key);
        IList<T> GetAll<T>(string key);
        void Set(string key, object data);
        void Set(string key, object data, DateTime time);
        void SetAll<T>(IDictionary<string, T> values);
        bool IsSet(string key);
        void Remove(string key);
        void RemoveByPattern(string pattern);
        int Count(string key);
    }
}
