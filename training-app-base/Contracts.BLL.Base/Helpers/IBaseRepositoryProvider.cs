using ee.itcollege.krruub.Contracts.DAL.Base;
using ee.itcollege.krruub.Contracts.DAL.Base.Repositories;

namespace ee.itcollege.krruub.Contracts.BLL.Base.Helpers
{
    public interface IBaseRepositoryProvider
    {
        TRepository GetRepository<TRepository>();

        IBaseRepository<TDomainEntity> GetEntityRepository< TDomainEntity>()
            where TDomainEntity : class, IDomainEntity, new();
    }
}