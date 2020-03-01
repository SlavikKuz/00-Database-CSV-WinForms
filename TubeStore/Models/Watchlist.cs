using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TubeStore.Models
{
    public class Watchlist
    {
        public int WatchlistId { get; set; }
        
        public int TubeId { get; set; }
        public Tube Tube { get; set; }
        
        public string CustomerId { get; set; }
        public Customer Customer { get; set; }
        
        public DateTime DateCreated { get; set; } = DateTime.Now;
    }
}
