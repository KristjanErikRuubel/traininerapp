using System;
using ee.itcollege.krruub.Contracts.DAL.Base;

namespace Domain
{
    public class NotificationAnswer : NotificationAnswer<Guid>, IDomainEntityBaseMetadata
    {}
    public class NotificationAnswer <TKey> : IDomainEntityBaseMetadata<TKey>
        where TKey : struct, IEquatable<TKey>
    {
        public string Content { get; set; }
        public Boolean Attending { get; set; }
        public Guid? NotificationId { get; set; }
        public virtual Notification? Notification { get; set; }
        public Guid Id { get; set; }
    }
}