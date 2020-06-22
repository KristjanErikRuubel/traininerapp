using System;
using ee.itcollege.krruub.Contracts.DAL.Base;

namespace ee.itcollege.krruub.DAL.Base
{
    public abstract class DomainEntity :  DomainEntity<Guid>
    {
    }

    public abstract class DomainEntity<TKey> :  IDomainEntity<TKey> 
        where TKey : struct, IEquatable<TKey>
    {
        public virtual Guid Id { get; set; }
        // public virtual string? CreatedBy { get; set; }
        // public virtual DateTime CreatedAt { get; set; }
        // public virtual string? ChangedBy { get; set; }
        // public virtual DateTime ChangedAt { get; set; }
        // public string? DeletedBy { get; set; }
        // public DateTime? DeletedAt { get; set; }
    }
}