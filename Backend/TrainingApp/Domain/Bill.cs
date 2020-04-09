using System;
using Contracts.DAL.Base;
using Domain.Identity;
using DAL.Base;

namespace Domain
{
    public class Bill : Bill<Guid>, IDomainEntity
    {
        
    }

    public class Bill<TKey> : DomainEntity<TKey> where TKey: struct, IEquatable<TKey>
    {
        public Int16 Total{ get; set; }
        public AppUser User { get; set; }
    }
}