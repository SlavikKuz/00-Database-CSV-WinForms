using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace TubeStore.Models
{
    public class Watchlist
    {
        [Key]
        public int WatchlistId { get; set; }
        
        [ForeignKey("Tubes")]
        public int TubeId { get; set; }
        public Tube Tube { get; set; }
        
        public string CustomerId { get; set; }
        public Customer Customer { get; set; }
        
        public DateTime DateCreated { get; set; } = DateTime.Now;
    }
}
