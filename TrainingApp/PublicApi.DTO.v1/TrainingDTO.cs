using System;
using System.Collections.Generic;
using Domain;
using PublicApi.DTO.v1.Identity;

namespace PublicApi.DTO.v1
{
    public class TrainingDTO
    {
        public DateTime TrainingDate { get; set; }
        public Guid Id { get; set; }
        public TrainingPlaceDTO TrainingPlace { get; set; }
        public string TrainingStatus { get; set; }
        public TimeSpan StartTime { get; set; }
        public string Duration { get; set; }
        public ICollection<UserInTrainingDTO> PeopleInvited { get; set; }
        public ICollection<UserDTO> PeopleAttending { get; set; }
        public string Description { get; set; }
        
        public UserDTO CreatedBy { get; set; }
        public List<CommentDTO> Comments { get; set; }
    }

    public class UserInTrainingDTO
    {
        public Guid Id { get; set; }
        public string userName { get; set; }
        public string email { get; set; }
        public string phoneNumber { get; set; }
        public string teamName { get; set; }
        public string token { get; set; }
        public  List<PlayerPositionDTO> positions { get; set; }
        
        public string role { get; set; }
        public Guid? teamId { get; set; }

        public NotificationAnswerDTO answer { get; set; }
        public bool recived { get; set; }
    }
}