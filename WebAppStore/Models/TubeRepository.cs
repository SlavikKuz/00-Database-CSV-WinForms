using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAppStore.Models
{
    public class TubeRepository : ITubeRepository
    {
        private readonly StoreDbContext storeDbContext;

        public TubeRepository(StoreDbContext storeDbContext)
        {
            this.storeDbContext = storeDbContext;
        }
        
        public IEnumerable<Tube> Tubes
        {
            get
            {
                return storeDbContext.Tubes.Include(x => x.Category);
            }
        }

        public IEnumerable<Tube> TubesOfTheWeek
        {
            get
            {
                return storeDbContext.Tubes.Include(x => x.Category).Where(t => t.IsTubeOfTheWeek);
            }
        }

        public Tube GetTubeById(int tubeId)
        {
            return storeDbContext.Tubes.FirstOrDefault(x => x.TubeId == tubeId);
        }
    }
}
