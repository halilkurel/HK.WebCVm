using DataAccessLayer.Context;
using DataAccessLayer.Interfaces;
using DataAccessLayer.Repositories;
using EntityLayer.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.UnitOfWork
{
    public class Uow : IUow
    {
        private readonly CVContext _context;

        public Uow(CVContext context)
        {
            _context = context;
        }

        public IRepository<T> GetRepository<T>() where T : BaseEntity
        {
            return new Repository<T>(_context);
        }

        public async Task SaveChanges()
        {
            await _context.SaveChangesAsync();
        }
    }
}
