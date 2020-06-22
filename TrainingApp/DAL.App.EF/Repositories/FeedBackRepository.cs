using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Contracts.DAL.App.Repositories;
using DAL.App.DTO;
using ee.itcollege.krruub.DAL.Base.EF.Mappers;
using ee.itcollege.krruub.DAL.Base.EF.Repositories;
using Microsoft.EntityFrameworkCore;

namespace DAL.App.EF.Repositories
{
    public class FeedBackRepository: EFBaseRepository<AppDbContext, Domain.Feedback, DAL.App.DTO.Feedback>, IFeedBackRepository
    {
        public FeedBackRepository(AppDbContext dbContext) : base(dbContext, new BaseDALMapper<Domain.Feedback, DTO.Feedback>())
        {
        }
        public async Task<IEnumerable<DTO.Feedback>> AllAsync(Guid? userId = null)
        {
            if (userId == null)
            {
                return (await base.AllAsync());
            }

            return (await RepoDbSet.Where(o => o.Id == userId).ToListAsync()).Select(domainEntity => Mapper.Map(domainEntity));
        }

        public async Task<DTO.Feedback> FirstOrDefaultAsync(Guid id, Guid? userId = null)
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

        public async Task AddNewFeedback(DTO.Feedback feedback)
        {
            var domain = new Domain.Feedback
            {
                AppUserId = feedback.AppUserId,
                Content = feedback.Content,
                Rating = feedback.Rating
            };
            await RepoDbSet.AddAsync(domain);
        }
    }
}