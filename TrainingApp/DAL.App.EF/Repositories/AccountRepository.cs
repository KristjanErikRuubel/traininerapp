using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Contracts.DAL.App.Repositories;
using DAL.App.EF.Mappers;
using ee.itcollege.krruub.DAL.Base.EF.Mappers;
using ee.itcollege.krruub.DAL.Base.EF.Repositories;
using Microsoft.EntityFrameworkCore;

namespace DAL.App.EF.Repositories
{
    public class AccountRepository : EFBaseRepository<AppDbContext, Domain.Identity.AppUser, DAL.App.DTO.Identity.AppUser>, IAccountRepository
    {
        public AccountRepository(AppDbContext dbContext) : base(dbContext, new BaseDALMapper<Domain.Identity.AppUser, DAL.App.DTO.Identity.AppUser>())
        {
        }
        public async Task<IEnumerable< DAL.App.DTO.Identity.AppUser>> AllAsync(Guid? userId = null)
        {
            if (userId == null)
            {
                return await AllAsync(); // base is not actually needed, using it for clarity
            }
            return (await RepoDbSet.Where(o => o.Id == userId).Include("PlayerPositions").ToListAsync()).Select(AccountMapper.Map);
        }

        public async Task< DAL.App.DTO.Identity.AppUser> FirstOrDefaultAsync(Guid id, Guid? userId = null)
        {
            var query = RepoDbSet.Where(a => a.Id == id).Include("PlayerPositions").AsQueryable();
            if (userId != null)
            {
                query = query.Where(a => a.Id == userId);
            }

            return AccountMapper.Map(await query.FirstOrDefaultAsync());
        }
        

        public async Task DeleteAsync(Guid id, Guid? userId = null)
        {
            var user = await FirstOrDefaultAsync(id, userId);
            base.Remove(user);
        }

        public async Task<IEnumerable<DAL.App.DTO.Identity.AppUser>> GetAllInUsersInTeam(Guid teamId)
        {
            var users =(await RepoDbSet.AsQueryable().Where(a => a.TeamId.Equals(teamId))
                .Include("Team")
                .Include("PlayerPositions")
                .ToListAsync()).Select(AccountMapper.Map).ToList();
            
            return users;
        }
    }
}