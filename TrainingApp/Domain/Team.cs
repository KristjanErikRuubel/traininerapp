using System;
using ee.itcollege.krruub.Contracts.DAL.Base;
namespace Domain
{
    public class Team : Team<Guid>, IDomainEntity, IDomainEntityBaseMetadata, BaseEntity<Guid>
    { 
    }

    public class Team<TKey> : IDomainEntityBaseMetadata<TKey>, BaseEntity<TKey>
        where TKey : struct, IEquatable<TKey>
    {
        public string? Name { get; set; }
        public string? Description { get; set; }

        public Guid Id { get; set; }
        public string? CreatedBy { get; set; }
        public DateTime CreatedAt { get; set; }
        public string? ChangedBy { get; set; }
        public DateTime ChangedAt { get; set; }
    }
}