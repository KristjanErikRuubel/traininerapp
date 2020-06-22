using Domain;

namespace DAL.App.EF.Mappers
{
    public static class NotificationAnswerMapper
    {
        public static DTO.NotificationAnswer Map(Domain.NotificationAnswer notificationAnswer)
        {
            DTO.NotificationAnswer dto = new DTO.NotificationAnswer
            {
                Id = notificationAnswer.Id,
                Content = notificationAnswer.Content,
                Attending = notificationAnswer.Attending,
                NotificationId = notificationAnswer.NotificationId
            };
            
            return dto;
        }
        
        public static Domain.NotificationAnswer   MapToDomain(DTO.NotificationAnswer notificationAnswer)
        {
            Domain.NotificationAnswer domain = new Domain.NotificationAnswer
            {
                Content = notificationAnswer.Content,
                Attending = notificationAnswer.Attending,
                NotificationId = notificationAnswer.NotificationId
            };
            return domain;
        }
        
        
    }
}