using System;
using System.Collections.Generic;
using DAL.App.DTO.Identity;
using ee.itcollege.krruub.Contracts.DAL.Base;

namespace DAL.App.DTO
{
    public class Bill : Bill<Guid>, IDomainBaseEntity<Guid>, IDomainEntity<Guid>
    {
    }

    public class Bill<TKey> where TKey: struct, IEquatable<TKey>
    {
        public TKey Id { get; set; }
        public virtual Int16 Total{ get; set; }
        public virtual DateTime Deadline { get; set; }
        public virtual ICollection<TrainingInBill>? Trainings { get; set; }
        public virtual TKey AppUserId { get; set; }
        public virtual AppUser? User { get; set; }
    }
}