using System;
using System.Collections.Generic;
using Domain;

namespace PublicApi.DTO.v1.Identity
{
    public class RegisterDTO
    {
        public string Email { get; set; }
        public string Password { get; set; }
        public string FirstName { get; set; }
        public string PhoneNumber { get; set; }
        public string LastName { get; set; }
        public Guid TeamId { get; set; }
        
        public string Role { get; set; }

        public List<string> PlayerPositions { get; set; }

        public override string ToString()
        {
            return Email + " " + Password + " " + FirstName + " " + LastName + " " + TeamId;
        }
    }
}