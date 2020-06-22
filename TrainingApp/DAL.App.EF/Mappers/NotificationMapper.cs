using DAL.App.DTO;

namespace DAL.App.EF.Mappers
{
    public static class NotificationMapper
    {
        public static DTO.Notification Map(Domain.Notification notification)
        {
            Notification dto = new DTO.Notification
            {
                Id = notification.Id,
                Title = notification.Title,
                Content = notification.Content,
                AppUserId = notification.AppUserId,
                NotificationType = notification.NotificationType,
                TrainingId = notification.TrainingId,
                Recived = notification.Recived
            };
            
            return dto;
        }
        public static Domain.Notification MapToDomain(DTO.Notification notification)
        {
            Domain.Notification domain = new Domain.Notification
            {
                Id = notification.Id,
                Title = notification.Title,
                Content = notification.Content,
                AppUserId = notification.AppUserId,
                NotificationType = notification.NotificationType,
                TrainingId = notification.TrainingId,
                Recived = notification.Recived
            };
            
            return domain;
        }
    }
}