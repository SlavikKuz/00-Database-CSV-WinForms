using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TubeStore.Models;

namespace TubeStore.Services
{
    public class MockTubeRepository : IRepository<Tube>
    {
        List<Tube> tubes;

        public MockTubeRepository()
        {
            tubes = new List<Tube>()
            {
                new Tube()
                {
                    TubeId = 1,
                    Type = "6N1P",
                    Brand = "NEVZ",
                    Date = "10.1963",
                    ShortDescription = "gray plates, tripple mica",
                    FullDescription = "Superb sonic tube, Novosibirsk NEVZ plant. The tubes are early series, large logo, and golden grids! " +
                    "Parameters are #270 (12-1959) 7.0 mA, 4.15 mA/V -- 7.5 mA, 4.15 mA/V",
                    MatchedPair = true,
                    Price = 12.00M,
                    Quantity = 22,
                    ImageUrl = "/Images/DoubleTriodes/6N1P.jpg",
                    ImageThumbnailUrl = "/Images/DoubleTriodes/6N1P_small.jpg",
                    InStock = true,
                    IsTubeOfTheWeek = false,
                    //Category = Categories["Preamp Triodes"],
                },
                new Tube()
                {
                    TubeId = 2,
                    Type = "6N2P",
                    Brand = "Voskhod",
                    Date = "01.1967",
                    ShortDescription = "gray plates, tripple mica",
                    FullDescription = "Superb sonic tube, Novosibirsk NEVZ plant. The tubes are early series, large logo, and golden grids! " +
                    "Parameters are #270 7.0 mA, 4.15 mA/V -- 7.5 mA, 4.15 mA/V",
                    MatchedPair = true,
                    Price = 14.00M,
                    Quantity = 110,
                    ImageUrl = "/Images/DoubleTriodes/6N2P.jpg",
                    ImageThumbnailUrl = "/Images/DoubleTriodes/6N2P_small.jpg",
                    InStock = true,
                    IsTubeOfTheWeek = false,
                    //Category = Categories["Preamp Triodes"],
                },
                new Tube()
                {
                    TubeId=3,
                    Type = "6N1P",
                    Brand = "Orel",
                    Date = "12.1971",
                    ShortDescription = "black plates, tripple mica",
                    FullDescription = "Superb sonic tube, Orel plant. The tubes are early series, large logo, and golden grids! " +
                    "Parameters = #272 (12-1959) 7.0 mA, 4.15 mA/V -- 7.5 mA, 4.15 mA/V",
                    MatchedPair = false,
                    Price = 21.00M,
                    Quantity = 30,
                    ImageUrl = "/Images/DoubleTriodes/6N1P.jpg",
                    ImageThumbnailUrl = "/Images/DoubleTriodes/6N1P_small.jpg",
                    InStock = true,
                    IsTubeOfTheWeek = true,
                    //Category = Categories["Preamp Triodes"],
                },
                new Tube()
                {
                    TubeId = 4,
                    Type = "6N6P",
                    Brand = "Foton",
                    Date = "05.1960",
                    ShortDescription = "box plates, double mica",
                    FullDescription = "Superb sonic tube, Foton plant. The tubes are early series, large logo, and golden grids! " +
                    "Parameters = #270 7.0 mA, 4.15 mA/V -- 7.5 mA, 4.15 mA/V",
                    MatchedPair = true,
                    Price = 49.99M,
                    Quantity = 10,
                    ImageUrl = "/Images/DoubleTriodes/6N2P.jpg",
                    ImageThumbnailUrl = "/Images/DoubleTriodes/6N2P_small.jpg",
                    InStock = true,
                    IsTubeOfTheWeek = false,
                    //Category = Categories["Preamp Triodes"],
                }
            };
        }

        public bool Add(Tube item)
        {
            try
            {
                Tube tube = item;
                tube.TubeId = tubes.Max(x => x.TubeId) + 1;
                tubes.Add(tube);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public bool Delete(Tube item)
        {
            throw new NotImplementedException();
        }

        public bool Edit(Tube item)
        {
            throw new NotImplementedException();
        }

        public Tube Get(int id)
        {
            return tubes.FirstOrDefault(x => x.TubeId == id);
        }

        public IEnumerable<Tube> GetAll()
        {
            return tubes.ToList();
        }
    }
}
