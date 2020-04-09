using System;
using Domain;

namespace PublicApi.DTO.v1
{
    public class NotificationDTO
    {
        public string NotificationContent { get; set; }
        public Guid Id { get; set; }
        public bool Recideved { get; set; }
        public NotificationAnswerDTO Answer { get; set; }
        public string Title { get; set; }
        public TrainingDTO TrainingDto { get; set; }
    }
}