using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using Contracts.BLL.App.Services;
using DAL.App.EF;
using Domain;
using Domain.Identity;
using Microsoft.AspNetCore.Identity.UI.Services;
using PublicApi.DTO.v1.Identity;

namespace BLL.App.Services
{
    public class NotificationService : INotificationService
    {
        private AppDbContext ctx { get; set; }
        private IEmailSender _sender { get; set; }

        public NotificationService(AppDbContext context)
        {
            ctx = context;
        }

        public async Task SendOutNewTrainingNotifications(ICollection<UserDTO> users, string content, Training training)
        {
            foreach (var user in users)
            {
                var notification = new Notification()
                {
                    Title = "New training invitation",
                    Content = "You have been invited to training",
                    AppUserId = user.Id,
                    Recived = false,
                    TrainingId = training.Id
                };
                sendOutNotification(notification, user);
                await ctx.Notifications.AddAsync(notification);
                await ctx.SaveChangesAsync();
            }
        }

        public void sendOutNotification(Notification notification, UserDTO user)
        {
            // _sender.send(notification, user);
        }


}
}