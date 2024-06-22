using RepositoryLayer.Context;
using RepositoryLayer.Repositories.Abstract;
using RepositoryLayer.Repositories.Concrete;
using RepositoryLayer.UnitOfWorks.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RepositoryLayer.UnitOfWorks.Concrete
{
    public class UnitOfWork : IUnitOfWorks
    {
        private readonly AppDbContext _context;
        
        public UnitOfWork(AppDbContext context)
        {
            _context = context;
        }

        public void Commit()
        {
            _context.SaveChanges();
        }

        public async Task CommitAsnyc()
        {
            await _context.SaveChangesAsync();
        }

        public ValueTask DisposeAsnyc()
        {
            return _context.DisposeAsync();
        }

        IGenericRepositories<T> IUnitOfWorks.GetGenericRepositories<T>()
        {
            return new GenericRepositories<T>(_context);
        }
    }
}
