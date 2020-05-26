using System;
using System.Collections.Generic;
using BLL.App.DTO.Identity;
using ee.itcollege.krruub.Contracts.DAL.Base;

namespace BLL.App.DTO
{
    public class Training  : Training<Guid>, IDomainBaseEntity<Guid>, IDomainEntity<Guid>
    {
    }

    public class Training<TKey>
        where TKey : struct, IEquatable<TKey>
    {
        public TKey Id { get; set; }
        public DateTime Start { get; set; }
        public TimeSpan StartTime { get; set; }
        public string Duration { get; set; }
        public string Description { set; get; }
        public TrainingPlace TrainingPlace { get; set; }
        public TKey TrainingPlaceId { get; set; }
        
        public virtual ICollection<UserInTraining> PeopleInTraining { get; set; }
        public string TrainingStatus { get; set; }
        public AppUser? CreatedBy { get; set; }
        public TKey? AppUserId { get; set; }
    }
}