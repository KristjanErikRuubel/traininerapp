using System;
using System.Collections.Generic;
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
        public ICollection<UserDTO> PeopleInvited { get; set; }
        public ICollection<UserDTO> PeopleAttending { get; set; }
        public string Description { get; set; }
        
        public UserDTO CreatedBy { get; set; }
    }
}