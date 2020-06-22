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

namespace DAL.App.EF.Repositories
{
    public class TeamRepository : EFBaseRepository<AppDbContext, Domain.Team, DAL.App.DTO.Team>, ITeamRepository
    {
        public TeamRepository(AppDbContext dbContext) : base(dbContext, new BaseDALMapper<Team, DTO.Team>())
        {
        }

        public async Task<ICollection<DTO.Team>> AllAsync(Guid? userId = null)
        {
            if (userId == null)
            {
                return (await base.AllAsync()).ToList();; // base is not actually needed, using it for clarity
            }
            return (await RepoDbSet.Where(o => o.Id == userId).ToListAsync()).Select(domainEntity => Mapper.Map(domainEntity)).ToList();
        }
        
        public async Task<DTO.Team> FirstOrDefaultAsync(Guid? id, Guid? userId = null)
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
            var team = await FirstOrDefaultAsync(id, userId);
            base.Remove(team);
        }

   
    }
}