using System;
using ee.itcollege.krruub.Contracts.DAL.Base;

namespace Domain
{
    public class UserInTrainingTeam: UserInTrainingTeam<Guid>, IDomainEntityBaseMetadata
    {
        
    }
    public class UserInTrainingTeam<TKey> : IDomainEntityBaseMetadata<TKey>, BaseEntity<TKey>
        where TKey : struct, IEquatable<TKey>
    {
        public Guid UserId { get; set; }
        public Guid TrainingTeamId { get; set; }
        
        public Guid Id { get; set; }
        public string? CreatedBy { get; set; }
        public DateTime CreatedAt { get; set; }
        public string? ChangedBy { get; set; }
        public DateTime ChangedAt { get; set; }
    }
}