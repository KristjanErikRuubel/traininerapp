using System;
using System.Threading.Tasks;
using PublicApi.DTO.v1;

namespace Contracts.BLL.App.Services
{
    public interface INotificationAnswerService
    {

        public Task AnswerNotification(NotificationAnswerDTO notificationAnswerDto);
        public Task ChangeAnswer(NotificationAnswerDTO notificationAnswerDto);
        public Task RemoveNotificationAnswer(Guid id);
    }
}