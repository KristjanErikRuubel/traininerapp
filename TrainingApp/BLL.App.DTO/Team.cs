#nullable enable
using System;
using System.Collections.Generic;
using BLL.App.DTO.Identity;
using ee.itcollege.krruub.Contracts.DAL.Base;

namespace BLL.App.DTO
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