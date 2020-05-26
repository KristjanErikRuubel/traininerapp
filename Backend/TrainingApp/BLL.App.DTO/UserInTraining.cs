using System;
using BLL.App.DTO.Identity;
using ee.itcollege.krruub.Contracts.DAL.Base;

namespace BLL.App.DTO
{
    public class UserInTraining : UserInTraining<Guid>, IDomainBaseEntity<Guid>
    {} 
    public class UserInTraining <TKey>
        where TKey : struct, IEquatable<TKey>
    {
        public Guid Id { get; set; }
        public virtual AppUser User { get; set; }
        public virtual TKey AppUserId { get; set; }
        public virtual TKey TrainingId { get; set; }

        public virtual Training Training { get; set; }
        public bool AttendingTraining { get; set; }
    }
}