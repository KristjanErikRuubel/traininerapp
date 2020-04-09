using System;
using Contracts.DAL.Base;
using DAL.Base;

namespace Domain
{
    public class NotificationAnswer : NotificationAnswer<Guid>, IDomainEntity
    {}
    public class NotificationAnswer <TKey> : DomainEntity<TKey>
        where TKey : struct, IEquatable<TKey>
    {
        public string Content { get; set; }
        public Boolean Attending { get; set; }
        public Guid NotificationId { get; set; }
        public virtual Notification Notification { get; set; }
    }
}