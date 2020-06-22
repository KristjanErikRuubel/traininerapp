using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Contracts.DAL.App.Repositories;
using ee.itcollege.krruub.DAL.Base.EF.Mappers;
using ee.itcollege.krruub.DAL.Base.EF.Repositories;
using UserInTrainingTeam = DAL.App.DTO.UserInTrainingTeam;

namespace DAL.App.EF.Repositories
{
    public class UserInTrainingTeamRepository :
        EFBaseRepository<AppDbContext, Domain.UserInTrainingTeam, DAL.App.DTO.UserInTrainingTeam>,
        IUserInTrainingTeamRepository
    {
        public UserInTrainingTeamRepository(AppDbContext dbContext) : base(dbContext,
            new BaseDALMapper<Domain.UserInTrainingTeam, DAL.App.DTO.UserInTrainingTeam>())
        {
        }

        public Task<IEnumerable<UserInTrainingTeam>> AllAsync(Guid? userId = null)
        {
            throw new NotImplementedException();
        }

        public Task<UserInTrainingTeam> FirstOrDefaultAsync(Guid id, Guid? userId = null)
        {
            throw new NotImplementedException();
        }

        public Task<bool> ExistsAsync(Guid id, Guid? userId = null)
        {
            throw new NotImplementedException();
        }

        public Task DeleteAsync(Guid id, Guid? userId = null)
        {
            throw new NotImplementedException();
        }
    }
}