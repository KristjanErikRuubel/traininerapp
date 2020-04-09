using System;
using Contracts.DAL.Base;
using DAL.Base;
using Domain.Identity;

namespace Domain
{
    public class Notification : Notification<Guid>, IDomainEntity
    {
    }
    public class Notification<TKey>  : DomainEntity<TKey>
        where TKey : struct, IEquatable<TKey>
    {
        public string Title { get; set; }
        public string Content { get; set; }
        public virtual Guid AppUserId { get; set; }
        public virtual AppUser Reciver { get; set; }
        public bool Recived { get; set; }
        public Guid? TrainingId { get; set; }
        public Training? Training { get; set; }
        public virtual NotificationAnswer? NotificationAnswer { get; set; }
    }
}