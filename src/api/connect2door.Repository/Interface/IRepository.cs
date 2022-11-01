using connect2door.Data.Entity;
using connect2door.Repository.Interface;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using connect2door.Data.BaseEntity;

namespace connect2door.Repository.Interface
{
   public  interface IRepository<T> where T : Entity
    {
        //Task<bool> CreateAsync(T entity);
        //Task<IEnumerable<T>> GetAllAsync();
        //Task<T> GetByIdAsync(string Id);
        //Task<bool> UpdateAsync(T entity);
        //Task<bool> DeleteAsync(string Id);

        Task<IEnumerable<T>> GetAll(); 
        Task<IEnumerable<T>> GetAll(string[] includes);
        Task<T?> Get(string? id);
        Task<T> Insert(T entity);
        Task<T> Update(T entity);
        void Delete(T entity);
    }


}
