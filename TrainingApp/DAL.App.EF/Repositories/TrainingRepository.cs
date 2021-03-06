﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Contracts.DAL.App.Repositories;
using DAL.App.EF.Mappers;
using Domain;
using ee.itcollege.krruub.DAL.Base.EF.Mappers;
using ee.itcollege.krruub.DAL.Base.EF.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace DAL.App.EF.Repositories
{
    public class TrainingRepository :  EFBaseRepository<AppDbContext, Domain.Training, DAL.App.DTO.Training>, ITrainingRepository
    {
        public TrainingRepository(AppDbContext dbContext) : base(dbContext, new BaseDALMapper<Training, DTO.Training>())
        {
        }
        public async Task<IEnumerable<DTO.Training>> AllAsync(Guid? userId = null)
        {
            if (userId == null)
            {
                return await base.AllAsync(); // base is not actually needed, using it for clarity
            }

            return (await RepoDbSet.Where(o => o.Id == userId).ToListAsync()).Select(domainEntity => Mapper.Map(domainEntity));
        }

        public async Task<DTO.Training> FirstOrDefaultAsync(Guid? id, Guid? userId = null)
        {
            var query = RepoDbSet.Where(a => a.Id == id).AsQueryable();
            if (userId != null)
            {
                query = query.Where(a => a.Id == userId);
            }

            var training = await query.FirstOrDefaultAsync();
            return TrainingMapper.Map(training);
        }

        public async Task<bool> ExistsAsync(Guid id, Guid? userId = null)
        {
            if (userId == null)
            {
                return await RepoDbSet.AnyAsync(a => a.Id == id);
            }

            return await RepoDbSet.AnyAsync(a => a.Id == id && a.Id == userId);
        }

        public async Task DeleteAsync(Guid id, Guid? userId = null)
        {
            var training = await FirstOrDefaultAsync(id, userId);
            base.Remove(training);
        }


        public DTO.Training AddNew(DTO.Training training)
        {
            
            var domainTraining = new Training()
            {
                TrainingPlaceId = training.TrainingPlaceId,
                TrainingStatus = training.TrainingStatus,
                Description = training.Description,
                Start = training.Start,
                StartTime = training.StartTime,
                CreatorId = training.CreatorId,
                Duration = training.Duration
            };

            var addedTraining = RepoDbSet.Add(domainTraining).Entity;
            return TrainingMapper.Map(addedTraining);
        }
    }
}