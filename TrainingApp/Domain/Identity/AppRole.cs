﻿using System;
using Microsoft.AspNetCore.Identity;

namespace Domain.Identity
{
    public class AppRole : IdentityRole<Guid>
    {
    }

    public class AppRole<TKey> : IdentityRole<TKey>, BaseEntity<TKey>
        where TKey : IEquatable<TKey>
    {
        public string? CreatedBy { get; set; }
        public DateTime CreatedAt { get; set; }
        public string? ChangedBy { get; set; }
        public DateTime ChangedAt { get; set; }
    }
}
