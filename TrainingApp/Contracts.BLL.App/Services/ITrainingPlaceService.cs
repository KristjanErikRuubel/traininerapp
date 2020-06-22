using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using DAL.App.DTO;
using PublicApi.DTO.v1;

namespace Contracts.BLL.App.Services
{
    public interface ITrainingPlaceService
    {
        public Task<TrainingPlace> GetTrainingPlace(Guid id);

        public Task AddTrainingPlace(TrainingPlaceDTO dto);
        public Task<List<TrainingPlaceDTO>> GetAllTrainingPlaces();

        public Task RemoveTrainingPlace(Guid id);
        
    }
}