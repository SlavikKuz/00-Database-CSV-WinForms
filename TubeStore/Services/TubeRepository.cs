using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TubeStore.Data;
using TubeStore.Models;

namespace TubeStore.Services
{
    public class TubeRepository : IRepository<Tube>
    {
        private TubeStoreDbContext dbContext;

        public TubeRepository(TubeStoreDbContext dbContext)
        {
            this.dbContext = dbContext;
        }
        
        public async Task Create (Tube item)
        {
            try
            {
                await dbContext.Tubes.AddAsync(item);
                await dbContext.SaveChangesAsync();
            }
            catch (Exception)
            {
                //TODO: Logging
            }
        }

        public async Task Delete(int id)
        {
            try
            {
                Tube tube = await GetById(id);
                dbContext.Tubes.Remove(tube);
                await dbContext.SaveChangesAsync();
            }
            catch (Exception)
            {
                //TODO: Logging
            }
        }

        public async Task Update(Tube item)
        {
            dbContext.Tubes.Update(item);
            await dbContext.SaveChangesAsync();
        }

        public IEnumerable<Tube> GetAll()
        {
            return dbContext.Tubes.Include(x => x.Category);
        }

        public async Task<Tube> GetById(int id)
        {
            return await dbContext.Tubes.Include(x => x.Category).AsNoTracking()
                .FirstOrDefaultAsync(x => x.TubeId == id);
        }
    }
}
