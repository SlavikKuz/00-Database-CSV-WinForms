using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace TubeStore.Models.Chat
{
    public class ChatMessage
    {
        [Key]
        public long ChatMessageId { get; set; }
        
        public string MessageText { get; set; }
        
        public long ChatGroupId { get; set; }

        public string CustomerId { get; set; } 
        public string UserName { get; set; }

        public string MessageDate { get; set; }
    }
}
