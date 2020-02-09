using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TubeStore.DB;
using TubeStore.Domain.Models;

namespace TubeStore.App.Repository
{
    class TubeRepository : ITubeRepository
    {
        private readonly TubeStoreDbContext tubeStoreDbContext;

        public TubeRepository(TubeStoreDbContext tubeStoreDbContext)
        {
            this.tubeStoreDbContext = tubeStoreDbContext;
        }
        
        public IEnumerable<Tube> GetAllTubes
        {
            get 
            {
                return tubeStoreDbContext.Tubes;
                    //.Incude(x => x.Category);
            }
        }

        public Tube GetTubeById(int tubeId)
        {
            return tubeStoreDbContext.Tubes.FirstOrDefault(x => x.TubeId == tubeId);
        }
    }
}
