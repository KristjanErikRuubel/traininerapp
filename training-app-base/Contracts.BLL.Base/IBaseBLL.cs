using System;
using System.Threading.Tasks;

namespace ee.itcollege.krruub.Contracts.BLL.Base
{
    public interface IBaseBLL
    {
        /*
        IBaseEntityService<TEntity> BaseEntityService<TEntity>() 
            where TEntity : class, IDomainEntity, new();
        */
        Task<int> SaveChangesAsync();
        int SaveChanges();
        
        TService GetService<TService>(Func<TService> serviceCreationMethod);
    }
}