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
        public int ChatMessageId { get; set; }

        public string ChatGroupId { get; set; }

        public string ChatUserId { get; set; }
        public string UserName { get; set; }        
        public virtual ChatUser Author { get; set; }

        public string MessageText { get; set; }

        public DateTime MessageDate { get; set; } = DateTime.Now;

    }
}
