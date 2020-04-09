using Contracts.DAL.Base;
using Contracts.DAL.Base.Repositories;

namespace Contracts.BLL.Base.Helpers
{
    public interface IBaseRepositoryProvider
    {
        TRepository GetRepository<TRepository>();

        IBaseRepository<TDomainEntity> GetEntityRepository< TDomainEntity>()
            where TDomainEntity : class, IDomainEntity, new();
    }
}