using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;
using Contracts.DAL.Base;
using DAL.Base;

namespace Domain
{
    public class Training  : Training<Guid>, IDomainEntity
    {
    }

    public class Training<TKey> : DomainEntity<TKey>
        where TKey : struct, IEquatable<TKey>
    {
        public DateTime Start { get; set; }
        public TimeSpan StartTime { get; set; }
        public string Duration { get; set; }
        public string Description { set; get; }
        [Column(TypeName = "decimal(18,4)")]
        public TrainingPlace TrainingPlace { get; set; }
        public Guid TrainingPlaceId { get; set; }
        public virtual ICollection<UserInTraining> PeopleInTraining { get; set; }
        public string TrainingStatus { get; set; }
    }
}