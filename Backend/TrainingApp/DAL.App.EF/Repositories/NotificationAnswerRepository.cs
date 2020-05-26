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
    public class NotificationAnswerRepository : EFBaseRepository<AppDbContext, Domain.NotificationAnswer, DAL.App.DTO.NotificationAnswer>, INotificationAnswerRepository
    {
        public NotificationAnswerRepository(AppDbContext dbContext) : base(dbContext, new BaseDALMapper<NotificationAnswer, DTO.NotificationAnswer>())
        {
        }

        public async Task<IEnumerable<DTO.NotificationAnswer>> AllAsync(Guid? Id = null)
        {
            return await base.AllAsync(); // base is not actually needed, using it for clarity
        }

        public async Task<DTO.NotificationAnswer> FirstOrDefaultAsync(Guid id, Guid? Id = null)
        {
            var query = RepoDbSet.Where(a => a.Id == id).AsQueryable();
            return Mapper.Map(await query.FirstOrDefaultAsync());
        }
        

        public async Task DeleteAsync(Guid id, Guid? userId = null)
        {
            var notificationAnswer = await FirstOrDefaultAsync(id, userId);
            base.Remove(notificationAnswer);
        }

    }
}