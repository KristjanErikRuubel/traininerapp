using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using ee.itcollege.krruub.Contracts.DAL.Base;
using Domain.Identity;

namespace Domain
{
    public class Training  : Training<Guid>, IDomainEntityBaseMetadata
    {
    }

    public class Training<TKey> : IDomainEntityBaseMetadata<TKey>
        where TKey : struct, IEquatable<TKey>
    {
        public DateTime Start { get; set; }
        public TimeSpan StartTime { get; set; }
        public string Duration { get; set; }
        public string Description { set; get; }
        public TrainingPlace TrainingPlace { get; set; }
        public Guid TrainingPlaceId { get; set; }
        public virtual ICollection<UserInTraining> PeopleInTraining { get; set; }
        public string TrainingStatus { get; set; }
        public AppUser? CreatedBy { get; set; }
        public Guid? AppUserId { get; set; }
        public Guid Id { get; set; }
    }
}