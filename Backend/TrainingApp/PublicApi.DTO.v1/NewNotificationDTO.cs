using System.Collections.Generic;
using PublicApi.DTO.v1.Identity;

namespace PublicApi.DTO.v1
{
    public class NewNotificationDTO
    {
        public string Title { get; set; }
        public string Content { get; set; }
        public List<UserDTO> Players { get; set; }
    }
}