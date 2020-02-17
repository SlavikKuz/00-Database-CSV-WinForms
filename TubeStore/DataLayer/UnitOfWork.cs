using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TubeStore.DataLayer
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly TubeStoreDbContext dbContext;
        private readonly Dictionary<Type, object> repositories = new Dictionary<Type, object>();

        public Dictionary<Type, object> Repositories
        {
            get { return repositories; }
            set { Repositories = value; }
        }

        public UnitOfWork(TubeStoreDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public IGenericRepository<Entity> Repository<Entity>() where Entity : class
        {
            if(Repositories.Keys.Contains(typeof(Entity)))
            {
                return Repositories[typeof(Entity)] as IGenericRepository<Entity>;
            }
            IGenericRepository<Entity> repo = new GenericRepository<Entity>(dbContext);
            Repositories.Add(typeof(Entity), repo);
            return repo;
        }

        public async Task<int> Commit()
        {
            return await dbContext.SaveChangesAsync();
        }

        public void Rollback()
        {
            dbContext.ChangeTracker.Entries().ToList().ForEach(x => x.Reload());
        }
    }
}
