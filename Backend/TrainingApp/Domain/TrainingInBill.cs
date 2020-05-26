using System;
using ee.itcollege.krruub.Contracts.DAL.Base;

namespace Domain
{
    public class TrainingInBill  : TrainingInBill<Guid>, IDomainEntityBaseMetadata
    {

    }
    
    
    public class TrainingInBill<TKey> : IDomainEntityBaseMetadata<TKey>
        where TKey : struct, IEquatable<TKey>
    {
        public Training? Training { get; set; }
        public Guid? TrainingId { get; set; }

        public Bill? Bill { get; set; }
        public Guid? BillId { get; set; }
        public Guid Id { get; set; }
    }
}