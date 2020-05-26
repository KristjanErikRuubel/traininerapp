#nullable enable
using System;
using ee.itcollege.krruub.Contracts.DAL.Base;

namespace BLL.App.DTO
{
    public class NotificationAnswer : NotificationAnswer<Guid>, IDomainBaseEntity<Guid>, IDomainEntity<Guid>
    {}
    public class NotificationAnswer <TKey> 
        where TKey : struct, IEquatable<TKey>
    {
        public TKey Id { get; set; }
        public string Content { get; set; }
        public Boolean Attending { get; set; }
        public TKey? NotificationId { get; set; }
        public virtual Notification? Notification { get; set; }
    }
}