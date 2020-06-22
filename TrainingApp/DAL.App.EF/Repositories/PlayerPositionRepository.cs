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
    public class PlayerPositionRepository  : EFBaseRepository<AppDbContext, Domain.PlayerPosition, DAL.App.DTO.PlayerPosition>, IPlayerPositionRepository
    {
        public PlayerPositionRepository(AppDbContext dbContext) :
            base(dbContext, new BaseDALMapper<PlayerPosition, DTO.PlayerPosition>())
        {

        }

        public async Task<ICollection<DTO.PlayerPosition>> AllAsync(Guid? Id = null)
        {            
            if (Id == null)
            {
                return (await base.AllAsync()).ToList(); // base is not actually needed, using it for clarity
            }

            return (await RepoDbSet.Where(o => o.Id == Id).ToListAsync()).Select(domainEntity => Mapper.Map(domainEntity)).ToList();
           
        }

        public async Task<DTO.PlayerPosition> FirstOrDefaultAsync(Guid id, Guid? userId = null)
        {
            var query = RepoDbSet.Where(a => a.Id == id).AsQueryable();
            if (userId != null)
            {
                query = query.Where(a => a.Id == userId);
            }
        
            return Mapper.Map(await query.FirstOrDefaultAsync());
        }

        public Task<bool> ExistsAsync(Guid id, Guid? userId = null)
        {
            throw new NotImplementedException();
        }

        public Task DeleteAsync(Guid id, Guid? userId = null)
        {
            throw new NotImplementedException();
        }

        public async Task<List<DTO.PlayerPosition>> GetUserPositions(Guid userId)
        {
            return
                (await RepoDbSet.AsQueryable().Where(pos => pos.AppUserId.Equals(userId))
                    .ToListAsync()).Select(domainEntity => Mapper.Map(domainEntity)).ToList();
        }
    }
}