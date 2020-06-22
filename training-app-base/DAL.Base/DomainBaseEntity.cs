using System;
using ee.itcollege.krruub.Contracts.DAL.Base;

namespace ee.itcollege.krruub.DAL.Base
{
    public abstract class DomainBaseEntity : IDomainBaseEntity
    {
        public virtual Guid Id { get; set; }
    }
}