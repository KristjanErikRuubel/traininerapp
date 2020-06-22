using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ee.itcollege.krruub.Contracts.BLL.Base.Mappers;
using ee.itcollege.krruub.Contracts.BLL.Base.Services;
using ee.itcollege.krruub.Contracts.DAL.Base;
using ee.itcollege.krruub.Contracts.DAL.Base.Repositories;

namespace ee.itcollege.krruub.BLL.Base.Services
{
        public class BaseEntityService<TServiceRepository, TUnitOfWork, TDALEntity, TBLLEntity> : BaseService,
        IBaseEntityService<TBLLEntity>
        where TBLLEntity : class, IDomainEntity<Guid>, new()
        where TDALEntity : class, IDomainEntity<Guid>, new()
        where TUnitOfWork : IBaseUnitOfWork
        where TServiceRepository : IBaseRepository<TDALEntity>
    {
        protected TUnitOfWork ServiceUnitOfWork;
        protected IBaseBLLMapper<TDALEntity, TBLLEntity> _mapper;
        protected TServiceRepository ServiceRepository;

        public BaseEntityService(TUnitOfWork unitOfWork, IBaseBLLMapper<TDALEntity, TBLLEntity> mapper,
            TServiceRepository serviceRepository)
        {
            ServiceUnitOfWork = unitOfWork;
            ServiceRepository = serviceRepository;
            _mapper = mapper;
        }


        public virtual IEnumerable<TBLLEntity> All() =>
            ServiceRepository.All().Select(entity => _mapper.Map<TDALEntity, TBLLEntity>(entity));

        public virtual async Task<IEnumerable<TBLLEntity>> AllAsync() =>
            (await ServiceRepository.AllAsync()).Select(entity => _mapper.Map<TDALEntity, TBLLEntity>(entity));

        public virtual TBLLEntity Find(params object[] id) =>
            _mapper.Map<TDALEntity, TBLLEntity>(ServiceRepository.Find(id));

        public virtual async Task<TBLLEntity> FindAsync(params object[] id) =>
            _mapper.Map<TDALEntity, TBLLEntity>(await ServiceRepository.FindAsync(id));

        public virtual TBLLEntity Add(TBLLEntity entity) =>
            _mapper.Map<TDALEntity, TBLLEntity>(ServiceRepository.Add(_mapper.Map<TBLLEntity, TDALEntity>(entity)));

        public virtual TBLLEntity Update(TBLLEntity entity) =>
            _mapper.Map<TDALEntity, TBLLEntity>(ServiceRepository.Update(_mapper.Map<TBLLEntity, TDALEntity>(entity)));


        public virtual TBLLEntity Remove(TBLLEntity entity) =>
            _mapper.Map<TDALEntity, TBLLEntity>(ServiceRepository.Remove(_mapper.Map<TBLLEntity, TDALEntity>(entity)));


        public virtual TBLLEntity Remove(params object[] id) =>
            _mapper.Map<TDALEntity, TBLLEntity>(ServiceRepository.Remove(id));
    }
}