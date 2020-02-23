using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace TubeStore.Models
{
    public class Tube
    {
        public int TubeId { get; set; }
        
        [Required(ErrorMessage = "Type is required")]
        [MinLength(2, ErrorMessage = "Please check the type value")]
        [Display(Name = "Tube type")]        
        public string Type { get; set; }
        
        public string Brand { get; set; }
        public string Date { get; set; } //years, era
        public string ShortDescription { get; set; } //getter, pins, plates
        public string FullDescription { get; set; } //history, sound description, electric
        public bool MatchedPair { get; set; } //available in Matchedpairs
        
        [DataType(DataType.Currency)]
        [Column(TypeName = "decimal(6,2)")]
        public decimal Price { get; set; }
        public int Quantity { get; set; }
        public string ImageUrl { get; set; }
        public string ImageThumbnailUrl { get; set; }
        public bool IsTubeOfTheWeek { get; set; }
        public bool IsNewArrival { get; set; }
        public bool InStock { get; set; }
        
        public decimal Discount { get; set; }
        
        public int CategoryId { get; set; }

        public virtual Category Category { get; set; }

        //public virtual ICollection<InvoiceInfo> InvoicesInfo { get; set; } 
        //    = new HashSet<InvoiceInfo>();
    }
}
