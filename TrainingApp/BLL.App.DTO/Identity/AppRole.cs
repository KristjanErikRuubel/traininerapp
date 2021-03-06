﻿using System;

namespace BLL.App.DTO.Identity
{
    public class AppRole : AppRole<Guid>
    {
    }

    public class AppRole<TKey>
        where TKey : IEquatable<TKey>
    {
        public Guid? Id { get; set; }
    }
}