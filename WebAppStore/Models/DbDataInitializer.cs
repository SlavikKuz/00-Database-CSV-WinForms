using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAppStore.Models
{
    public static class DbDataInitializer
    {
        
        
        public static void Seed (IServiceProvider serviceProvider)
        {
            using (var storeDbContext = new StoreDbContext(
                serviceProvider.GetRequiredService<
                    DbContextOptions<StoreDbContext>>()))
            {
                if (!storeDbContext.Categories.Any())
                {
                    storeDbContext.Categories.AddRange(Categories.Select(x => x.Value));
                }

                if (!storeDbContext.Tubes.Any())
                {
                    storeDbContext.AddRange(
                        new Tube
                        {
                            Type = "6N1P",
                            Brand = "NEVZ",
                            Date = "Early 60s",
                            ShortDescription = "gray plates, tripple mica",
                            FullDescription = "Superb sonic tube, Novosibirsk NEVZ plant. The tubes are early series, large logo, and golden grids! ",
                            Parameters = "#270 (12-1959) 7.0 mA, 4.15 mA/V -- 7.5 mA, 4.15 mA/V",

                            Price = 15.00M,
                            ImageUrl = "/Images/DoubleTriodes/6N1P.jpg",
                            ImageThumbnailUrl = "/Images/DoubleTriodes/6N1P_small.jpg",
                            InStock = true,
                            IsTubeOfTheWeek = false,
                            Category = Categories["Preamp Triodes"],
                        },
                        new Tube
                        {
                            Type = "6N2P",
                            Brand = "Voskhod",
                            Date = "1967",
                            ShortDescription = "gray plates, tripple mica",
                            FullDescription = "Superb sonic tube, Novosibirsk NEVZ plant. The tubes are early series, large logo, and golden grids! ",
                            Parameters = "#270 7.0 mA, 4.15 mA/V -- 7.5 mA, 4.15 mA/V",

                            Price = 15.00M,
                            ImageUrl = "/Images/DoubleTriodes/6N2P.jpg",
                            ImageThumbnailUrl = "/Images/DoubleTriodes/6N2P_small.jpg",
                            InStock = true,
                            IsTubeOfTheWeek = false,
                            Category = Categories["Preamp Triodes"],
                        },
                        new Tube
                        {
                            Type = "6N1P",
                            Brand = "NEVZ",
                            Date = "Early 60s",
                            ShortDescription = "gray plates, tripple mica",
                            FullDescription = "Superb sonic tube, Novosibirsk NEVZ plant. The tubes are early series, large logo, and golden grids! ",
                            Parameters = "#272 (12-1959) 7.0 mA, 4.15 mA/V -- 7.5 mA, 4.15 mA/V",

                            Price = 15.00M,
                            ImageUrl = "/Images/DoubleTriodes/6N1P.jpg",
                            ImageThumbnailUrl = "/Images/DoubleTriodes/6N1P_small.jpg",
                            InStock = true,
                            IsTubeOfTheWeek = false,
                            Category = Categories["Preamp Triodes"],
                        },
                        new Tube
                        {
                            Type = "6N2P",
                            Brand = "Voskhod",
                            Date = "1967",
                            ShortDescription = "gray plates, tripple mica",
                            FullDescription = "Superb sonic tube, Novosibirsk NEVZ plant. The tubes are early series, large logo, and golden grids! ",
                            Parameters = "#270 7.0 mA, 4.15 mA/V -- 7.5 mA, 4.15 mA/V",

                            Price = 15.00M,
                            ImageUrl = "/Images/DoubleTriodes/6N2P.jpg",
                            ImageThumbnailUrl = "/Images/DoubleTriodes/6N2P_small.jpg",
                            InStock = true,
                            IsTubeOfTheWeek = false,
                            Category = Categories["Preamp Triodes"],
                        }
                        );
                storeDbContext.SaveChanges();
                }
            }
        }
        private static Dictionary<string, Category> categories;

        public static Dictionary<string, Category> Categories
        {
            get
            {
                if (categories == null)
                {
                    var CategoriesList = new Category[]
                    {
                        new Category { CategoryName = "Output Penthodes", Description = "Powerfull output tubes for Push/Pull amplifiers" },
                        new Category { CategoryName = "Preamp Penthodes", Description = "Driver penthode tubes with hi amplification and low noise" },
                        new Category { CategoryName = "Preamp Triodes", Description = "Driver double triodes for sweet and clear sound" }
                    };

                    categories = new Dictionary<string, Category>();

                    foreach (var cat in CategoriesList)
                    {
                        categories.Add(cat.CategoryName, cat);
                    }
                }
                return categories;
            }
        }
    }
}
