using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Contracts.DAL.App.Repositories;
using Domain;
using ee.itcollege.krruub.DAL.Base.EF.Mappers;
using ee.itcollege.krruub.DAL.Base.EF.Repositories;
using Microsoft.EntityFrameworkCore;
using TrainingInBill = DAL.App.DTO.TrainingInBill;

namespace DAL.App.EF.Repositories
{
    public class TrainingPlaceRepository : EFBaseRepository<AppDbContext, Domain.TrainingPlace, DAL.App.DTO.TrainingPlace>, ITrainingPlaceRepository 
    {
        public TrainingPlaceRepository(AppDbContext dbContext) : base(dbContext, new BaseDALMapper<TrainingPlace, DTO.TrainingPlace>())
        {
        }
        public async Task<IEnumerable<DTO.TrainingPlace>> AllAsync(Guid? userId = null)
        {
            if (userId == null)
            {
                return (await base.AllAsync());
            }

            return (await RepoDbSet.Where(o => o.Id == userId).ToListAsync()).Select(domainEntity => Mapper.Map(domainEntity));
        }

        public async Task<DTO.TrainingPlace> FirstOrDefaultAsync(Guid id, Guid? userId = null)
        {
            var query = RepoDbSet.Where(a => a.Id == id).AsQueryable();
            if (userId != null)
            {
                query = query.Where(a => a.Id == userId);
            }

            return Mapper.Map(await query.FirstOrDefaultAsync());
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
            var place = await FirstOrDefaultAsync(id, userId);
            base.Remove(place);
        }
    }
}