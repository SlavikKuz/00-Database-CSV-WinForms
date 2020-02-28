using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TubeStore.DataLayer;

namespace TubeStore.Models
{
    public class ChatGroupStore
    {
        private readonly IGenericRepository<ChatGroup> chatGroups;
        private readonly UserManager<Customer> userManager;

        public ChatGroupStore(IGenericRepository<ChatGroup> chatGroups,
                              UserManager<Customer> userManager)
        {
            this.chatGroups = chatGroups;
            this.userManager = userManager;
        }

        public async Task AddGroup(string group)
        {
            await chatGroups.AddAsync(new ChatGroup { ChatGroupName = group });
        }

        public async Task<bool> GroupExists(string group)
        {
            var item = await chatGroups.FindAsync(x=>x.ChatGroupName==group);
            
            if (item == null)
                return false;

            return true;
        }

        //public void CreateNewItem(NewsItem item)
        //{
        //    if (GroupExists(item.NewsGroup))
        //    {
        //        _newsContext.NewsItemEntities.Add(new NewsItemEntity
        //        {
        //            Header = item.Header,
        //            Author = item.Author,
        //            NewsGroup = item.NewsGroup,
        //            NewsText = item.NewsText
        //        });
        //        _newsContext.SaveChanges();
        //    }
        //    else
        //    {
        //        throw new System.Exception("group does not exist");
        //    }
        //}

        //public IEnumerable<NewsItem> GetAllNewsItems(string group)
        //{
        //    return _newsContext.NewsItemEntities.Where(item => item.NewsGroup == group).Select(z =>
        //        new NewsItem
        //        {
        //            Author = z.Author,
        //            Header = z.Header,
        //            NewsGroup = z.NewsGroup,
        //            NewsText = z.NewsText
        //        });
        //}

        public List<string> GetAllGroups()
        {
            return chatGroups.GetAll().Select(x=>x.ChatGroupName).ToList();
        }
    }
}

