using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TubeStore.Models;

namespace TubeStore.Services
{
    public class MockCarouselRepository : IRepository<Carousel>
    {
        List<Carousel> carousels;
        
        public MockCarouselRepository()
        {
            carousels = new List<Carousel>()
            {
                new Carousel()
                {
                    CarouselId = 1,
                    ImageUrl = "/Images/Carousel/carousel01.jpg",
                    Title = "ECC82",
                    Description = "Premium selected",
                    Status = true 
                },
                new Carousel()
                {
                    CarouselId = 2,
                    ImageUrl = "/Images/Carousel/carousel02.jpg",
                    Title = "6P14P",
                    Description = "Platinum matched quad",
                    Status = true,
                },
                new Carousel()
                {
                    CarouselId = 3,
                    ImageUrl = "/Images/Carousel/carousel03.jpg",
                    Title = "6N6P",
                    Description = "Tested pre-amp set",
                    Status = true,
                },
            };
        }
               
        public bool Add(Carousel item)
        {
            throw new NotImplementedException();
        }

        public bool Delete(Carousel item)
        {
            throw new NotImplementedException();
        }

        public bool Edit(Carousel item)
        {
            throw new NotImplementedException();
        }

        public Carousel Get(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Carousel> GetAll()
        {
            return carousels.ToList();
        }
    }
}
