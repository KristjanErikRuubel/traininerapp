using System;
using ee.itcollege.krruub.Contracts.DAL.Base;

namespace BLL.App.DTO
{
    public class TrainingInBill  : Training<Guid>, IDomainBaseEntity<Guid>
    {

    }
    
    
    public class TrainingInBill<TKey>
        where TKey : struct, IEquatable<TKey>
    {
        public TKey Id { get; set; }
        public Training Training { get; set; }
        public TKey TrainingId { get; set; }

        public Bill Bill { get; set; }
        public TKey BillId { get; set; }
    }
}