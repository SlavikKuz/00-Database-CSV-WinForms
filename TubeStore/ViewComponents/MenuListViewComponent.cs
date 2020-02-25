using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TubeStore.DataLayer;
using TubeStore.Models;
using TubeStore.ViewModels;

namespace TubeStore.ViewComponents
{
    public class MenuListViewComponent : ViewComponent
    {
        private readonly IGenericRepository<Tube> tubes;

        public MenuListViewComponent(IGenericRepository<Tube> tubes)
        {
            this.tubes = tubes;
        }

        public IViewComponentResult Invoke(string category)
        {
            DropdownViewModel model = new DropdownViewModel();

            model.DropdownName = category;
            model.DropdownItems = tubes.GetAll()
                                       .Where(x => x.Category.CategoryName == category)
                                       .OrderBy(x=>x.Type)
                                       .Select(x => x.Type)
                                       .Distinct()
                                       .ToList();

            return View("Dropdown", model);
        }
    }
}
