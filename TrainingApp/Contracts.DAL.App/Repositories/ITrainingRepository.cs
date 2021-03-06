﻿using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using ee.itcollege.krruub.Contracts.DAL.Base.Repositories;
using DAL.App.DTO;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace Contracts.DAL.App.Repositories
{
    public interface ITrainingRepository : IBaseRepository<Training>
    {
        Task<IEnumerable<Training>> AllAsync(Guid? userId = null);
        Task<Training> FirstOrDefaultAsync(Guid? id, Guid? userId = null);

        Task<bool> ExistsAsync(Guid id, Guid? userId = null);
        Task DeleteAsync(Guid id, Guid? userId = null);
        public Training AddNew(Training training);
    }
}