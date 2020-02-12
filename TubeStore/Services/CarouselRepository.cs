using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TubeStore.Data;
using TubeStore.Models;

namespace TubeStore.Services
{
    public class CarouselRepository : IRepository<Carousel>
    {
        private TubeStoreDbContext dbContext;

        public CarouselRepository(TubeStoreDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public async Task Create(Carousel item)
        {
            try
            {
                await dbContext.Carousels.AddAsync(item);
                await dbContext.SaveChangesAsync();
            }
            catch (Exception)
            {
                //TODO: logging
            }
        }

        public async Task Delete(int id)
        {
            try
            {
                Carousel carousel = await GetById(id);
                dbContext.Carousels.Remove(carousel);
                await dbContext.SaveChangesAsync();
            }
            catch (Exception)
            {
                //TODO: logging
            }
        }

        public IEnumerable<Carousel> GetAll()
        {
            return dbContext.Carousels;
        }

        public async Task<Carousel> GetById(int id)
        {
            return await dbContext.Carousels.AsNoTracking()
                .FirstOrDefaultAsync(x => x.CarouselId == id);
        }

        public async Task Update(Carousel item)
        {
            dbContext.Carousels.Update(item);
            await dbContext.SaveChangesAsync();
        }
    }
}
