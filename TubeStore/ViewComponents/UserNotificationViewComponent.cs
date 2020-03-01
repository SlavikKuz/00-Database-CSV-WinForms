using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TubeStore.Models;
using TubeStore.Models.Cart;

namespace TubeStore.ViewComponents
{
    [ViewComponent(Name = "UserNotification")]
    public class UserNotificationViewComponent : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View("Notification");
        }
    }
}
