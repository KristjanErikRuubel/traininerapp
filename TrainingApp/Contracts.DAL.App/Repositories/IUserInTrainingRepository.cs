using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using ee.itcollege.krruub.Contracts.DAL.Base.Repositories;
using DAL.App.DTO;

namespace Contracts.DAL.App.Repositories
{
    public interface IUserInTrainingRepository : IBaseRepository<UserInTraining>
    {
        public UserInTraining AddNewUserInTraining(UserInTraining userInTraining);   
        Task<ICollection<UserInTraining>> AllAsync(Guid? userId = null);
        Task<UserInTraining> FirstOrDefaultAsync(Guid id, Guid? userId = null);

        Task<bool> ExistsAsync(Guid id, Guid? userId = null);
        Task DeleteAsync(Guid id, Guid? userId = null);

        public Task<List<UserInTraining>> FindByTrainingId(Guid trainingId);
        public Task<List<UserInTraining>> FindByAppUserId(Guid appUserId);

        public Task<UserInTraining> FindByAppUserIdAndTrainingId(Guid appUserId, Guid trainingId);
        public void UpdateUserInTraining(UserInTraining userInTraining);
    }
}