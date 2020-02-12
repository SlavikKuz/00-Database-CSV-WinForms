using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TubeStore.Models;

namespace TubeStore.Data
{
    public class CarouselConfiguration : IEntityTypeConfiguration<Carousel>
    {
        public void Configure(EntityTypeBuilder<Carousel> builder)
        {
            builder.ToTable("Carousels");

            builder.HasData
            (
                new Carousel()
                {
                    CarouselId = 1,
                    ImageUrl = "/Images/Carousel/carousel_01.jpg",
                    Title = "ECC82",
                    Description = "Premium selected",
                    Status = true
                },
                new Carousel()
                {
                    CarouselId = 2,
                    ImageUrl = "/Images/Carousel/carousel_02.jpg",
                    Title = "6P14P",
                    Description = "Platinum matched quad",
                    Status = true,
                },
                new Carousel()
                {
                    CarouselId = 3,
                    ImageUrl = "/Images/Carousel/carousel_03.jpg",
                    Title = "6N6P",
                    Description = "Tested pre-amp set",
                    Status = true,
                }
            );
        }
    }
}