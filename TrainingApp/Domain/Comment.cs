using System;
using ee.itcollege.krruub.Contracts.DAL.Base;

namespace Domain
{
    public class Comment : Comment<Guid>, IDomainEntityBaseMetadata
    {
    }
    
    
    public class Comment<TKey>: IDomainEntityBaseMetadata<Guid>, BaseEntity<TKey>
        where TKey : struct, IEquatable<TKey>
    {
        public Guid? TrainingId { get; set; }
        public string? Content { get; set; }
        public Guid? AppUserId { get; set; }
        public Guid Id { get; set; }
        public string? CreatedBy { get; set; }
        public DateTime CreatedAt { get; set; }
        public string? ChangedBy { get; set; }
        public DateTime ChangedAt { get; set; }
    }
}