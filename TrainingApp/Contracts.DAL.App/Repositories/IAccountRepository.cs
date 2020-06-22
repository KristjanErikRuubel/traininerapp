using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using DAL.App.DTO.Identity;
using ee.itcollege.krruub.Contracts.DAL.Base.Repositories;


namespace Contracts.DAL.App.Repositories
{
    public interface IAccountRepository  : IBaseRepository<AppUser>
    {
        Task<IEnumerable<AppUser>> AllAsync(Guid? userId = null);
        Task<AppUser> FirstOrDefaultAsync(Guid id, Guid? userId = null);
        Task DeleteAsync(Guid id, Guid? userId = null);

        Task<IEnumerable<AppUser>> GetAllInUsersInTeam(Guid teamId);

    }
}