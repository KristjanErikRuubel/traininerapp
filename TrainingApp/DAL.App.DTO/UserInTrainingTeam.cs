using System;
using ee.itcollege.krruub.Contracts.DAL.Base;

namespace DAL.App.DTO
{
    public class UserInTrainingTeam: UserInTrainingTeam<Guid>, IDomainEntityBaseMetadata
    {
        
    }

    public class UserInTrainingTeam<TKey> 
        where TKey : struct, IEquatable<TKey>
    {
        public TKey? UserId { get; set; }
        public TKey? TrainingTeamId { get; set; }

        public Guid Id { get; set; }
    }
}