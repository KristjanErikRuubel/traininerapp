﻿using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using ee.itcollege.krruub.Contracts.DAL.Base.Repositories;
using DAL.App.DTO;

namespace Contracts.DAL.App.Repositories
{
    public interface ITeamRepository : IBaseRepository<Team>
    {
        Task<ICollection<Team>> AllAsync(Guid? userId = null);
        Task<Team> FirstOrDefaultAsync(Guid? id, Guid? userId = null);

        Task<bool> ExistsAsync(Guid id, Guid? userId = null);
        Task DeleteAsync(Guid id, Guid? userId = null);
        
    }
}