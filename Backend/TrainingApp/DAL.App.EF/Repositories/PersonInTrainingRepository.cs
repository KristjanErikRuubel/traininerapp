using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Contracts.DAL.App.Repositories;
using DAL.Base.EF.Repositories;
using Domain;
using Microsoft.EntityFrameworkCore;

namespace DAL.App.EF.Repositories
{
    public class PersonInTrainingRepository : EFBaseRepository<UserInTraining, AppDbContext>, IPersonInTrainingRepository
    {
        public PersonInTrainingRepository(AppDbContext dbContext) : base(dbContext)
        {
        }

        public async Task<IEnumerable<UserInTraining>> AllAsync(Guid? userId = null)
        {
            var query = RepoDbSet
                .Include(a => a.User)
                .Include(a => a.Training)
                .AsQueryable();

            if (userId != null)
            {
                query = query.Where(o => o.User!.Id == userId && o.Training!.Id == userId);
            }

            return await query.ToListAsync();
        }

        public async Task<UserInTraining> FirstOrDefaultAsync(Guid id, Guid? userId = null)
        {
            var query = RepoDbSet
                .Include(a => a.User)
                .Include(a => a.Training)
                .Where(a => a.Id == id)
                .AsQueryable();

            if (userId != null)
            {
                query = query.Where(a => a.User!.Id == userId && a.Training!.Id == userId);
            }

            return await query.FirstOrDefaultAsync();
        }

        public async Task<bool> ExistsAsync(Guid id, Guid? userId = null)
        {
            if (userId == null)
            {
                return await RepoDbSet.AnyAsync(a => a.Id == id);
            }

            return await RepoDbSet.AnyAsync(a =>
                a.Id == id && a.User!.Id == userId && a.User!.Id == userId);
        }

        public async Task DeleteAsync(Guid id, Guid? userId = null)
        {
            var personInTraining = await FirstOrDefaultAsync(id, userId);
            base.Remove(personInTraining);
        }

        // public async Task<IEnumerable<OwnerAnimalDTO>> DTOAllAsync(Guid? userId = null)
        // {
        //     var query = RepoDbSet
        //         .Include(o => o.Owner)
        //         .Include(o => o.Animal)
        //         .AsQueryable();
        //     if (userId != null)
        //     {
        //         query = query.Where(o => o.Animal!.AppUserId == userId && o.Owner!.AppUserId == userId);
        //     }
        //
        //     return await query
        //         .Select(o => new OwnerAnimalDTO()
        //         {
        //             Id = o.Id,
        //             AnimalId = o.AnimalId,
        //             OwnerId = o.OwnerId,
        //             OwnedPercentage = o.OwnedPercentage,
        //             Animal = new AnimalDTO()
        //             {
        //                 Id = o.Animal!.Id,
        //                 AnimalName = o.Animal!.AnimalName,
        //                 BirthYear = o.Animal!.BirthYear,
        //                 OwnerCount = o.Animal!.Owners!.Count,
        //             },
        //             Owner = new OwnerDTO()
        //             {
        //                 Id = o.Owner!.Id,
        //                 FirstName = o.Owner!.FirstName,
        //                 LastName = o.Owner!.LastName,
        //                 AnimalCount = o.Owner!.Animals!.Count
        //             }
        //         })
        //         .ToListAsync();
        // }
        //
        // public Task<OwnerAnimalDTO> DTOFirstOrDefaultAsync(Guid id, Guid? userId = null)
        // {
        //     throw new NotImplementedException();
        // }
    }
}