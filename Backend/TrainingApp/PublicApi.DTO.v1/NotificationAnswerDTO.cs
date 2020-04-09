using System;
using Domain;

namespace PublicApi.DTO.v1
{
    public class NotificationAnswerDTO
    {
        public Guid id { get; set; }
        public string Content { get; set; }
        public Boolean Coming { get; set; }
        public string NotificationId { get; set; }
        public string TrainingId { get; set; }
        public string AppUserId { get; set; }
    }
}