using System;
using System.Text.Json.Serialization;
using Contracts.DAL.Base;
using DAL.Base;
using Domain.Identity;

namespace Domain
{
    public class UserInTraining : UserInTraining<Guid>, IDomainEntity
    {} 
    public class UserInTraining <TKey> : DomainEntity<TKey>
        where TKey : struct, IEquatable<TKey>
    {
        public virtual AppUser User { get; set; }
        public virtual Guid AppUserId { get; set; }
        [JsonIgnore]
        public virtual Guid TrainingId { get; set; }
        [JsonIgnore]
        public virtual Training Training { get; set; }
        public bool AttendingTraining { get; set; }
    }
}