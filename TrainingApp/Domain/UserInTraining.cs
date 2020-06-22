using System;
using ee.itcollege.krruub.Contracts.DAL.Base;
using Domain.Identity;

namespace Domain
{
    public class UserInTraining : UserInTraining<Guid>, IDomainEntityBaseMetadata
    {} 
    public class UserInTraining <TKey> : IDomainEntityBaseMetadata<TKey>, BaseEntity<TKey>
        where TKey : struct, IEquatable<TKey>
    {
        public virtual AppUser? AppUser { get; set; }
        public virtual TKey AppUserId { get; set; }
        public virtual Guid TrainingId { get; set; }
        public virtual Training? Training { get; set; }
        public bool AttendingTraining { get; set; }
        public Guid Id { get; set; }
        public string? CreatedBy { get; set; }
        public DateTime CreatedAt { get; set; }
        public string? ChangedBy { get; set; }
        public DateTime ChangedAt { get; set; }
    }
}