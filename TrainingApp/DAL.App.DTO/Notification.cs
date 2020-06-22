﻿using System;
using ee.itcollege.krruub.Contracts.DAL.Base;
using DAL.App.DTO.Identity;

namespace DAL.App.DTO
{
    public class Notification : Notification<Guid>, IDomainBaseEntity<Guid>, IDomainEntity<Guid>
    {
    }
    public class Notification<TKey> 
        where TKey : struct, IEquatable<TKey>
    {
        public TKey Id { get; set; }
        public string? Title { get; set; }
        public string? Content { get; set; }
        public string? NotificationType { get; set; }
        public virtual TKey AppUserId { get; set; }
        public virtual AppUser? Reciver { get; set; }
        public bool Recived { get; set; }
        public Guid? TrainingId { get; set; }
        public virtual NotificationAnswer? NotificationAnswer { get; set; }
    }
}