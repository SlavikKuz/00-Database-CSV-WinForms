using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace TubeStore.DataLayer
{
    public interface IGenericRepository<Entity> where Entity : class
    {
        Entity Add(Entity entity);
        Task<Entity> AddAsync(Entity entity);

        int Count();
        Task<int> CountAsync();

        void Delete(Entity entity);
        Task<int> DeleteAsync(Entity entity);

        void Dispose();

        Entity Find(Expression<Func<Entity, bool>> match);
        ICollection<Entity> FindAll(Expression<Func<Entity, bool>> match);
        Task<ICollection<Entity>> FindAllAsync(Expression<Func<Entity, bool>> match);
        Task<Entity> FindAsync(Expression<Func<Entity, bool>> match);
        IQueryable<Entity> FindBy(Expression<Func<Entity, bool>> predicate);
        Task<ICollection<Entity>> FindByAsync(Expression<Func<Entity, bool>> predicate);

        Entity Get(int id);
        IQueryable<Entity> GetAll();
        Task<ICollection<Entity>> GetAllAsync();
        IQueryable<Entity> GetIncluding(Expression<Func<Entity, bool>> match, params Expression<Func<Entity, object>>[] includeProperties);
        IQueryable<Entity> GetAllIncluding(params Expression<Func<Entity, object>>[] includeProperties);
        Task<Entity> GetAsync(int id);
        
        Entity Update(Entity entity);
        Task<Entity> UpdateAsync(Entity entity);

        bool Exist(Expression<Func<Entity, bool>> predicate);
    }
}
