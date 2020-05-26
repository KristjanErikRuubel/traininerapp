using System;
using ee.itcollege.krruub.Contracts.DAL.Base;

namespace DAL.App.DTO
{
    public class TrainingPlace : TrainingPlace<Guid>, IDomainBaseEntity<Guid>, IDomainEntity<Guid>
    {
    }

    public class TrainingPlace<TKey> 
        where TKey : struct, IEquatable<TKey>
    {
        public TKey Id { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public TimeSpan OpeningTime { get; set; }
        public TimeSpan ClosingTime { get; set; }
    }
}