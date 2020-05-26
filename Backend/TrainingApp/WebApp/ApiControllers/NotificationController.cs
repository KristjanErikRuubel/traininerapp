
using System.Threading.Tasks;
using Contracts.BLL.App;
using Microsoft.AspNetCore.Mvc;
using PublicApi.DTO.v1;

namespace WebApp.ApiControllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class NotificationController : ControllerBase
    {
        private IAppBLL bll;
        public NotificationController(IAppBLL bll)
        {
            this.bll = bll;
        }
  
        [HttpPost]
        public async Task PostNotification(NewNotificationDTO notification)
        {
            await bll.NotificationService.SendOutCustomNotification(notification);
        }
        
    }
}
