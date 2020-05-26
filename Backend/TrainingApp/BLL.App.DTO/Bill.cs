#nullable enable
using System;
using System.Collections.Generic;
using BLL.App.DTO.Identity;
using ee.itcollege.krruub.Contracts.DAL.Base;

namespace BLL.App.DTO
{
    public class Bill : Bill<Guid>, IDomainBaseEntity<Guid>, IDomainEntity<Guid>
    {
    }

    public class Bill<TKey> where TKey: struct, IEquatable<TKey>
    {
        public TKey Id { get; set; }
        public virtual Int16 Total{ get; set; }
        public virtual DateTime Deadline { get; set; }
        public virtual List<TrainingInBill> Trainings { get; set; }
        public virtual TKey AppUserId{ get; set; } = default!;
        public virtual AppUser<TKey>? AppUser { get; set; }
    }
}