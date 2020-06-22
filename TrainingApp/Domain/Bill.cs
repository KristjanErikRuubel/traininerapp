﻿using System;
 using System.Collections.Generic;
 using ee.itcollege.krruub.Contracts.DAL.Base;
 using Domain.Identity;

 namespace Domain
{
    public class Bill : Bill<Guid>, IDomainEntityBaseMetadata, BaseEntity<Guid>
    {
    }

    public class Bill<TKey> : ee.itcollege.krruub.Contracts.DAL.Base.IDomainEntityBaseMetadata<Guid>, BaseEntity<TKey>
        where TKey : struct, IEquatable<TKey>
    {
        public Int16 Total{ get; set; }
        public DateTime Deadline { get; set; }
        public List<TrainingInBill>? Trainings { get; set; }
        public Guid AppUserId { get; set; }
        public AppUser? User { get; set; }
        public Guid Id { get; set; }
        public string? CreatedBy { get; set; }
        public DateTime CreatedAt { get; set; }
        public string? ChangedBy { get; set; }
        public DateTime ChangedAt { get; set; }
    }
}