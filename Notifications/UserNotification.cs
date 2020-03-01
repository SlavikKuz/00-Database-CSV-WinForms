using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using System;
using System.Collections.Generic;
using System.Text;
using static UserNotifications.SupportClass;

namespace UserNotifications
{
    public class UserNotification : IUserNotification
    {
        private readonly IHttpContextAccessor httpContextAccessor;
        private readonly HttpContext httpContext;
        private readonly ITempDataDictionaryFactory factory;
        private readonly ITempDataDictionary tempData;

        public UserNotification(IHttpContextAccessor httpContextAccessor)
        {
            this.httpContextAccessor = httpContextAccessor;
            httpContext = httpContextAccessor.HttpContext;
            factory = httpContext.RequestServices.GetService(typeof(ITempDataDictionaryFactory)) as ITempDataDictionaryFactory;
            tempData = factory.GetTempData(httpContext);
        }

        public void AddNotificationSweet(string title, NotificationType type, string text)
        {
            string message = "swal('" + title + "', '" + text + "', '" + type + "')";

            tempData["swalNotification"] = message;
        }

        public void AddNotificationToast(string text, NotificationType type, ToastOption options)
        {
            var positions = new SupportClass().position();

            var JsonSerializerSettings = new JsonSerializerSettings
            {
                ContractResolver = new CamelCasePropertyNamesContractResolver()
            };

            if (options == null)
            {
                tempData["options"] = JsonConvert
                        .SerializeObject(new ToastOption(), JsonSerializerSettings);
            }
            else
            {
                tempData["options"] = JsonConvert
                        .SerializeObject(options, JsonSerializerSettings);
            }

            var message = "toastr." + type + "('" + text + "')";
            tempData["notification"] = message;
        }
    }
}
