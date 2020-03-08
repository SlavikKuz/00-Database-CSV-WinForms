using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace TubeStore.Models
{
    public class Carousel
    {
        [Key]
        public int CarouselId { get; set; }
        
        [Required]
        [Display(Name = "Image Url")]
        public string ImageUrl { get; set; }

        [Required]
        [Display(Name = "Slide Title")]
        public string Title { get; set; }

        [Required]
        [Display(Name = "Description on Slide")]
        public string Description { get; set; }

        [Required]
        [Display(Name = "Tube Id")]
        public int TubeReferenceId { get; set; }

        [Display(Name = "Status")]
        public bool Status { get; set; }
    }
}
