using System;
using ee.itcollege.krruub.Contracts.DAL.Base;
namespace Domain
{
    public class Team : Team<Guid>, IDomainEntity, IDomainEntityBaseMetadata
    { 
    }

    public class Team<TKey> : IDomainEntityBaseMetadata<TKey>
        where TKey : struct, IEquatable<TKey>
    {
        public string? Name { get; set; }
        public string? Description { get; set; }

        public Guid Id { get; set; }
    }
}