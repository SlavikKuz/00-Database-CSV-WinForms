using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TubeStore.DataLayer;
using TubeStore.Models;

namespace TubeStore.ViewComponents
{
    public class AddToWatchlistViewComponent:ViewComponent
    {
        private readonly IGenericRepository<Watchlist> watchlists;

        public AddToWatchlistViewComponent(IGenericRepository<Watchlist> watchlists)
        {
            this.watchlists = watchlists;
        }

        public IViewComponentResult Invoke(string userName, int tubeId)
        {
            ICollection<Watchlist> usersWatchlists = watchlists.FindAll(x => x.CustomerId == userName);
            
            if (usersWatchlists.Count() > 0)
                usersWatchlists = usersWatchlists.Where(x => x.TubeId.Equals(tubeId)).ToList();

            if (usersWatchlists.Count() > 0)
                return View("AddToWatchlist",0);

            return View("AddToWatchlist", tubeId);        
        }
    }
}
