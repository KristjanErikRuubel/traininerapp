using System;
using BLL.App.DTO.Identity;
using ee.itcollege.krruub.Contracts.DAL.Base;

namespace BLL.App.DTO
{
    public class Feedback : Feedback<Guid>, IDomainEntityBaseMetadata, IDomainEntity<Guid>
    {
        
    }
    
    
    public class Feedback<TKey>  : IDomainEntityBaseMetadata<Guid>
        where TKey : struct, IEquatable<TKey>
    {
        public string Content { get; set; }
        public AppUser AppUser { get; set; }
        public Guid AppUserId { get; set; }
        public Int16 Rating { get; set; }
        public Guid Id { get; set; }
    }
}