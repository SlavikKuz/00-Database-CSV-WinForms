using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace TubeStore.Models
{
    public class ChatUser
    {
        [Key]
        public string ChatUserId { get; set; }
        
        public string UserName { get; set; }

        //?? if we need it
        public string CustomerId { get; set; }
        
        public virtual Customer User { get; set; }

        public virtual ICollection<ChatMessage> Messages { get; set; }
                            = new HashSet<ChatMessage>();
    }
}
