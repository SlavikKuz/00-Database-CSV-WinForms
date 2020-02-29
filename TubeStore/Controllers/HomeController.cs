using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using TubeStore.DataLayer;
using TubeStore.Models;
using TubeStore.ViewModels;

namespace TubeStore.Controllers
{
    public class HomeController : Controller
    {
        private readonly IGenericRepository<Tube> tubes;
        private readonly IGenericRepository<Carousel> carousels;
        private readonly IGenericRepository<ChatMessage> messages;
        private readonly IGenericRepository<ChatUser> chatUsers;
        private readonly IGenericRepository<ChatGroup> groups;
        private readonly UserManager<Customer> userManager;

        public HomeController(IGenericRepository<Tube> tubes,
                              IGenericRepository<Carousel> carousels,
                              IGenericRepository<ChatMessage> messages,
                              IGenericRepository<ChatUser> chatUsers,
                              IGenericRepository<ChatGroup> groups,
                              UserManager<Customer> userManager)
        {
            this.tubes = tubes;
            this.carousels = carousels;
            this.messages = messages;
            this.chatUsers = chatUsers;
            this.groups = groups;
            this.userManager = userManager;
        }
     
        public IActionResult Index()
        {
            HomeIndexViewModel homeIndexViewModel = new HomeIndexViewModel()
            {
                Tubes = tubes.GetAll(),
                Carousels = carousels.GetAll()
            };       
            
            return View(homeIndexViewModel);
        }

        public async Task<IActionResult> IndexCategory(string category, int? page, int? categoryId)
        {
            ICollection<Tube> tubesInCategory;

            if (categoryId!=null)
                tubesInCategory = await tubes.FindAllAsync(x => x.Category.CategoryId == categoryId);
            else
                tubesInCategory = await tubes.FindAllAsync(x => x.Category.CategoryName == category);

            int pageSize = 6;
            int pageNumber = (page ?? 1);
            return View(PaginatedList<Tube>.CreateNonAsync(tubesInCategory,
                                                           pageNumber,
                                                           pageSize));
        }

        public async Task<IActionResult> IndexType(string type, int? page)
        {
            ICollection<Tube> tubesInCategory = await tubes.FindAllAsync(x => x.Type == type);

            int pageSize = 6;
            int pageNumber = (page ?? 1);
            return View(PaginatedList<Tube>.CreateNonAsync(tubesInCategory,
                                                           pageNumber,
                                                           pageSize));
        }

        [HttpPost]
        public IActionResult Search(IFormCollection form)
        {
            ISession session = this.HttpContext.Session;
            session.SetString("Keyword", form["keyword"]);           
            
            return RedirectToAction("SearchList");
        }

        private async Task<List<Tube>> GetSearchingResult()
        {
            ISession session = this.HttpContext.Session;
            string[] searchKeys = session.GetString("Keyword").Split(' ');

            IEnumerable<Tube> temp;
            List<Tube> resultTemp = new List<Tube>();

            for (int i = 0; i < searchKeys.Count(); i++)
            {
                temp = await tubes.FindAllAsync(x => x.Brand.Contains(searchKeys[i]));

                foreach (var tube in temp)
                    resultTemp.Add(tube);

                temp = await tubes.FindAllAsync(x => x.Type.Contains(searchKeys[i]));

                foreach (var tube in temp)
                    resultTemp.Add(tube);

                temp = await tubes.FindAllAsync(x => x.ShortDescription.Contains(searchKeys[i]));

                foreach (var tube in temp)
                    resultTemp.Add(tube);
            }

            return resultTemp.Distinct().ToList();
        }

        public async Task<IActionResult> SearchList(int? page)
        {
            int pageSize = 3;
            int pageNumber = (page ?? 1);
            return View(PaginatedList<Tube>.CreateNonAsync(await GetSearchingResult(),
                                                           pageNumber,
                                                           pageSize));
        }

        [HttpGet]
        public async Task<IActionResult> Chat()
        {   
            ChatUser chatUser = new ChatUser();
            chatUser.User = await userManager.GetUserAsync(User);
            chatUser.ChatUserId = chatUser.User.Id;
            chatUser.UserName = chatUser.User.UserName;

            if ((await chatUsers.FindAsync(x => x.ChatUserId == chatUser.ChatUserId)) == null)
                return RedirectToAction("ChatInit", chatUser);

            ICollection<ChatMessage> chatMessages = 
                await messages.FindAllAsync(x => x.ChatUserId == chatUser.ChatUserId);
            
            return View(chatMessages);
        }

        [HttpPost]
        public IActionResult Chat([FromBody] AjaxChatModel model)
        {
            return Json(new { newUrl = Url.Action("Chat", "Home") });
        }

        public async Task<IActionResult> ChatInit()
        {
            ChatUser chatUser = new ChatUser();
            chatUser.User = await userManager.GetUserAsync(User);
            chatUser.ChatUserId = chatUser.User.Id;
            chatUser.UserName = chatUser.User.UserName;

            ChatGroup chatGroup;

            if ((await chatUsers.FindAsync(x => x.ChatUserId == chatUser.ChatUserId)) == null)
            {
                await chatUsers.AddAsync(chatUser);

                chatGroup = new ChatGroup { ChatGroupName = chatUser.UserName };
                await groups.AddAsync(chatGroup);

                ChatMessage chatMessage = new ChatMessage
                {
                    ChatGroupId = chatGroup.ChatGroupId.ToString(),
                    ChatUserId = chatUser.ChatUserId,
                    UserName = chatUser.UserName,
                    MessageText = "You started the chat"
                };

                await messages.AddAsync(chatMessage);
            }

            ChatMessage message = (await messages.FindByAsync(x => x.ChatUserId == chatUser.ChatUserId)).First();

        return View(message);
        }

        public async Task<IActionResult> CreateMessage(ChatMessage message)
        {
            if(ModelState.IsValid)
            {
                message.Author = await chatUsers.FindAsync(x=>x.UserName == User.Identity.Name);
                message.ChatUserId = message.Author.ChatUserId;
                await messages.AddAsync(message);

                return Ok();
            }
            return Error();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

    }

    public class AjaxChatModel
    {
        public string name { get; set; }
        public string group { get; set; }
    }
}