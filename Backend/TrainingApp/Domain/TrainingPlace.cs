using System;
using Contracts.DAL.Base;
using DAL.Base;

namespace Domain
{
    public class TrainingPlace : TrainingPlace<Guid>, IDomainEntity
    {
    }

    public class TrainingPlace<TKey> : DomainEntity<TKey>
        where TKey : struct, IEquatable<TKey>
    {
        public string Name { get; set; }
        public string Address { get; set; }
        public TimeSpan OpeningTime { get; set; }
        public TimeSpan ClosingTime { get; set; }
    }
}