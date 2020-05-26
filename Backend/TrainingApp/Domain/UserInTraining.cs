using System;
using ee.itcollege.krruub.Contracts.DAL.Base;
using Domain.Identity;

namespace Domain
{
    public class UserInTraining : UserInTraining<Guid>, IDomainEntityBaseMetadata
    {} 
    public class UserInTraining <TKey> : IDomainEntityBaseMetadata<TKey>
        where TKey : struct, IEquatable<TKey>
    {
        public virtual AppUser AppUser { get; set; }
        public virtual TKey AppUserId { get; set; }
        public virtual Guid TrainingId { get; set; }
        public virtual Training Training { get; set; }
        public bool AttendingTraining { get; set; }
        public Guid Id { get; set; }
    }
}