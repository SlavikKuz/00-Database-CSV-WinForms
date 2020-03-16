using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TubeStore.Models;

namespace TubeStore.ViewModels.Admin
{
    public class TubeViewModel
    {
        public Tube Tube { get; set; }
        public List<SelectListItem> CategoriesList { get; set; }
    }
}
