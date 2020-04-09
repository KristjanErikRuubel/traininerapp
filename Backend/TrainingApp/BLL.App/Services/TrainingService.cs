using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Contracts.BLL.App.Services;
using DAL.App.EF;
using Domain;
using Domain.Identity;
using Microsoft.EntityFrameworkCore;
using PublicApi.DTO.v1;
using PublicApi.DTO.v1.Identity;

namespace BLL.App.Services
{
    public class TrainingService : ITrainingService
    {
        private AppDbContext Ctx { get; set; }
        private INotificationService NotificationService { get; set; }
        private ITeamService TeamService { get; set; }

        public TrainingService(AppDbContext context, INotificationService notificationService, ITeamService teamService)
        {
            TeamService = teamService;
            NotificationService = notificationService;
            Ctx = context;
        }

        /**
         * Add new training
         */
        public async Task AddNewTraining(NewTrainingDTO newTrainingDto)
        {
            var training = new Training()
            {
                Description = newTrainingDto.Description,
                Duration = newTrainingDto.Duration,
                TrainingPlace = await Ctx.TrainingPlaces.FindAsync(Guid.Parse(newTrainingDto.TrainingPlaceId)),
                Start = DateTime.Parse(newTrainingDto.Start),
                StartTime = TimeSpan.Parse(newTrainingDto.StartTime),
                TrainingStatus = "Created"
            };
            await Ctx.Trainings.AddAsync(training);
            await Ctx.SaveChangesAsync();
            var users = newTrainingDto.PeopleInvited;
            foreach (var user in users)
            {
                var usrInTraining = new UserInTraining()
                {
                    AppUserId = user.Id,
                    TrainingId = training.Id,
                    AttendingTraining = false
                };
                await Ctx.UsersInTrainings.AddAsync(usrInTraining);
            }

            await NotificationService.SendOutNewTrainingNotifications(users, newTrainingDto.NotificationContent,
                training);
            await Ctx.SaveChangesAsync();
        }

        public async Task<List<TrainingDTO>> GetUserTrainings(Guid userId)
        {
            var usersInTraining = await Ctx.UsersInTrainings.AsQueryable().Where(t => t.AppUserId.Equals(userId) && t.AttendingTraining.Equals(true))
                .ToListAsync();
            var result = new List<TrainingDTO>();
            foreach (var usrTraining in usersInTraining)
            {
                result.Add(await TrainingDataMapper(usrTraining.TrainingId));
            }
            return result;
        }

        public async Task<TrainingDTO> GetTrainingWithDetails(Guid id)
        {
            return await TrainingDataMapper(id);
        }


        public async Task<TrainingDTO> TrainingDataMapper(Guid Id)
        {
            var training = await Ctx.Trainings.FindAsync(Id);
            var usersInThisTraining =
                await Ctx.UsersInTrainings.AsQueryable().Where(t => t.TrainingId == training.Id).ToListAsync();
            var usersAttending = new List<UserDTO>();
            var usersInvited = new List<UserDTO>();
            foreach (var user in usersInThisTraining)
            {
                if (user.AttendingTraining == false)
                {
                    var appUser = await Ctx.Users.FindAsync(user.AppUserId);
                    var usrDTO = new UserDTO
                    {
                        Id = appUser.Id,
                        email = appUser.Email,
                        phoneNumber = appUser.PhoneNumber,
                        userName = appUser.FirstName + " " + appUser.LastName
                    };
                    usersInvited.Add(usrDTO);
                }

                if (user.AttendingTraining == true)
                {
                    var appUser = await Ctx.Users.FindAsync(user.AppUserId);
                    var usrDTO = new UserDTO
                    {
                        Id = appUser.Id,
                        email = appUser.Email,
                        phoneNumber = appUser.PhoneNumber,
                        userName = appUser.FirstName + " " + appUser.LastName
                    };
                    usersAttending.Add(usrDTO);
                }
            }

            var trainingPlace = await Ctx.TrainingPlaces.FindAsync(training.TrainingPlaceId);
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

            await Ctx.SaveChangesAsync();
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
                StartTime = training.StartTime
            };
            return trainingDto;
        }
    }
}