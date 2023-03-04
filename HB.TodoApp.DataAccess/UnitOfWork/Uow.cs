using HB.TodoApp.DataAccess.Contexts;
using HB.TodoApp.DataAccess.Interfaces;
using HB.TodoApp.DataAccess.Repositories;
using HB.TodoApp.Entities.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HB.TodoApp.DataAccess.UnitOfWork
{
    public class Uow : IUow
    {
        private readonly TodoContext _context;

        public Uow(TodoContext context)
        {
            _context = context;
        }

        public IRepository<T> GetRepository<T>() where T :BaseEntity
        {
            return new Repository<T>(_context);
        }

        public async Task SaveChanges()
        {
            await _context.SaveChangesAsync();
        }
    }
}
