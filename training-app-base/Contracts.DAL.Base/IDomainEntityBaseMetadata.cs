using System;

namespace ee.itcollege.krruub.Contracts.DAL.Base
{
    public interface IDomainEntityBaseMetadata : IDomainEntityBaseMetadata<Guid>
    {
    }

    public interface IDomainEntityBaseMetadata<TKey> : IDomainBaseEntity<TKey>, IDomainEntityMetadata
        where TKey : struct, IEquatable<TKey>
    {
    }
}