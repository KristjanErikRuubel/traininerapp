using System;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;
using ee.itcollege.krruub.Contracts.DAL.Base;

namespace Domain
{
    public interface BaseEntity<TKey> : IDomainEntityMetadata
        where TKey : IEquatable<TKey>
    {
        [MaxLength(256)] [JsonIgnore] public string? CreatedBy { get; set; }
        [JsonIgnore] [DataType(DataType.Date)] public DateTime CreatedAt { get; set; }

        [MaxLength(256)] [JsonIgnore] public string? ChangedBy { get; set; }
        [JsonIgnore] [DataType(DataType.Time)] public DateTime ChangedAt { get; set; }
    }
}