using Microsoft.EntityFrameworkCore;
using connect2door.Data;
using connect2door.Data.BaseEntity;
using connect2door.Repository.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace connect2door.Repository.Repository
{

    public class Repository<T> : IRepository<T> where T : Entity
    {
        private readonly DataContext _context;
        private readonly DbSet<T> _entities;
        string _errorMessage = string.Empty;
        public Repository(DataContext context)
        {
            _context = context;
            _entities = context.Set<T>();
        }
        public async Task<IEnumerable<T>> GetAll()
        {
            return await _entities.ToListAsync();
        }
        public async Task<IEnumerable<T>> GetAll(string[] includes)
        {
            return await includes.Aggregate(_entities.AsQueryable(), (query, path) => query.Include(path)).ToListAsync();
        }
        public async Task<T?> Get(string? id)
        {
            return await _entities.SingleOrDefaultAsync(s => s.Id == id);
        }
        public async Task<T> Insert(T entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException(nameof(entity));
            }
            _entities.Add(entity);
            await _context.SaveChangesAsync();
            return entity;
        }
        public async Task<T> Update(T entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException(nameof(entity));
            }
            await _context.SaveChangesAsync();
            return entity;
        }
        public void Delete(T entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException(nameof(entity));
            }
            _entities.Remove(entity);
            _context.SaveChanges();
        }


    }
}
