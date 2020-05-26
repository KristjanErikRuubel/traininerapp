using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using PublicApi.DTO.v1;

namespace Contracts.BLL.App.Services
{
    public interface ITrainingService
    {
        public Task AddNewTraining(NewTrainingDTO newTrainingDto);
        public Task<List<TrainingDTO>> GetUserTrainings(Guid userId);
        public Task<TrainingDTO> GetTrainingWithDetails(Guid id);
    }
}