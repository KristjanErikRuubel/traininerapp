using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Contracts.BLL.App.Services;
using Contracts.DAL.App;
using Contracts.DAL.App.Repositories;
using ee.itcollege.krruub.BLL.Base.Mappers;
using ee.itcollege.krruub.BLL.Base.Services;

namespace BLL.App.Services
{
    public class PlayerPositionService : BaseEntityService<IPlayerPositionRepository, IAppUnitOfWork, DAL.App.DTO.PlayerPosition, BLL.App.DTO.PlayerPosition>, IPlayerPositionService
    {
        public PlayerPositionService(IAppUnitOfWork unitOfWork)
            : base(unitOfWork, new IdentityMapper<DAL.App.DTO.PlayerPosition, BLL.App.DTO.PlayerPosition>(), unitOfWork.PlayerPostionRepository)
        {
        }

        public async Task AddPosition(string position, Guid userId)
        {
            var playerPostion = new DAL.App.DTO.PlayerPosition()
            {
                AppUserId = userId,
                PersonPosition = position
            };
            ServiceRepository.Add(playerPostion);
            await ServiceUnitOfWork.SaveChangesAsync();
        }

        public async Task<List<DAL.App.DTO.PlayerPosition>> GetPlayerPositions(Guid userId)
        {
           return await ServiceRepository.GetUserPositions(userId);
        }
        public void RemovePlayerPosition(Guid id)
        {
            ServiceRepository.Remove(id);
        }
        
    }
}