using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using DAL.App.DTO;
using ee.itcollege.krruub.Contracts.DAL.Base.Repositories;


namespace Contracts.DAL.App.Repositories
{
    public interface INotificationRepository : IBaseRepository<Notification>
    {
        Task<IEnumerable<Notification>> AllAsync(Guid? userId = null);
        Task<Notification> FirstOrDefaultAsync(Guid id, Guid? userId = null);

        Task<bool> ExistsAsync(Guid id, Guid? userId = null);
        Task DeleteAsync(Guid id, Guid? userId = null);

        Task<IEnumerable<Notification>> GetNewNotifications(Guid userId);

        Task<IEnumerable<Notification>> GetAllNotifications(Guid userId);
        Notification AddNewNotification(Notification notification);
        public Task<Notification> UpdateNotification(Notification notification);
        public Task<Notification> FindByTrainingAndUserId(Guid userId, Guid trainingId);
    }
}