using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Domain;

namespace PublicApi.DTO.v1.Identity
{
    public class UserDTO
    {
        public Guid Id { get; set; }
        public string userName { get; set; }
        public string email { get; set; }
        public string phoneNumber { get; set; }
        public string teamName { get; set; }
        public string token { get; set; }
        public  List<PlayerPositionDTO> positions { get; set; }
        
        public string role { get; set; }
        
        public ICollection<Notification> userNotifications { get; set; }
        public Guid? teamId { get; set; }
    }
}