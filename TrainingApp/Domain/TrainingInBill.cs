using System;
using ee.itcollege.krruub.Contracts.DAL.Base;

namespace Domain
{
    public class TrainingInBill  : TrainingInBill<Guid>, IDomainEntityBaseMetadata
    {

    }
    
    
    public class TrainingInBill<TKey> : IDomainEntityBaseMetadata<TKey>, BaseEntity<TKey>
        where TKey : struct, IEquatable<TKey>
    {
        public Training? Training { get; set; }
        public Guid TrainingId { get; set; }

        public Bill? Bill { get; set; }
        public Guid BillId { get; set; }
        public Guid Id { get; set; }
        public string? CreatedBy { get; set; }
        public DateTime CreatedAt { get; set; }
        public string? ChangedBy { get; set; }
        public DateTime ChangedAt { get; set; }
    }
}