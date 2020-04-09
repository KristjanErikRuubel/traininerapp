using System;
using Contracts.DAL.Base;
using Microsoft.EntityFrameworkCore;

namespace Contracts.BLL.Base.Helpers
{
    public interface IBaseRepositoryFactory<TDbContext>
        where TDbContext: DbContext
    {
        void AddToCreationMethods<TRepository>(Func<TDbContext, TRepository> creationMethod)
            where TRepository : class;
        
        Func<TDbContext, object> GetRepositoryFactory<TRepository>();

        Func<TDbContext, object> GetEntityRepositoryFactory<TDALEntity, TDomainEntity>()
            where TDALEntity : class, new()
            where TDomainEntity : class, IDomainEntity, new();



    }
}