using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Contracts.DAL.App.Repositories;
using Domain;
using ee.itcollege.krruub.DAL.Base.EF.Mappers;
using ee.itcollege.krruub.DAL.Base.EF.Repositories;
using Microsoft.EntityFrameworkCore;

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

            return Mapper.Map(await query.FirstOrDefaultAsync());
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
                (await RepoDbSet.AsQueryable().Where(t => t.TrainingId.Equals(trainingId)).ToListAsync())
                .Select(domainEntity => Mapper.Map(domainEntity)).ToList();
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
            return Mapper.Map(await RepoDbSet.AsQueryable()
                .Where(t =>
                    t.AppUserId.Equals(appUserId) && t.TrainingId.Equals(trainingId)).FirstAsync());
        }
    }
}