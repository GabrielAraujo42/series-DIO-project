using System.Collections.Generic;

namespace Series.Interfaces
{
    interface IRepository<T>
    {
        List<T> GetList();
        T GetById(int id);
        void Insert(T value);
        void Remove(int id);
        void Update(int id, T value);
        int NextId();
    }
}
