using System;
using System.Collections.Generic;
using Domain.Identity;
using PublicApi.DTO.v1.Identity;

namespace PublicApi.DTO.v1
{
    public class TeamDTO
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public ICollection<UserDTO> Users { get; set; }
    }
}