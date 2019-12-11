using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAppStore.Models
{
    public class CategoryRepository:ICategoryRepository
    {
        private StoreDbContext storeDbContext;

        public CategoryRepository(StoreDbContext storeDbContext)
        {
            this.storeDbContext = storeDbContext;
        }

        public IEnumerable<Category> Categories => storeDbContext.Categories;
    }
}
