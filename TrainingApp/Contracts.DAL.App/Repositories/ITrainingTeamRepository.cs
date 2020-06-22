
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using DAL.App.DTO;
using ee.itcollege.krruub.Contracts.DAL.Base.Repositories;

namespace Contracts.DAL.App.Repositories
{
    public interface ITrainingTeamRepository: IBaseRepository<TrainingTeam>
    {
        Task<IEnumerable<TrainingTeam>> AllAsync(Guid? userId = null);
        Task<TrainingTeam> FirstOrDefaultAsync(Guid id, Guid? userId = null);

        Task<bool> ExistsAsync(Guid id, Guid? userId = null);
        Task DeleteAsync(Guid id, Guid? userId = null);
    }
}