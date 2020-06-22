using System;
using System.Collections.Generic;
using Domain.Identity;
using ee.itcollege.krruub.Contracts.DAL.Base;

namespace Domain
{
    public class TrainingTeam : TrainingTeam<Guid>, IDomainEntityBaseMetadata
    {
    }
    public class TrainingTeam<TKey> : IDomainEntityBaseMetadata<TKey>, BaseEntity<TKey>
        where TKey : struct, IEquatable<TKey>
    {
        
        public List<UserInTrainingTeam> UsersInTrainingTeam { get; set; }
        public string? TeamName { get; set; }
        public Guid Id { get; set; }
        public string? CreatedBy { get; set; }
        public DateTime CreatedAt { get; set; }
        public string? ChangedBy { get; set; }
        public DateTime ChangedAt { get; set; }
    }
}