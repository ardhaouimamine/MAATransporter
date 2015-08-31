using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace TravelerDataProvider
{
    public interface IDatabase<T> where T : class, new()
    {
        void Add(T item);
        void Add(IEnumerable<T> items);
        bool Delete(T item);
        int Delete(Expression<Func<T, bool>> expression);
        void DeleteAll();
        T Single(Expression<Func<T, bool>> expression);
        IQueryable<T> Where(Expression<Func<T, bool>> expression);
        IQueryable<T> All(Expression<Func<T, bool>> expression, int page, int pageSize);
    }
}
