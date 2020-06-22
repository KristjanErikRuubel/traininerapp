using System;
using ee.itcollege.krruub.Contracts.DAL.Base;

namespace Domain
{
    public class NotificationAnswer : NotificationAnswer<Guid>, IDomainEntityBaseMetadata, BaseEntity<Guid>
    {}
    public class NotificationAnswer <TKey> : IDomainEntityBaseMetadata<TKey>, BaseEntity<TKey>
        where TKey : struct, IEquatable<TKey>
    {
        public string? Content { get; set; }
        public Boolean Attending { get; set; }
        public Guid? NotificationId { get; set; }
        public virtual Notification? Notification { get; set; }
        public Guid Id { get; set; }
        public string? CreatedBy { get; set; }
        public DateTime CreatedAt { get; set; }
        public string? ChangedBy { get; set; }
        public DateTime ChangedAt { get; set; }
    }
}