using System;
using ee.itcollege.krruub.Contracts.DAL.Base;

namespace BLL.App.DTO
{
    public class Comment : Comment<Guid>, IDomainEntityBaseMetadata, IDomainEntity<Guid>
    {
        
    }

    
    public class Comment<TKey>  : IDomainEntityBaseMetadata<Guid>
        where TKey : struct, IEquatable<TKey>
    {
        public Guid? TrainingId { get; set; }
        public string? Content { get; set; }
        public TKey? AppUserId { get; set; }
        public Guid Id { get; set; }
    }
}