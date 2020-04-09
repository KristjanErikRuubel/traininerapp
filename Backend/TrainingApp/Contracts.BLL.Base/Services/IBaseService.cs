using System;
using Contracts.DAL.Base;
using Contracts.DAL.Base.Repositories;

namespace Contracts.BLL.App.Services
{
    public interface IBaseService
    {
    }
    
    public interface IBaseEntityService<TBLLEntity> :IBaseService, IBaseRepository<TBLLEntity> 
        where TBLLEntity : class, IDomainEntity<Guid>, new()
    {
        
    }
}