using System.Collections.Generic;

namespace RestApp.Data.Contracts
{
    public interface IGenericRepository<T>
    {
        int Create(T item);
        void CreateRange(List<T> items);
        IEnumerable<T> Read(string searchString = null, int? skip = null, int? limit = null);
        void Update(T item);
        void Delete(int id);
        T GetItem(int id);
    }
}
