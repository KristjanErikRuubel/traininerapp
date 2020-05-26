using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Contracts.DAL.App.Repositories;
using Domain;
using ee.itcollege.krruub.DAL.Base.EF.Mappers;
using ee.itcollege.krruub.DAL.Base.EF.Repositories;
using Microsoft.EntityFrameworkCore;

namespace DAL.App.EF.Repositories
{
    public class NotificationRepository : EFBaseRepository<AppDbContext, Domain.Notification, DAL.App.DTO.Notification>, INotificationRepository
    {
        public NotificationRepository(AppDbContext dbContext) : base(dbContext, new BaseDALMapper<Notification, DTO.Notification>())
        {
        }

        public async Task<IEnumerable<DTO.Notification>> AllAsync(Guid? userId = null)
        {
            if (userId == null)
            {
                return await base.AllAsync();
            }
            return (await RepoDbSet.Where(o => o.AppUserId == userId).ToListAsync()).Select(domainNotification => Mapper.Map(domainNotification));
        }

        public async Task<DTO.Notification> FirstOrDefaultAsync(Guid id, Guid? userId = null)
        {
            var query = RepoDbSet.Where(a => a.Id == id).AsQueryable();
            if (userId != null)
            {
                query = query.Where(a => a.AppUserId == userId);
            }

            return Mapper.Map(await query.FirstOrDefaultAsync());
        }

        public async Task<bool> ExistsAsync(Guid id, Guid? userId = null)
        {
            if (userId == null)
            {
                return await RepoDbSet.AnyAsync(a => a.Id == id);
            }

            return await RepoDbSet.AnyAsync(a => a.Id == id && a.AppUserId == userId);
        }

        public async Task DeleteAsync(Guid id, Guid? userId = null)
        {
            var notification = await FirstOrDefaultAsync(id, userId);
            base.Remove(notification);
        }

        public async Task<IEnumerable<DTO.Notification>> GetNewNotifications(Guid userId)
        {
            return (await RepoDbSet.AsQueryable().Where(n => n.AppUserId.Equals(userId) && n.Recived == false)
                .ToListAsync()).Select(domainEntity => Mapper.Map(domainEntity));
        }

        public async Task<IEnumerable<DTO.Notification>> GetAllNotifications(Guid userId)
        {
            return (await RepoDbSet.AsQueryable().Where(n => n.AppUserId.Equals(userId))
                .ToListAsync()).Select(domainEntity => Mapper.Map(domainEntity));
        }
        
    }
}