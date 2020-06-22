using System;
using ee.itcollege.krruub.Contracts.DAL.Base;

namespace Domain
{
    public class PlayerPosition : PlayerPosition<Guid>, IDomainEntityBaseMetadata, BaseEntity<Guid>
    {
        
    }
    public class PlayerPosition<TKey> : IDomainEntityBaseMetadata<Guid>, BaseEntity<TKey>
        where TKey : struct, IEquatable<TKey>
    {
        public Guid? AppUserId { get; set; }
        public string? PersonPosition { get; set; }
        public Guid Id { get; set; }
        public string? CreatedBy { get; set; }
        public DateTime CreatedAt { get; set; }
        public string? ChangedBy { get; set; }
        public DateTime ChangedAt { get; set; }
    }
}