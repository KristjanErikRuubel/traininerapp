using System;
using Contracts.DAL.Base;
using DAL.Base;
using Domain.Identity;

namespace Domain
{
    public class UserRoleInTeam : UserRoleInTeam<Guid>, IDomainEntity
    {
        
    }
    public class UserRoleInTeam<TKey> : DomainEntity<TKey>
        where TKey : struct, IEquatable<TKey>
    {
        public string Role { get; set; }
        public string PersonPosition { get; set; }
    }
}