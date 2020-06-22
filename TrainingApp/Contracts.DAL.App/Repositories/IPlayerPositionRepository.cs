using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using ee.itcollege.krruub.Contracts.DAL.Base.Repositories;
using DAL.App.DTO;

namespace Contracts.DAL.App.Repositories
{
    public interface IPlayerPositionRepository : IBaseRepository<PlayerPosition>
    {
        Task<ICollection<PlayerPosition>> AllAsync(Guid? userId = null);
        Task<PlayerPosition> FirstOrDefaultAsync(Guid id, Guid? userId = null);

        Task<bool> ExistsAsync(Guid id, Guid? userId = null);
        Task DeleteAsync(Guid id, Guid? userId = null);

        Task<List<PlayerPosition>> GetUserPositions(Guid userId);

    }
}