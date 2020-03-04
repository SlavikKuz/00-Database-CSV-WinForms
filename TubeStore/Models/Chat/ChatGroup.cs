using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TubeStore.Models.Chat
{
    public class ChatGroup
    {
        public long ChatGroupId { get; set; }
        public string CustomerId { get; set; }
        public string AdminId { get; set; }
        public virtual ICollection<ChatMessage> ChatMessages { get; set; }
        public bool IsReadAdmin { get; set; }
    }
}
