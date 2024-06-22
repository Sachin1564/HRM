using CoreLayer.BaseEntities;
using RepositoryLayer.Repositories.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RepositoryLayer.UnitOfWorks.Abstract
{
    public interface IUnitOfWorks
    {
        void Commit();
        Task CommitAsnyc();
        IGenericRepositories<T> GetGenericRepositories<T>() where T : class, IBaseEntity, new();
        ValueTask DisposeAsnyc();
        
       

    }
}
