using System;
using System.Collections.Generic;
using Contracts.DAL.Base;
using DAL.Base;
using Domain.Identity;

namespace Domain
{
    public class Team : Team<Guid>, IDomainEntity 
    { 
    }

    public class Team<TKey> : DomainEntity<TKey>
        where TKey : struct, IEquatable<TKey>
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public ICollection<AppUser> Users { get; set; }

    }
}