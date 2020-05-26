#nullable enable
using System;
using BLL.App.DTO.Identity;
using ee.itcollege.krruub.Contracts.DAL.Base;

namespace BLL.App.DTO
{
    public class Notification : Notification<Guid>, IDomainBaseEntity<Guid>, IDomainEntity<Guid>
    {
    }
    public class Notification<TKey> 
        where TKey : struct, IEquatable<TKey>
    {
        public TKey Id { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
        public string NotificationType { get; set; }
        public virtual TKey? AppUserId { get; set; }
        public virtual AppUser? Reciver { get; set; }
        public bool Recived { get; set; }
        public  virtual TKey? TrainingId { get; set; }
        public Training? Training { get; set; }
        public virtual NotificationAnswer? NotificationAnswer { get; set; }
    }
}