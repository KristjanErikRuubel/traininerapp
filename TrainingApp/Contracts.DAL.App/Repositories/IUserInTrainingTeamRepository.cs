
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using DAL.App.DTO;
using ee.itcollege.krruub.Contracts.DAL.Base.Repositories;

namespace Contracts.DAL.App.Repositories
{
    public interface IUserInTrainingTeamRepository: IBaseRepository<UserInTrainingTeam>
    {
        Task<IEnumerable<UserInTrainingTeam>> AllAsync(Guid? userId = null);
        Task<UserInTrainingTeam> FirstOrDefaultAsync(Guid id, Guid? userId = null);

        Task<bool> ExistsAsync(Guid id, Guid? userId = null);
        Task DeleteAsync(Guid id, Guid? userId = null);
    }
}