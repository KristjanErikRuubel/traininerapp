using System;
using ee.itcollege.krruub.Contracts.DAL.Base;

namespace Domain
{
    public class PlayerPosition : PlayerPosition<Guid>, IDomainEntityBaseMetadata
    {
        
    }
    public class PlayerPosition<TKey> : IDomainEntityBaseMetadata<Guid>
        where TKey : struct, IEquatable<TKey>
    {
        public Guid? AppUserId { get; set; }
        public string PersonPosition { get; set; }
        public Guid Id { get; set; }
    }
}