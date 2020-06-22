using System;
using System.Collections.Generic;
using ee.itcollege.krruub.Contracts.DAL.Base;

namespace DAL.App.DTO
{
    public class TrainingTeam : TrainingTeam<Guid>, IDomainEntity<Guid>
    {
        
    }
    public class TrainingTeam <TKey> 
        where TKey : struct, IEquatable<TKey>
    {
                
        public List<UserInTrainingTeam>? UsersInTrainingTeam { get; set; }
        public string? TeamName { get; set; }
        public Guid Id { get; set; }
    }

}