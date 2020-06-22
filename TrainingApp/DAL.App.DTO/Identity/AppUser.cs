using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using ee.itcollege.krruub.Contracts.DAL.Base;

namespace DAL.App.DTO.Identity
{
    public class AppUser : AppUser<Guid>, IDomainBaseEntity<Guid>, IDomainEntity<Guid>
    {
        
    }

    public class AppUser<TKey>
        where TKey : IEquatable<TKey>
    {

        public TKey Id { get; set; } = default!;
        [MaxLength(128)] [MinLength(1)] public string? FirstName { get; set; }
        [MaxLength(128)] [MinLength(1)] public string? LastName { get; set; }
        public Team? Team { get; set; }
        public Guid? TeamId { get; set; }
        public List<PlayerPosition>? PlayerPositions { get; set; }
        public string? Email { get; set; }
        public string? PhoneNumber { get; set; }
        public string? UserName { get; set; }

    }
}