using System;
using System.Linq;
using System.Threading.Tasks;
using Contracts.BLL.App.Services;
using Contracts.DAL.App;
using Contracts.DAL.App.Repositories;

using ee.itcollege.krruub.BLL.Base.Mappers;
using ee.itcollege.krruub.BLL.Base.Services;
using Microsoft.AspNetCore.Identity.UI.Services;
using PublicApi.DTO.v1;


namespace BLL.App.Services
{
    public class NotificationAnswerService : BaseEntityService<INotificationAnswerRepository, IAppUnitOfWork, DAL.App.DTO.NotificationAnswer, BLL.App.DTO.NotificationAnswer>, INotificationAnswerService
    {
        private IEmailSender _sender { get; set; }

        public NotificationAnswerService(IAppUnitOfWork unitOfWork) : base(unitOfWork, new IdentityMapper<DAL.App.DTO.NotificationAnswer, BLL.App.DTO.NotificationAnswer>(), unitOfWork.NotificationAnswerRepository)
        {
        }

        public async Task AnswerNotification( NotificationAnswerDTO notificationAnswerDto)
        {
            var notificationAnswer = new DAL.App.DTO.NotificationAnswer
            {
                Attending = notificationAnswerDto.Coming,
                Content = notificationAnswerDto.Content,
                NotificationId = Guid.Parse(notificationAnswerDto.NotificationId),
            };  
            await ServiceRepository.AddNewAnswer(notificationAnswer);
            await ServiceUnitOfWork.SaveChangesAsync();
            var notification = await ServiceUnitOfWork.NotificationRepository.FirstOrDefaultAsync(Guid.Parse(notificationAnswerDto.NotificationId));
            await ServiceUnitOfWork.NotificationRepository.UpdateNotification(notification);
            await ServiceUnitOfWork.SaveChangesAsync();
            var userInTraining =
                await ServiceUnitOfWork.UsersInTrainingRepository.FindByAppUserIdAndTrainingId(Guid.Parse(notificationAnswerDto.AppUserId),
                    Guid.Parse(notificationAnswerDto.TrainingId));
            if (notificationAnswerDto.Coming)
            {
                userInTraining.AttendingTraining = true;
                ServiceUnitOfWork.UsersInTrainingRepository.UpdateUserInTraining(userInTraining);
            }
            await ServiceUnitOfWork.SaveChangesAsync();
        }

        public async Task ChangeAnswer(NotificationAnswerDTO notificationAnswerDto)
        {
            
            var previousAnswer = await ServiceRepository.FirstOrDefaultAsync(notificationAnswerDto.id);
            
            
            previousAnswer.Attending = notificationAnswerDto.Coming;
            previousAnswer.Content = notificationAnswerDto.Content;
            var userInTraining =
                await ServiceUnitOfWork.UsersInTrainingRepository.FindByAppUserIdAndTrainingId(
                    Guid.Parse(notificationAnswerDto.AppUserId),
                    Guid.Parse(notificationAnswerDto.TrainingId));
            if (notificationAnswerDto.Coming)
            {
                userInTraining.AttendingTraining = true;
            }
            ServiceRepository.Add(previousAnswer);
            await ServiceUnitOfWork.SaveChangesAsync();
        }

        public async Task RemoveNotificationAnswer(Guid id)
        {
            ServiceRepository.Remove(id);
            await ServiceUnitOfWork.SaveChangesAsync();
        }
    }
}