using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TubeStore.Models;

namespace TubeStore.Data
{
    public class TubeConfiguration : IEntityTypeConfiguration<Tube>
    {
        public void Configure(EntityTypeBuilder<Tube> builder)
        {
            builder.ToTable("Tubes");

            builder.HasData
            (
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
                    ImageUrl = "/Images/PreTriodes/6N1P/20160808_6N1Pnevz.jpg",
                    ImageThumbnailUrl = "/Images/PreTriodes/6N1P/20160808_6N1Pnevz_small.jpg",
                    IsTubeOfTheWeek = false,
                    IsNewArrival = false,
                    //Category = new Category() { CategoryName = "Pre Triodes" }
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
                    ImageUrl = "/Images/PreTriodes/6N1P/20170201_6N1Pboxplates.jpg",
                    ImageThumbnailUrl = "/Images/PreTriodes/6N1P/20170201_6N1Pboxplates_small.jpg",
                    InStock = true,
                    IsTubeOfTheWeek = true,
                    IsNewArrival = false,
                    //Category = new Category() { CategoryName = "Pre Triodes" }
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
                    ImageUrl = "/Images/PreTriodes/6N6P/20170506_6N6Pfoton.jpg",
                    ImageThumbnailUrl = "/Images/PreTriodes/6N6P/20170506_6N6Pfoton_small.jpg",
                    InStock = true,
                    IsTubeOfTheWeek = false,
                    IsNewArrival = false,
                    //Category = new Category() { CategoryName = "Pre Triodes" }
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
                    ImageUrl = "/Images/PreTriodes/6N6P/20170506_6N6Pnevz.jpg",
                    ImageThumbnailUrl = "/Images/PreTriodes/6N6P/20170506_6N6Pnevz_small.jpg",
                    InStock = true,
                    IsTubeOfTheWeek = false,
                    IsNewArrival = true,
                    //Category = new Category() { CategoryName = "Pre Triodes" }
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
                    ImageUrl = "/Images/PreTriodes/ECC82/20171220_ECC82tungsram.jpg",
                    ImageThumbnailUrl = "/Images/PreTriodes/ECC82/20171220_ECC82tungsram_small.jpg",
                    InStock = true,
                    IsTubeOfTheWeek = false,
                    IsNewArrival = true,
                    //Category = new Category() { CategoryName = "Pre Triodes" }
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
                    ImageUrl = "/Images/PreTriodes/ECC82/20171212_ECC82mullard.jpg",
                    ImageThumbnailUrl = "/Images/PreTriodes/ECC82/20171212_ECC82mullard_small.jpg",
                    InStock = true,
                    IsTubeOfTheWeek = false,
                    IsNewArrival = true,
                    //Category = new Category() { CategoryName = "Pre Triodes" }
                }
            );
        }
    }
}
