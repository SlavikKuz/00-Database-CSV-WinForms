using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TubeStore.Models
{
    public class Category
    {
        public int CategoryId { get; set; }
        public string CategoryName { get; set; }

        public int? ParentId { get; set; }
        //public Category Parent { get; set; }

        //public virtual ICollection<Category> Parents { get; set; } 
        //    = new HashSet<Category>();

        //public virtual ICollection<Tube> Tubes { get; set; }
        //    = new HashSet<Tube>();
    }
}
