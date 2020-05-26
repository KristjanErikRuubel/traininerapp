using System;
using ee.itcollege.krruub.Contracts.DAL.Base;

namespace Domain
{
    public class TrainingPlace : TrainingPlace<Guid>, IDomainEntityBaseMetadata
    {
    }

    public class TrainingPlace<TKey> : IDomainEntityBaseMetadata<TKey>
        where TKey : struct, IEquatable<TKey>
    {
        public string Name { get; set; }
        public string Address { get; set; }
        public TimeSpan OpeningTime { get; set; }
        public TimeSpan ClosingTime { get; set; }
        public Guid Id { get; set; }
    }
}