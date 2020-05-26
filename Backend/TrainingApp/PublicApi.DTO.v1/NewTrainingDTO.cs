using System;
using System.Collections.Generic;
using Domain.Identity;
using PublicApi.DTO.v1.Identity;

namespace PublicApi.DTO.v1
{
    public class NewTrainingDTO
    {
        public string Duration { get; set; }
        public string Start { get; set; }
        public string StartTime { get; set; }
        public string TrainingPlaceId { get; set; }
        public string Description { get; set; }
        public string NotificationContent { get; set; }
        public ICollection<UserDTO> PeopleInvited { get; set; }
        
        public string TeamId { get; set; }
        public string Cost { get; set; }
        public UserDTO createdBy { get; set; }
        public override string ToString()
        {
            return Duration + " " + Start + " " + StartTime + " " + TrainingPlaceId + " " + Description + " " +
                   NotificationContent + " " + Cost;
        }
    }
}