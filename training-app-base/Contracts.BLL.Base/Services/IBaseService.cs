using System;
using ee.itcollege.krruub.Contracts.DAL.Base;
using ee.itcollege.krruub.Contracts.DAL.Base.Repositories;

namespace ee.itcollege.krruub.Contracts.BLL.Base.Services
{
    public interface IBaseService
    {
    }
    
    public interface IBaseEntityService<TBLLEntity> :IBaseService, IBaseRepository<TBLLEntity> 
        where TBLLEntity : class, IDomainEntity<Guid>, new()
    {
        
    }
}