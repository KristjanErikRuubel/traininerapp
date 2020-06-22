using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Contracts.DAL.App.Repositories;
using DAL.App.EF.Mappers;
using Domain;
using ee.itcollege.krruub.DAL.Base.EF.Mappers;
using ee.itcollege.krruub.DAL.Base.EF.Repositories;
using Microsoft.EntityFrameworkCore;
using Training = DAL.App.DTO.Training;

namespace DAL.App.EF.Repositories
{
    public class UserInTrainingRepository : EFBaseRepository<AppDbContext, Domain.UserInTraining, DAL.App.DTO.UserInTraining>, IUserInTrainingRepository
    {
        public UserInTrainingRepository(AppDbContext dbContext) : base(dbContext, new BaseDALMapper<UserInTraining, DTO.UserInTraining>())
        {
        }

        public async Task<ICollection<DTO.UserInTraining>> AllAsync(Guid? userId = null)
        {
            var query = RepoDbSet
                .Include(a => a.AppUser)
                .Include(a => a.Training)
                .AsQueryable();

            if (userId != null)
            {
                (query = query.Where(o => o.AppUser!.Id == userId && o.Training!.Id == userId)).Select(domainEntity => Mapper.Map(domainEntity));
            }

            return (await query.ToListAsync()).Select(domainEntity => Mapper.Map(domainEntity)).ToList();
        }

        public async Task<DTO.UserInTraining> FirstOrDefaultAsync(Guid id, Guid? userId = null)
        {
            var query = RepoDbSet
                .Include(a => a.AppUser)
                .Include(a => a.Training)
                .Where(a => a.Id == id)
                .AsQueryable();

            if (userId != null)
            {
                query = query.Where(a => a.AppUser!.Id == userId && a.Training!.Id == userId);
            }

            var userInTraining = await query.FirstOrDefaultAsync();
            var mappedUserInTraining = new DAL.App.DTO.UserInTraining()
            {
                Id = userInTraining.Id,
                AttendingTraining = userInTraining.AttendingTraining,
                TrainingId = userInTraining.TrainingId,
                AppUserId = userInTraining.AppUserId,
                Training = new DAL.App.DTO.Training()
                {
                    Id = userInTraining.Training.Id,
                    TrainingPlaceId = userInTraining.Training.TrainingPlaceId,
                    TrainingStatus = userInTraining.Training.TrainingStatus,
                    Description = userInTraining.Training.Description,
                    Start = userInTraining.Training.Start,
                    StartTime = userInTraining.Training.StartTime,
                    CreatorId = userInTraining.Training.CreatorId,
                    Duration = userInTraining.Training.Duration
                }
            };
            
            return mappedUserInTraining;
        }

        public async Task<bool> ExistsAsync(Guid id, Guid? userId = null)
        {
            if (userId == null)
            {
                return await RepoDbSet.AnyAsync(a => a.Id == id);
            }

            return await RepoDbSet.AnyAsync(a =>
                a.Id == id && a.AppUser!.Id == userId && a.AppUser!.Id == userId);
        }

        public async Task DeleteAsync(Guid id, Guid? userId = null)
        {
            var personInTraining = await FirstOrDefaultAsync(id, userId);
            base.Remove(personInTraining);
        }

        public async Task<List<DTO.UserInTraining>> FindByTrainingId(Guid trainingId)
        {
            return
                (await RepoDbSet.AsQueryable().Where(t => t.TrainingId.Equals(trainingId)).Include("Training").ToListAsync())
                .Select(UserInTrainingMapper.Map).ToList();
        }
        public async Task<List<DTO.UserInTraining>> FindByAppUserId(Guid appUserId)
        {
            return (await RepoDbSet.AsQueryable()
                    .Where(t =>t.AppUserId.Equals(appUserId))
                    .ToListAsync())
                .Select(domainEntity => Mapper.Map(domainEntity)).ToList();
        }
        
        public async Task<DTO.UserInTraining> FindByAppUserIdAndTrainingId(Guid appUserId, Guid trainingId)
        {
            return UserInTrainingMapper.Map(await RepoDbSet.AsQueryable()
                .Where(t =>
                    t.AppUserId.Equals(appUserId) && t.TrainingId.Equals(trainingId)).FirstAsync());
        }

        public DTO.UserInTraining AddNewUserInTraining(DTO.UserInTraining userInTraining)
        {

            var domainUserInTraining = new UserInTraining()
            {
                AppUserId = userInTraining.AppUserId,
                AttendingTraining = userInTraining.AttendingTraining,
                TrainingId = userInTraining.TrainingId
            };

            var addedUserInTraining = RepoDbSet.Add(domainUserInTraining);
            return UserInTrainingMapper.Map(addedUserInTraining.Entity);
        }

        public async void UpdateUserInTraining(DAL.App.DTO.UserInTraining userInTraining)
        {
            var usr = await RepoDbSet.FindAsync(userInTraining.Id);
            usr.AttendingTraining = userInTraining.AttendingTraining;
            RepoDbSet.Update(usr);
        }
    }
}