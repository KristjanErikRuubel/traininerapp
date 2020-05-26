using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using DAL.App.DTO;

namespace Contracts.BLL.App.Services
{
    public interface IPlayerPositionService
    {
        public Task AddPosition(string position, Guid userId);

        public Task<List<PlayerPosition>> GetPlayerPositions(Guid userId);
    }
    
}