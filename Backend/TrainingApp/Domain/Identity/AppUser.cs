using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Identity;

namespace Domain.Identity
{
    public class AppUser : AppUser<Guid>
    {
        
    }

    public class AppUser<TKey> : IdentityUser<TKey> 
        where TKey : IEquatable<TKey>
    {
        // add your own fields
        [MaxLength(128)] [MinLength(1)] public string FirstName { get; set; } = default;
        [MaxLength(128)] [MinLength(1)] public string LastName { get; set; } = default;
        public Team Team { get; set; }
        public Guid TeamId { get; set; }
        public Guid RoleId { get; set; }
        public UserRoleInTeam Role { get; set; }
    }
}