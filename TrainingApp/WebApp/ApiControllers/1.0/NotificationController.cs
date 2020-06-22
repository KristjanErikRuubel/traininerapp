using System.Threading.Tasks;
using Contracts.BLL.App;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PublicApi.DTO.v1;

namespace WebApp.ApiControllers._1._0
{
    [ApiController]
    [ApiVersion( "1.0" )]
    [Route("api/v{version:apiVersion}/[controller]")]
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
