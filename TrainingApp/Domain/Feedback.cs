using System;
using Domain.Identity;
using ee.itcollege.krruub.Contracts.DAL.Base;

namespace Domain
{
    public class Feedback : Feedback<Guid>, IDomainEntityBaseMetadata, BaseEntity<Guid>
    {
        
    }
    
    
    public class Feedback<TKey>  : IDomainEntityBaseMetadata<Guid>, BaseEntity<TKey>
        where TKey : struct, IEquatable<TKey>
    {
        public string? Content { get; set; }
        public AppUser? AppUser { get; set; }
        public Guid AppUserId { get; set; }
        public Int16 Rating { get; set; }
        public Guid Id { get; set; }
        public string? CreatedBy { get; set; }
        public DateTime CreatedAt { get; set; }
        public string? ChangedBy { get; set; }
        public DateTime ChangedAt { get; set; }
    }
}