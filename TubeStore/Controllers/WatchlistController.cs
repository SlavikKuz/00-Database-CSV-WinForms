using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using ModalNofications;
using TubeStore.DataLayer;
using TubeStore.Models;
using static ModalNofications.SupportModalClass;

namespace TubeStore.Controllers
{
    [Authorize]
    public class WatchlistController : Controller
    {
        private readonly IGenericRepository<Watchlist> watchlists;
        private readonly IGenericRepository<Tube> tubes;
        private readonly UserManager<Customer> userManager;
        private readonly IModalNotification modalNotification;

        public WatchlistController(IGenericRepository<Watchlist> watchlists,
                                   UserManager<Customer> userManager,
                                   IModalNotification modalNotification,
                                   IGenericRepository<Tube> tubes)
        {
            this.watchlists = watchlists;
            this.tubes = tubes;
            this.userManager = userManager;
            this.modalNotification = modalNotification;
        }
        
        public async Task<IActionResult> Index()
        {
            string userId = userManager.GetUserId(User);
            ICollection<Watchlist> usersWatchlists = await watchlists.FindAllAsync(x => x.CustomerId == userId);         
            foreach (var item in usersWatchlists)
            {
                item.Tube = await tubes.GetAsync(item.TubeId);
            }
            return View(usersWatchlists);
        }

        public async Task<IActionResult> Add(int tubeId)
        {
            string userId= userManager.GetUserId(User);

            Watchlist watchlist = new Watchlist()
            {
                TubeId = tubeId,
                CustomerId = userId
            };

            ICollection<Watchlist> userWatchlists = await watchlists.FindAllAsync(x => x.CustomerId.Equals(userId));


            await watchlists.AddAsync(watchlist);

            modalNotification.AddNotificationSweet("Watchlist", NotificationType.success, "The tube has been added to your watchlist.");
            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Delete(int id)
        {
            Watchlist watchlist = await watchlists.GetAsync(id);
            await watchlists.DeleteAsync(watchlist);

            modalNotification.AddNotificationSweet("Watchlist", NotificationType.success, "The tube has been removerd from your watchlist.");

            return RedirectToAction(nameof(Index));
        }
    }
}