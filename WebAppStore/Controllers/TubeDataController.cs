using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WebAppStore.Models;
using WebAppStore.ViewModels;

namespace WebAppStore.Controllers
{
    [Route("api/[controller]")]
    public class TubeDataController : Controller
    {
        private readonly ITubeRepository _tubeRepository;
        
        public TubeDataController(ITubeRepository tubeRepository)
        {
            _tubeRepository = tubeRepository;
        }

        [HttpGet]
        public IEnumerable<TubeViewModel> GetMoreTubes()
        {
            IEnumerable<Tube> dbTubes = _tubeRepository.AllTubes.OrderBy(x => x.TubeId).Take(10);
            List<TubeViewModel> tubes = new List<TubeViewModel>();

            foreach (var dbTube in dbTubes)
            {
                tubes.Add(MapDbTubeToTubeViewModel(dbTube));
            }
            return tubes; 
        }

        private TubeViewModel MapDbTubeToTubeViewModel(Tube dbTube)
        {
            return new TubeViewModel
            {
                TubeId = dbTube.TubeId,
                Type = dbTube.Type,
                Brand = dbTube.Brand,
                ShortDescription = dbTube.ShortDescription,
                FullDescription = dbTube.FullDescription,
                Parameters = dbTube.Parameters,
                Price = dbTube.Price,
                ImageThumbnailUrl = dbTube.ImageThumbnailUrl
            };
        }
    }
}
