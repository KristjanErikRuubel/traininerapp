using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using DAL.App.DTO;
using ee.itcollege.krruub.Contracts.DAL.Base.Repositories;

namespace Contracts.DAL.App.Repositories
{
    public interface IBillRepository : IBaseRepository<Bill>
    {
        Task<IEnumerable<Bill>> AllAsync(Guid? userId = null);
        Task<Bill> FirstOrDefaultAsync(Guid id, Guid? userId = null);

        Task<bool> ExistsAsync(Guid id, Guid? userId = null);
        Task DeleteAsync(Guid id, Guid? userId = null);

        Task<IEnumerable<Bill>> GetUserBills(Guid userId);

    }
}
