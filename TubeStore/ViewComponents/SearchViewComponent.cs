using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TubeStore.DataLayer;
using TubeStore.Models;

namespace TubeStore.ViewComponents
{
    [ViewComponent(Name = "Search")]
    public class SearchViewComponent : ViewComponent
    {
        private readonly IGenericRepository<Tube> tubes;

        public SearchViewComponent(IGenericRepository<Tube> tubes)
        {
            this.tubes = tubes;
        }

        //public async Task<IViewComponentResult> InvokeAsync()
        //{
        //    string keyword = HttpContext.Request.Query["keyword"].ToString();

        //}
    }
}
