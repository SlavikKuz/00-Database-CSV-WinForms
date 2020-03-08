using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace TubeStore.Models
{
    public class Category
    {
        [Key]
        public int CategoryId { get; set; }

        [Required]
        [StringLength(20)]
        [Display(Name = "Category Name")]
        public string CategoryName { get; set; }

        [Display(Name = "Parent Id")]
        public int? ParentId { get; set; }
        public Category Parent { get; set; }

        public virtual ICollection<Category> Parents { get; set; }
            = new HashSet<Category>();

        public virtual ICollection<Tube> Tubes { get; set; }
            = new HashSet<Tube>();
    }
}
