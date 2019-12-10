using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAppStore.Models
{
    public class MockTubeRepository : ITubeRepository
    {
        private readonly ICategoryRepository _categoryRepository = new MockCategoryRepository();
        
        public IEnumerable<Tube> Tubes
        {
            get
            {
                return new List<Tube>
                {
                    new Tube
                    {
                        TubeId = 1,
                        Name = "6N1P",
                        Price = 15.00M,
                        ShortDetails = "double triode",
                        FullDetails = "pre amp tube for ...",
                        Category = _categoryRepository.Categories.ToList()[0],
                        ImageUrl = "",
                        ImageThumbnailUrl = "/Images/DoubleTriodes/6N1P_small.jpg",
                        InStock = true,
                        IsTubeOfTheWeek = false
                    },
                    new Tube
                    {
                        TubeId = 2,
                        Name = "6N2P",
                        Price = 18.00M,
                        ShortDetails = "double triode",
                        FullDetails = "pre amp tube for strong ...",
                        Category = _categoryRepository.Categories.ToList()[1],
                        ImageUrl = "",
                        ImageThumbnailUrl = "/Images/DoubleTriodes/6N2P_small.jpg",
                        InStock = true,
                        IsTubeOfTheWeek = false
                    },
                };
            }
        }

        public IEnumerable<Tube> TubesOfTheWeek { get; }

        public Tube GetTubeById(int tubeId)
        {
            throw new NotImplementedException();
        }
    }
}
