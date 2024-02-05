using Microsoft.EntityFrameworkCore;
using SignalR.Chat.Contexto;
using SignalR.Chat.Interfaces;
using System.Linq.Expressions;

namespace SignalR.Chat.Repository
{
    public class RepositoryBase<T> : IRepositoryBase<T> where T : class
    {
        private readonly ChatContext _conn;

        public RepositoryBase(ChatContext conn)
        {
            _conn = conn;
        }
        public IQueryable<T> GetAll(Expression<Func<T, bool>> filter = null,
        Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null,
        params Expression<Func<T, object>>[] includes
            )
        {
            IQueryable<T> query = _conn.Set<T>(); 
            if(filter != null)
            {
                query = query.Where(filter);
            }
            if(includes != null)
            {
                foreach (var include in includes)
                {
                    query = query.Include(include);
                }
            }
            if(orderBy != null)
            {
                query = orderBy(query);
            }

            return query;
        }

        public bool Add(T entity)
        {
            try
            {
                _conn.Entry(entity).State = EntityState.Added;
                _conn.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public bool Delete(T entity)
        {
            try
            {
                _conn.Entry(entity).State = EntityState.Deleted;
                _conn.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public T? Get(int id)
        {
            try
            {
                var result = _conn.Set<T>().Find(id);
                return result;
            }
            catch(Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public T GetByString(string name)
        {
            throw new NotImplementedException();
        }

        public bool Update(T entity)
        {
            try
            {
                _conn.Entry(entity).State = EntityState.Modified;
                _conn.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }
    }
}
