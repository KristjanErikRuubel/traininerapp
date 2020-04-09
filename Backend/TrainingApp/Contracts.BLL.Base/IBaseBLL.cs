using System.Threading.Tasks;

namespace Contracts.BLL.App
{
    public interface IBaseBLL
    {
        /*
        IBaseEntityService<TEntity> BaseEntityService<TEntity>() 
            where TEntity : class, IDomainEntity, new();
        */
        
        Task<int> SaveChangesAsync();
        int SaveChanges();
    }
}