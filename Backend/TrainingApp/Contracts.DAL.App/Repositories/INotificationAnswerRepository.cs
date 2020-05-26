using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using ee.itcollege.krruub.Contracts.DAL.Base.Repositories;
using DAL.App.DTO;

namespace Contracts.DAL.App.Repositories
{
    public interface INotificationAnswerRepository : IBaseRepository<NotificationAnswer>

    {
        Task<IEnumerable<NotificationAnswer>> AllAsync(Guid? userId = null);
        Task<NotificationAnswer> FirstOrDefaultAsync(Guid id, Guid? userId = null);
        Task DeleteAsync(Guid id, Guid? userId = null);
        
    }
}