using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Contracts.BLL.App.Services;
using Contracts.DAL.App;
using Contracts.DAL.App.Repositories;
using ee.itcollege.krruub.BLL.Base.Mappers;
using ee.itcollege.krruub.BLL.Base.Services;
using PublicApi.DTO.v1;

namespace BLL.App.Services
{
    public class TrainingPlaceService :
        BaseEntityService<ITrainingPlaceRepository, IAppUnitOfWork, DAL.App.DTO.TrainingPlace, BLL.App.DTO.TrainingPlace>, ITrainingPlaceService
    {
        public TrainingPlaceService(IAppUnitOfWork unitOfWork)
            : base(unitOfWork, new IdentityMapper< DAL.App.DTO.TrainingPlace, BLL.App.DTO.TrainingPlace>(), unitOfWork.TrainingPlaceRepository)
        {
        }

        public async Task<DAL.App.DTO.TrainingPlace> GetTrainingPlace(Guid id)
        {
            return await ServiceRepository.FirstOrDefaultAsync(id);
        }

        public async Task<List<TrainingPlaceDTO>> GetAllTrainingPlaces()
        {   
            
            var trainingPlaces = await ServiceRepository.AllAsync();
            var mappedData = new List<TrainingPlaceDTO>(); 
            foreach (var place in trainingPlaces)
            {
                var trainingPlaceDto = new TrainingPlaceDTO()
                {
                    Id = place.Id,
                    Name = place.Name,
                    Address = place.Address,
                    OpeningTime = place.OpeningTime,
                    ClosingTime = place.ClosingTime
                };
                mappedData.Add(trainingPlaceDto);
            }
            return mappedData;
        }

        public async Task AddTrainingPlace(TrainingPlaceDTO dto)
        {
            var trainingPlace = new DAL.App.DTO.TrainingPlace()
            {
                Name = dto.Name,
                Address = dto.Address,
                OpeningTime = dto.OpeningTime,
                ClosingTime = dto.ClosingTime
            };
            ServiceRepository.Add(trainingPlace);
            await ServiceUnitOfWork.SaveChangesAsync();
        }
    }
}