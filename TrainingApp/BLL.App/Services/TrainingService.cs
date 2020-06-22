using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Contracts.BLL.App.Services;
using Contracts.DAL.App;
using Contracts.DAL.App.Repositories;
using Domain;
using ee.itcollege.krruub.BLL.Base.Mappers;
using ee.itcollege.krruub.BLL.Base.Services;
using PublicApi.DTO.v1;
using PublicApi.DTO.v1.Identity;

namespace BLL.App.Services
{
    public class TrainingService: BaseEntityService<ITrainingRepository, IAppUnitOfWork, DAL.App.DTO.Training, BLL.App.DTO.Training>,
        ITrainingService
    {
        private static readonly string CreatedTrainingStatus = "Created";
        private static readonly string ConfirmedTrainingStatus = "Confirmed";
        private INotificationService NotificationService { get;}
        private ICommentService CommentService { get; }

        public TrainingService(INotificationService notificationService, ICommentService commentService, IAppUnitOfWork unitOfWork) 
            : base(unitOfWork, new BaseBLLMapper<DAL.App.DTO.Training, BLL.App.DTO.Training>(), unitOfWork.TrainingRepository)
        {
            NotificationService = notificationService;
            CommentService = commentService;
        }
        
        public async Task AddNewTraining(NewTrainingDTO newTrainingDto)
        {
            var training = new DAL.App.DTO.Training()
            {
                Description = newTrainingDto.Description,
                Duration = newTrainingDto.Duration,
                TrainingPlaceId =  newTrainingDto.TrainingPlaceId,
                Start = DateTime.Parse(newTrainingDto.Start),
                StartTime = TimeSpan.Parse(newTrainingDto.StartTime),
                TrainingStatus = CreatedTrainingStatus,
                CreatorId = newTrainingDto.CreatedBy.Id
            };
            
            var trainingwithId = ServiceRepository.AddNew(training);
            await ServiceUnitOfWork.SaveChangesAsync();
            var users = newTrainingDto.PeopleInvited;
            foreach (var user in users)
            {
                var usrInTraining = new DAL.App.DTO.UserInTraining()
                {
                    AppUserId = user.Id,
                    TrainingId = trainingwithId.Id,
                    AttendingTraining = false
                }; 
                ServiceUnitOfWork.UsersInTrainingRepository.AddNewUserInTraining(usrInTraining);
            }
            await ServiceUnitOfWork.SaveChangesAsync();
            await NotificationService.SendOutNewTrainingNotifications(users, newTrainingDto.NotificationContent,
                trainingwithId);
        
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
            var training = await ServiceRepository.FirstOrDefaultAsync(Id);
            var creator = await ServiceUnitOfWork.AccountRepository.FirstOrDefaultAsync(training.CreatorId);
            var usersInThisTraining = await ServiceUnitOfWork.UsersInTrainingRepository.FindByTrainingId(Id);
            var usersAttending = new List<UserDTO>();
            var usersInvited = new List<UserInTrainingDTO>();
            foreach (var user in usersInThisTraining)
            {
                if (user.AttendingTraining == false)
                {
                    var appUser = await ServiceUnitOfWork.AccountRepository.FirstOrDefaultAsync(user.AppUserId);
                    var notification = await ServiceUnitOfWork.NotificationRepository.FindByTrainingAndUserId(user.AppUserId, training.Id);
                    if (notification.Recived)
                    {
                        var notificationAnswer = await ServiceUnitOfWork.NotificationAnswerRepository.findbyNotificationId(notification.Id);
                        var usrDTO = new UserInTrainingDTO()
                        {
                            Id = appUser.Id,
                            email = appUser.Email,
                            phoneNumber = appUser.PhoneNumber,
                            userName = appUser.FirstName + " " + appUser.LastName,
                            positions = await MapPlayerPositionDtos(appUser),
                            recived = notification.Recived,
                            answer = new NotificationAnswerDTO()
                            {
                                Coming = notificationAnswer.Attending,
                                Content = notificationAnswer.Content
                            }
                        };
                        usersInvited.Add(usrDTO);
                    }
                    else
                    {
                        var userDTO = new UserInTrainingDTO()
                        {
                            Id = appUser.Id,
                            email = appUser.Email,
                            phoneNumber = appUser.PhoneNumber,
                            userName = appUser.FirstName + " " + appUser.LastName,
                            positions = await MapPlayerPositionDtos(appUser),
                            recived = notification.Recived,
                            answer = null
                        };
                        usersInvited.Add(userDTO);
                    }
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
                    usersAttending.Add(usrDTO);
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
                training.TrainingStatus = ConfirmedTrainingStatus;
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
                    Id = creator.Id,
                    userName = creator.FirstName + " " + creator.LastName,
                    email = creator.Email,
                    phoneNumber = creator.PhoneNumber
                },
                Comments = await CommentService.GetTrainingComments(training.Id)
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
        public void RemoveTraining(Guid id)
        {
            ServiceRepository.Remove(id);
            ServiceUnitOfWork.SaveChangesAsync();
        }

    }
}