using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Contracts.DAL.Base.Repositories;
using Domain;

namespace Contracts.DAL.App.Repositories
{
    public interface IPersonInTrainingRepository : IBaseRepository<UserInTraining>
    {
        
        Task<IEnumerable<UserInTraining>> AllAsync(Guid? userId = null);
        Task<UserInTraining> FirstOrDefaultAsync(Guid id, Guid? userId = null);

        Task<bool> ExistsAsync(Guid id, Guid? userId = null);
        Task DeleteAsync(Guid id, Guid? userId = null);
        
    }
}