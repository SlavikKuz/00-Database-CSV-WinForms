using Microsoft.AspNetCore.Mvc;
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

        [Remote("VerifyTubeName", "Validator", ErrorMessage = "The tube already exists!",
        AdditionalFields = "Type")]
        public string Brand { get; set; }

        public string Date { get; set; } //years, era
        public string ShortDescription { get; set; } //getter, pins, plates
        public string FullDescription { get; set; } //history, sound description, electric

        [Display(Name = "Available in Pairs")]
        public bool MatchedPair { get; set; } //available in Matchedpairs
        
        [DataType(DataType.Currency)]
        [Column(TypeName = "decimal(6,2)")]
        [Display(Name = "Price (coma separated)")]
        public decimal Price { get; set; }
        public int Quantity { get; set; }
        public string ImageUrl { get; set; }
        public string ImageThumbnailUrl { get; set; }

        [Display(Name = "Week's Bestseller ")]
        public bool IsTubeOfTheWeek { get; set; }

        [Display(Name = "New Arrival")]
        public bool IsNewArrival { get; set; }

        [Display(Name = "Discount (0,01 = 1%)")]
        [RegularExpression(@"^[0-9]+(\.[0-9]{1,2})$", ErrorMessage = "Valid Decimal number with maximum 2 decimal places.")]
        public decimal Discount { get; set; }
        
        public int CategoryId { get; set; }

        public virtual Category Category { get; set; }

        public virtual ICollection<Watchlist> Watchlists { get; set; }
    }
}
