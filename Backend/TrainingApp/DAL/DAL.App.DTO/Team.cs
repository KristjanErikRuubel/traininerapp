using System;
using System.Collections.Generic;
using ee.itcollege.krruub.Contracts.DAL.Base;
using DAL.App.DTO.Identity;

namespace DAL.App.DTO
{
    public class Team : Team<Guid>, IDomainBaseEntity<Guid>, IDomainEntity<Guid>
    { 
    }

    public class Team<TKey>
        where TKey : struct, IEquatable<TKey>
    {
        public TKey Id { get; set; }
        public string Name { get; set; }
        public string? Description { get; set; }
        public ICollection<AppUser>? Users { get; set; }

    }
}