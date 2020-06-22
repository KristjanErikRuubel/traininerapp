namespace BLL.App.Mappers
{
    public static class NotificationMapper
    {
        public static DTO.Notification Map(DAL.App.DTO.Notification notification)
        {
            var dto = new DTO.Notification
            {
                Id = notification.Id,
                Title = notification.Title,
                Content = notification.Content,
                AppUserId = notification.AppUserId,
                NotificationType = notification.NotificationType,
                TrainingId = notification.TrainingId
            };
            return dto;
        }
    }
}