using System.Collections.Generic;
using System.Threading.Tasks;
using Contracts.BLL.App.Services;
using Contracts.DAL.App;
using Contracts.DAL.App.Repositories;
using DAL.App.DTO;
using ee.itcollege.krruub.BLL.Base.Mappers;
using ee.itcollege.krruub.BLL.Base.Services;
using Microsoft.AspNetCore.Identity.UI.Services;
using PublicApi.DTO.v1;
using PublicApi.DTO.v1.Identity;

namespace BLL.App.Services
{
    public class NotificationService : BaseEntityService<INotificationRepository, IAppUnitOfWork, DAL.App.DTO.Notification, BLL.App.DTO.Notification>,
        INotificationService
    {
        private IEmailSender _sender { get; }
        public NotificationService(IAppUnitOfWork unitOfWork, IEmailSender sender) 
            : base(unitOfWork, new BaseBLLMapper<DAL.App.DTO.Notification, BLL.App.DTO.Notification>(), unitOfWork.NotificationRepository)
        {
            _sender = sender;
        }

        public async Task SendOutNewTrainingNotifications(ICollection<UserDTO> users, string content, Training training)
        {
            foreach (var user in users)
            {
                var notification = new Notification
                {
                    Title = "New training invitation",
                    Content = "You have been invited to training",
                    AppUserId = user.Id,
                    Recived = false,
                    TrainingId = training.Id,
                    NotificationType = "Training Invitation"
                };
                sendOutNotification(notification, user);
                ServiceRepository.Add(notification);
            } 
            await ServiceUnitOfWork.SaveChangesAsync();
        }

        public async Task SendOutCustomNotification(NewNotificationDTO dto)
        {
            foreach (var user in dto.Players)
            {
                var notification = new DAL.App.DTO.Notification
                {
                    Title = dto.Title,
                    Content = dto.Content,
                    AppUserId = user.Id,
                    NotificationType = "View"
                };
                ServiceRepository.Add(notification);
                sendOutNotification(notification, user);
            }
            await ServiceUnitOfWork.SaveChangesAsync();
        }
        

        public void sendOutNotification(DAL.App.DTO.Notification notification, UserDTO user)
        {
            // _sender.send(notification, user);
        }


}
}