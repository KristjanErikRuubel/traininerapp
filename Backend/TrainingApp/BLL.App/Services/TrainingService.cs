using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Contracts.BLL.App.Services;
using Contracts.DAL.App;
using Contracts.DAL.App.Repositories;
using ee.itcollege.krruub.BLL.Base.Mappers;
using ee.itcollege.krruub.BLL.Base.Services;
using PublicApi.DTO.v1;
using PublicApi.DTO.v1.Identity;

namespace BLL.App.Services
{
    public class TrainingService: BaseEntityService<ITrainingRepository, IAppUnitOfWork, DAL.App.DTO.Training, BLL.App.DTO.Training>,
        ITrainingService
    {
        private INotificationService NotificationService { get;}

        public TrainingService(INotificationService notificationService, IAppUnitOfWork unitOfWork) 
            : base(unitOfWork, new BaseBLLMapper<DAL.App.DTO.Training, BLL.App.DTO.Training>(), unitOfWork.TrainingRepository)
        {
            NotificationService = notificationService;
        }
        
        public async Task AddNewTraining(NewTrainingDTO newTrainingDto)
        {
            var training = new DAL.App.DTO.Training()
            {
                Description = newTrainingDto.Description,
                Duration = newTrainingDto.Duration,
                TrainingPlace =  await ServiceUnitOfWork.TrainingPlaceRepository.FindAsync(Guid.Parse(newTrainingDto.TrainingPlaceId)),
                Start = DateTime.Parse(newTrainingDto.Start),
                StartTime = TimeSpan.Parse(newTrainingDto.StartTime),
                TrainingStatus = "Created",
                CreatedBy = ServiceUnitOfWork.AccountRepository.Find(newTrainingDto.createdBy.Id),
                AppUserId = newTrainingDto.createdBy.Id
            };
            ServiceRepository.Add(training);
            await ServiceUnitOfWork.SaveChangesAsync();
            var users = newTrainingDto.PeopleInvited;
            foreach (var user in users)
            {
                var usrInTraining = new DAL.App.DTO.UserInTraining()
                {
                    AppUserId = user.Id,
                    TrainingId = training.Id,
                    AttendingTraining = false
                };
                ServiceUnitOfWork.UsersInTrainingRepository.Add(usrInTraining);
            }

            await NotificationService.SendOutNewTrainingNotifications(users, newTrainingDto.NotificationContent,
                training);
            await ServiceUnitOfWork.SaveChangesAsync();
        }

        public async Task<List<TrainingDTO>> GetUserTrainings(Guid userId)
        {
            var usersInTraining = await ServiceUnitOfWork.UsersInTrainingRepository.FindByAppUserId(userId);
            var result = new List<TrainingDTO>();
            foreach (var usrTraining in usersInTraining)
            {
                result.Add(await MapTrainingData(usrTraining.TrainingId));
            }
            return result;
        }

        public async Task<TrainingDTO> GetTrainingWithDetails(Guid id)
        {
            return await MapTrainingData(id);
        }


        public async Task<TrainingDTO> MapTrainingData(Guid Id)
        {
            var training = await ServiceRepository.FindAsync(Id);
            var creator = await ServiceUnitOfWork.AccountRepository.FindAsync(training.AppUserId);
            var usersInThisTraining = await ServiceUnitOfWork.UsersInTrainingRepository.FindByTrainingId(Id);
            var usersAttending = new List<UserDTO>();
            var usersInvited = new List<UserDTO>();
            foreach (var user in usersInThisTraining)
            {
                if (user.AttendingTraining == false)
                {
                    var appUser = await ServiceUnitOfWork.AccountRepository.FirstOrDefaultAsync(user.AppUserId);
                    var usrDTO = new UserDTO
                    {
                        Id = appUser.Id,
                        email = appUser.Email,
                        phoneNumber = appUser.PhoneNumber,
                        userName = appUser.FirstName + " " + appUser.LastName,
                        positions = await MapPlayerPositionDtos(appUser)
                    };
                    usersInvited.Add(usrDTO);
                }

                if (user.AttendingTraining)
                {
                    var appUser = await ServiceUnitOfWork.AccountRepository.FirstOrDefaultAsync(user.AppUserId);
               
                    var usrDTO = new UserDTO
                    {
                        Id = appUser.Id,
                        email = appUser.Email,
                        phoneNumber = appUser.PhoneNumber,
                        userName = appUser.FirstName + " " + appUser.LastName,
                        positions = await MapPlayerPositionDtos(appUser)
                    };
                    usersInvited.Add(usrDTO);
                }
            }

            var trainingPlace = await ServiceUnitOfWork.TrainingPlaceRepository.FirstOrDefaultAsync(training.TrainingPlaceId);
            var trainingPlaceDto = new TrainingPlaceDTO
            {
                Id = trainingPlace.Id,
                Address = trainingPlace.Address,
                Name = trainingPlace.Name,
                ClosingTime = trainingPlace.ClosingTime,
                OpeningTime = trainingPlace.OpeningTime
            };

            if (usersAttending.Count >= 16)
            {
                training.TrainingStatus = "Confirmed";
            }

            await ServiceUnitOfWork.SaveChangesAsync();
            var trainingDto = new TrainingDTO
            {
                Id = training.Id,
                TrainingPlace = trainingPlaceDto,
                TrainingDate = training.Start,
                Description = training.Description,
                Duration = training.Duration,
                TrainingStatus = training.TrainingStatus,
                PeopleInvited = usersInvited,
                PeopleAttending = usersAttending,
                StartTime = training.StartTime,
                CreatedBy = new UserDTO()
                {
                    userName = creator.FirstName + " " + creator.LastName,
                    // email = creator.Email,
                    // phoneNumber = creator.PhoneNumber
                }
            };
            return trainingDto;
        }

        public async Task<List<PlayerPositionDTO>> MapPlayerPositionDtos(DAL.App.DTO.Identity.AppUser user)
        {
            var databasePositions = await ServiceUnitOfWork.PlayerPostionRepository.GetUserPositions(user.Id);
            var positions = new List<PlayerPositionDTO>();
            foreach (var position in databasePositions)
            {
                var pos = new PlayerPositionDTO()
                {
                    Position = position.PersonPosition
                };
                positions.Add(pos);
            }

            return positions;
        }
    }
}