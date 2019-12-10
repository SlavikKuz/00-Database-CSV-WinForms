using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAppStore.Models
{
    public class MockCategoryRepository : ICategoryRepository
    {
        public IEnumerable<Category> Categories
        {
            get 
            {
                return new List<Category>
                {
                    new Category {CategoryId = 1, CategoryName = "Input Triode", Description = "From 60s"},
                    new Category {CategoryId = 2, CategoryName = "Penthode", Description = "From 50s"},
                    new Category {CategoryId = 3, CategoryName = "Power Triode", Description = "From 60s"},
                };
            }
        }
    }
}
