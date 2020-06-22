using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using DAL.App.DTO;
using ee.itcollege.krruub.Contracts.DAL.Base.Repositories;

namespace Contracts.DAL.App.Repositories
{
    public interface IFeedBackRepository : IBaseRepository<Feedback>
    {
        Task<IEnumerable<Feedback>> AllAsync(Guid? userId = null);
        Task<Feedback> FirstOrDefaultAsync(Guid id, Guid? userId = null);

        Task<bool> ExistsAsync(Guid id, Guid? userId = null);
        Task DeleteAsync(Guid id, Guid? userId = null);
        Task AddNewFeedback(Feedback feedback);
    }
}