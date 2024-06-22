using CoreLayer.BaseEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace RepositoryLayer.Repositories.Abstract
{
    public interface IGenericRepositories<T> where T : class , IBaseEntity , new()
    {
        Task AddEntityAsync(T entity);
        void UpdatetEntity(T entity);
        void DeletetEntity(T entity);
        IQueryable<T> GetAlltEntityList();
        IQueryable<T> Where(Expression<Func<T, bool>> Predicate);

        Task<T> GetEntityByIdAsync(int id);
    }
}
