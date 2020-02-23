using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TubeStore.Models;

namespace TubeStore.DataLayer
{
    public class TubeStoreDbContext : IdentityDbContext<Customer>
    {
        public TubeStoreDbContext(DbContextOptions<TubeStoreDbContext> options)
            : base(options) { }

        public DbSet<Carousel> Carousels { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Invoice> Invoices { get; set; }
        public DbSet<InvoiceInfo> InvoiceInfos { get; set; }
        public DbSet<ShippingAddress> ShippingAddresses { get; set; }
        public DbSet<Tube> Tubes { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Tube>().HasData(
                new Tube()
                {
                    TubeId = 1,
                    Type = "6N1P",
                    Brand = "NEVZ",
                    Date = "10.1963",
                    ShortDescription = "NOS, Gray plates, gold grids, mica",
                    FullDescription = "The 6N1P has similar ratings to the 6DJ8 and in the past was sometimes rebranded as such, however differences between the two types (the 6N1P requires almost twice the filament current and has only one third the S value) mean they are not directly interchangeable. The S is about 4.35 ma/V, the 6DJ8/ECC88 has a S of 12.5 ma/V and a gain of 33 and a lower internal resistance. However, the 6N1P is typically more linear for a given load. It is therefore inaccurate to say that these two tubes are identical. The correct Russian equivalent to the 6DJ8/ECC88 is the 6N23P, the latter has a S of 12.5 mA/V and a gain of 33.",
                    MatchedPair = true,
                    Price = 12.00M,
                    Quantity = 62,
                    ImageUrl = "/Images/Pre Triodes/6N1P/20160808_6N1Pnevz.jpg",
                    ImageThumbnailUrl = "/Images/Pre Triodes/6N1P/20160808_6N1Pnevz_small.jpg",
                    IsTubeOfTheWeek = false,
                    IsNewArrival = false,
                    CategoryId = 1,
                    Discount = 10
                },
                new Tube()
                {
                    TubeId = 2,
                    Type = "6N1P",
                    Brand = "NEVZ",
                    Date = "01.1967",
                    ShortDescription = "NOS, box plates",
                    FullDescription = "The 6N1P has similar ratings to the 6DJ8 and in the past was sometimes rebranded as such, however differences between the two types (the 6N1P requires almost twice the filament current and has only one third the S value) mean they are not directly interchangeable. The S is about 4.35 ma/V, the 6DJ8/ECC88 has a S of 12.5 ma/V and a gain of 33 and a lower internal resistance. However, the 6N1P is typically more linear for a given load. It is therefore inaccurate to say that these two tubes are identical. The correct Russian equivalent to the 6DJ8/ECC88 is the 6N23P, the latter has a S of 12.5 mA/V and a gain of 33.",
                    MatchedPair = true,
                    Price = 115.00M,
                    Quantity = 12,
                    ImageUrl = "/Images/Pre Triodes/6N1P/20170201_6N1Pboxplates.jpg",
                    ImageThumbnailUrl = "/Images/Pre Triodes/6N1P/20170201_6N1Pboxplates_small.jpg",
                    InStock = true,
                    IsTubeOfTheWeek = true,
                    IsNewArrival = false,
                    CategoryId = 1
                },
                new Tube()
                {
                    TubeId = 3,
                    Type = "6N6P",
                    Brand = "Foton",
                    Date = "1960s",
                    ShortDescription = "square getter, millitary grade",
                    FullDescription = "The 6N6p tube is a Russian dual triode tube. This tube is often seen as 6N6p, 6N6PI, 6N6pi, 6H6p, 6N6p-i, 6N6n-i ,or 6H6n-i. The Chinese name for the 6H6p tube is 6N6 tube. The 6N6p is a fantastic tube for preamps and driver stages, and is even used as output tubes in the Little Dot MkIII headphone amp. It has been used by the tube DIY underground for many years and is now becoming better known in the mainstream.",
                    MatchedPair = true,
                    Price = 39.99M,
                    Quantity = 30,
                    ImageUrl = "/Images/Pre Triodes/6N6P/20170506_6N6Pfoton.jpg",
                    ImageThumbnailUrl = "/Images/Pre Triodes/6N6P/20170506_6N6Pfoton_small.jpg",
                    InStock = true,
                    IsTubeOfTheWeek = false,
                    IsNewArrival = false,
                    CategoryId = 1
                },
                new Tube()
                {
                    TubeId = 4,
                    Type = "6N6P",
                    Brand = "NEVZ",
                    Date = "08.1974",
                    ShortDescription = "gold pin & grid",
                    FullDescription = "The 6N6p tube is a Russian dual triode tube. This tube is often seen as 6N6p, 6N6PI, 6N6pi, 6H6p, 6N6p-i, 6N6n-i ,or 6H6n-i. The Chinese name for the 6H6p tube is 6N6 tube. The 6N6p is a fantastic tube for preamps and driver stages, and is even used as output tubes in the Little Dot MkIII headphone amp. It has been used by the tube DIY underground for many years and is now becoming better known in the mainstream.",
                    MatchedPair = true,
                    Price = 89.99M,
                    Quantity = 10,
                    ImageUrl = "/Images/Pre Triodes/6N6P/20170506_6N6Pnevz.jpg",
                    ImageThumbnailUrl = "/Images/Pre Triodes/6N6P/20170506_6N6Pnevz_small.jpg",
                    InStock = true,
                    IsTubeOfTheWeek = false,
                    IsNewArrival = true,
                    CategoryId = 1
                },
                new Tube()
                {
                    TubeId = 5,
                    Type = "ECC82",
                    Brand = "Tungsram",
                    Date = "1970s",
                    ShortDescription = "Made in hungary",
                    FullDescription = "The tube is popular in hi-fi vacuum tube audio as a low-noise line amplifier, driver (especially for tone stacks), and phase-inverter in vacuum tube push–pull amplifier circuits. It was widely used, in special-quality versions such as ECC82 and 5814A, in pre-semiconductor digital computer circuitry. ",
                    MatchedPair = false,
                    Price = 49.99M,
                    Quantity = 11,
                    ImageUrl = "/Images/Pre Triodes/ECC82/20171220_ECC82tungsram.jpg",
                    ImageThumbnailUrl = "/Images/Pre Triodes/ECC82/20171220_ECC82tungsram_small.jpg",
                    InStock = true,
                    IsTubeOfTheWeek = false,
                    IsNewArrival = true,
                    CategoryId = 1
                },
                new Tube()
                {
                    TubeId = 6,
                    Type = "ECC82",
                    Brand = "Mullard",
                    Date = "02.1961",
                    ShortDescription = "Made in Great Britain",
                    FullDescription = "The tube is popular in hi-fi vacuum tube audio as a low-noise line amplifier, driver (especially for tone stacks), and phase-inverter in vacuum tube push–pull amplifier circuits. It was widely used, in special-quality versions such as ECC82 and 5814A, in pre-semiconductor digital computer circuitry. ",
                    MatchedPair = false,
                    Price = 299.99M,
                    Quantity = 3,
                    ImageUrl = "/Images/Pre Triodes/ECC82/20171212_ECC82mullard.jpg",
                    ImageThumbnailUrl = "/Images/Pre Triodes/ECC82/20171212_ECC82mullard_small.jpg",
                    InStock = true,
                    IsTubeOfTheWeek = false,
                    IsNewArrival = true,
                    CategoryId = 1
                }
            );

            modelBuilder.Entity<Category>().HasData(
                new Category()
                {
                    CategoryId = 1,
                    CategoryName = "Pre Triodes"
                }
            );

            modelBuilder.Entity<Carousel>().HasData(
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

            //modelBuilder.Entity<Microsoft.AspNetCore.Identity.IdentityRole>().HasData(
            //    new Microsoft.AspNetCore.Identity.IdentityRole()
            //    {
            //        Id = "80460a1b-fab3-40be-b4c5-b7f729182021",
            //        Name = "User",
            //        NormalizedName = "USER",
            //        ConcurrencyStamp = "ee28bb50-8b19-4af0-9cf1-48573d65d9f3"
            //    },

            //    new Microsoft.AspNetCore.Identity.IdentityRole()
            //    {
            //        Id = "86950302-3357-444d-8bbc-39c68c8281ab",
            //        Name = "Admin",
            //        NormalizedName = "ADMIN",
            //        ConcurrencyStamp = "1ec21564-a910-4fa8-be57-37d44d96c402"
            //    }
            // );

            
        }
    }
}
