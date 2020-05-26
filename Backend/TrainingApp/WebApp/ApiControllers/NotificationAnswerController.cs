using System.Threading.Tasks;
using Contracts.BLL.App;
using Microsoft.AspNetCore.Mvc;
using PublicApi.DTO.v1;

namespace WebApp.ApiControllers
{
    [Route("api/[controller]")]
    [ApiController]
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
