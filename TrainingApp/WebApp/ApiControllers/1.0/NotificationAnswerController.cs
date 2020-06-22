using System.Threading.Tasks;
using Contracts.BLL.App;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PublicApi.DTO.v1;

namespace WebApp.ApiControllers._1._0
{
    [Route("api/[controller]")]
    [ApiController]
    [ApiVersion( "1.0" )]
    [Route("api/v{version:apiVersion}/[controller]")]
    public class NotificationAnswerController : ControllerBase
    {
        private IAppBLL _bll;

        public NotificationAnswerController(IAppBLL bll)
        {
            _bll = bll;
        }
        
        [HttpPost]
        public async Task PostNotificationAnswer([FromBody] NotificationAnswerDTO notificationAnswer)
        {
            await _bll.NotificationAnswerService.AnswerNotification(notificationAnswer);
        }

        [HttpPost]
        [Route("/change")]
        public async Task ChangeAnswer([FromBody] NotificationAnswerDTO notificationAnswer)
        {
            await _bll.NotificationAnswerService.ChangeAnswer(notificationAnswer);
        }
    }
}
