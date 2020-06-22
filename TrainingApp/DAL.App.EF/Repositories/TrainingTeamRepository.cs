using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Contracts.DAL.App.Repositories;
using DAL.App.DTO;
using ee.itcollege.krruub.DAL.Base.EF.Mappers;
using ee.itcollege.krruub.DAL.Base.EF.Repositories;

namespace DAL.App.EF.Repositories
{
    public class TrainingTeamRepository: EFBaseRepository<AppDbContext, Domain.TrainingTeam, DAL.App.DTO.TrainingTeam>, ITrainingTeamRepository
    {
        public TrainingTeamRepository(AppDbContext dbContext) : base(dbContext, new BaseDALMapper<Domain.TrainingTeam, DAL.App.DTO.TrainingTeam>())
        {
        }

        public Task<IEnumerable<TrainingTeam>> AllAsync(Guid? userId = null)
        {
            throw new NotImplementedException();
        }

        public Task<TrainingTeam> FirstOrDefaultAsync(Guid id, Guid? userId = null)
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