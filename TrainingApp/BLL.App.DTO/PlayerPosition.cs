using System;
using ee.itcollege.krruub.Contracts.DAL.Base;

namespace BLL.App.DTO
{
    public class PlayerPosition : PlayerPosition<Guid>, IDomainBaseEntity<Guid>, IDomainEntity<Guid>
    {
        
    }
    public class PlayerPosition<TKey>
        where TKey : struct, IEquatable<TKey>
    {
        public TKey Id { get; set; }
        public TKey? AppUserId { get; set; }
        public string PersonPosition { get; set; }
    }
}