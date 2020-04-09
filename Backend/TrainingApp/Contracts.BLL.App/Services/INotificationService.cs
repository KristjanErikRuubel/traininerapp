using System.Collections.Generic;
using System.Threading.Tasks;
using Domain;
using Domain.Identity;
using PublicApi.DTO.v1.Identity;

namespace Contracts.BLL.App.Services
{
    public interface INotificationService
    {
        public Task SendOutNewTrainingNotifications(ICollection<UserDTO> users, string content, Training training);
        public void sendOutNotification(Notification notification, UserDTO user);

    }
}