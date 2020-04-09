using System;
using System.Linq;
using System.Threading.Tasks;
using Contracts.BLL.App.Services;
using DAL.App.EF;
using Domain;
using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.EntityFrameworkCore;
using PublicApi.DTO.v1;
using PublicApi.DTO.v1.Identity;

namespace BLL.App.Services
{
    public class NotificationAnswerService : INotificationAnswerService
    {
        private AppDbContext ctx { get; set; }
        private IEmailSender _sender { get; set; }

        public NotificationAnswerService(AppDbContext context)
        {
            ctx = context;
        }

        public async Task AnswerNotification( NotificationAnswerDTO notificationAnswerDto)
        {
            var notificationAnswer = new NotificationAnswer
            {
                Attending = notificationAnswerDto.Coming,
                Content = notificationAnswerDto.Content,
                NotificationId = Guid.Parse(notificationAnswerDto.NotificationId),
            };
            var notification = await ctx.Notifications.FindAsync(Guid.Parse(notificationAnswerDto.NotificationId));

            notification.Recived = true;
            
            var userInTraining = ctx.UsersInTrainings.FromSqlRaw("Select * From  UsersInTrainings where TrainingId = '" + notificationAnswerDto.TrainingId + "' and  AppUserId = '" + notificationAnswerDto.AppUserId + "'").First();

            if (notificationAnswerDto.Coming == true)
            {
                userInTraining.AttendingTraining = true;
            }
            await ctx.NotificationAnswers.AddAsync(notificationAnswer);
            ctx.UsersInTrainings.Update(userInTraining);
            await ctx.SaveChangesAsync();
        }

        public async Task ChangeAnswer(NotificationAnswerDTO notificationAnswerDto)
        {
          
        }


}
}