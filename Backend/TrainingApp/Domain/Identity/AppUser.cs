using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using ee.itcollege.krruub.Contracts.DAL.Base;
using Microsoft.AspNetCore.Identity;

namespace Domain.Identity
{
    public class AppUser : AppUser<Guid>, IDomainEntityBaseMetadata<Guid>
    {
        
    }

    public class AppUser<TKey> : IdentityUser<TKey> 
        where TKey : IEquatable<TKey>
    {
        [MaxLength(128)] [MinLength(1)] public string? FirstName { get; set; }
        [MaxLength(128)] [MinLength(1)] public string? LastName { get; set; }
        public Team Team { get; set; }
        public Guid? TeamId { get; set; }
        public string? AppRoleId { get; set; }
        public List<PlayerPosition>? PlayerPositions { get; set; }
    }
}