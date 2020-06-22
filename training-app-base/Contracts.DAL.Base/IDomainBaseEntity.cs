using System;

namespace ee.itcollege.krruub.Contracts.DAL.Base
{
    public interface IDomainBaseEntity : IDomainBaseEntity<Guid>
    {
    }

    public interface IDomainBaseEntity<TKey> 
        where TKey : struct, IEquatable<TKey>
    {
        public Guid Id { get; set; }
    }
}