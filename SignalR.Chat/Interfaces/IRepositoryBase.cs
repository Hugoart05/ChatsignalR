using System.Linq.Expressions;

namespace SignalR.Chat.Interfaces
{
    public interface IRepositoryBase<T> where T : class
    {
        IQueryable<T> GetAll(Expression<Func<T, bool>> filter = null,
                Func<IQueryable<T>, IOrderedQueryable<T>> orderby = null,
                params Expression<Func<T, object>>[] includes);
        T? Get(int id);
        T GetByString(string name);
        bool Add(T entity);
        bool Update(T entity);
        bool Delete(T entity);
    }
}
