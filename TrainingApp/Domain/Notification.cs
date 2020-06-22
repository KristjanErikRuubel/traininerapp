using System;
using ee.itcollege.krruub.Contracts.DAL.Base;
using Domain.Identity;

namespace Domain
{
    public class Notification : Notification<Guid>, IDomainEntityBaseMetadata
    {
    }
    public class Notification<TKey>  : IDomainEntityBaseMetadata<Guid>, BaseEntity<TKey>
        where TKey : struct, IEquatable<TKey>
    {
        public string? Title { get; set; }
        public string? Content { get; set; }
        public string? NotificationType { get; set; }
        public virtual Guid AppUserId { get; set; }
        public virtual AppUser? Reciver { get; set; }
        public bool Recived { get; set; }
        public Guid? TrainingId { get; set; }
        public Training? Training { get; set; }
        public virtual NotificationAnswer? NotificationAnswer { get; set; }
        public Guid Id { get; set; }
        public string? CreatedBy { get; set; }
        public DateTime CreatedAt { get; set; }
        public string? ChangedBy { get; set; }
        public DateTime ChangedAt { get; set; }
    }
}