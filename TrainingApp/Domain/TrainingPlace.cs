using System;
using ee.itcollege.krruub.Contracts.DAL.Base;

namespace Domain
{
    public class TrainingPlace : TrainingPlace<Guid>, IDomainEntityBaseMetadata
    {
    }

    public class TrainingPlace<TKey> : IDomainEntityBaseMetadata<TKey>, BaseEntity<TKey>
        where TKey : struct, IEquatable<TKey>
    {
        public string? Name { get; set; }
        public string? Address { get; set; }
        public TimeSpan OpeningTime { get; set; }
        public TimeSpan ClosingTime { get; set; }
        public Guid Id { get; set; }
        public string? CreatedBy { get; set; }
        public DateTime CreatedAt { get; set; }
        public string? ChangedBy { get; set; }
        public DateTime ChangedAt { get; set; }
    }
}