using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace TubeStore.DataLayer
{
    public class GenericRepository<Entity> : IGenericRepository<Entity>
        where Entity : class
    {
        private readonly TubeStoreDbContext dbContext;
        private readonly IUnitOfWork unitOfWork;

        public GenericRepository(TubeStoreDbContext dbContext)
        {
            this.dbContext = dbContext;
            unitOfWork = new UnitOfWork(dbContext);
        }
              
        public virtual Entity Add(Entity entity)
        {
            dbContext.Set<Entity>().Add(entity);
            dbContext.SaveChanges();
            return entity;
        }

        public virtual async Task<Entity> AddAsync(Entity entity)
        {
            dbContext.Set<Entity>().Add(entity);
            await unitOfWork.Commit();
            return entity;
        }

        public int Count()
        {
            return dbContext.Set<Entity>().Count();
        }

        public async Task<int> CountAsync()
        {
            return await dbContext.Set<Entity>().CountAsync();
        }

        public virtual void Delete(Entity entity)
        {
            dbContext.Set<Entity>().Remove(entity);
            dbContext.SaveChanges();
        }

        public virtual async Task<int> DeleteAsync(Entity entity)
        {
            dbContext.Set<Entity>().Remove(entity);
            return await unitOfWork.Commit();
        }

        private bool disposed = false;
        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if(disposing)
                {
                    dbContext.Dispose();
                }
                this.disposed = true;
            }
        }
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        public virtual Entity Find(Expression<Func<Entity, bool>> match)
        {
            return dbContext.Set<Entity>().SingleOrDefault(match);
        }

        public virtual ICollection<Entity> FindAll(Expression<Func<Entity, bool>> match)
        {
            return dbContext.Set<Entity>().Where(match).ToList();
        }

        public virtual async Task<ICollection<Entity>> FindAllAsync(Expression<Func<Entity, bool>> match)
        {
            return await dbContext.Set<Entity>().Where(match).ToListAsync();
        }

        public virtual async Task<Entity> FindAsync(Expression<Func<Entity, bool>> match)
        {
            return await dbContext.Set<Entity>().SingleOrDefaultAsync(match);
        }

        public virtual IQueryable<Entity> FindBy(Expression<Func<Entity, bool>> predicate)
        {
            IQueryable<Entity> query = dbContext.Set<Entity>().Where(predicate);
            return query;
        }

        public virtual async Task<ICollection<Entity>> FindByAsync(Expression<Func<Entity, bool>> predicate)
        {
            return await dbContext.Set<Entity>().Where(predicate).ToListAsync();
        }

        public virtual Entity Get(int id)
        {
            return dbContext.Set<Entity>().Find(id);
        }

        public IQueryable<Entity> GetAll()
        {
            return dbContext.Set<Entity>();
        }

        public virtual async Task<ICollection<Entity>> GetAllAsync()
        {
            return await dbContext.Set<Entity>().ToListAsync();
        }

        public IQueryable<Entity> GetAllIncluding(params Expression<Func<Entity, object>>[] includeProperties)
        {
            IQueryable<Entity> entities = GetAll();
            foreach (var property in includeProperties)
            {
                entities = entities.Include<Entity, object>(property);
            }
            return entities;
        }

        public virtual async Task<Entity> GetAsync(int id)
        {
            return await dbContext.Set<Entity>().FindAsync(id);
        }

        public virtual Entity Update(Entity entity)
        {
            if (entity == null)
                return null;
            
             dbContext.Set<Entity>().Attach(entity);
             dbContext.Entry(entity).State = EntityState.Modified;
             dbContext.SaveChanges();
            
            return entity;
        }

        public virtual async Task<Entity> UpdateAsync(Entity entity)
        {
            if (entity == null)
                return null;

            dbContext.Set<Entity>().Attach(entity);
            dbContext.Entry(entity).State = EntityState.Modified;
            await unitOfWork.Commit();

            return entity;
        }

        public virtual bool Exist(Expression<Func<Entity, bool>> predicate)
        {
            var exist = dbContext.Set<Entity>().Where(predicate);
            return exist.Any() ? true : false;
        }

        public IQueryable<Entity> GetIncluding(Expression<Func<Entity, bool>> predicate, 
                                               params Expression<Func<Entity, object>>[] includeProperties)
        {
            IQueryable<Entity> entity = FindBy(predicate);
            foreach (var property in includeProperties)
            {
                entity = entity.Include<Entity, object>(property);
            }
            return entity;
        }
    }
}
