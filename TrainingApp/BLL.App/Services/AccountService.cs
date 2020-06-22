using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Contracts.BLL.App.Services;
using Contracts.DAL.App;
using Contracts.DAL.App.Repositories;
using Domain.Identity;
using ee.itcollege.krruub.BLL.Base.Mappers;
using ee.itcollege.krruub.BLL.Base.Services;
using ee.itcollege.krruub.Identity;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using PublicApi.DTO.v1;
using PublicApi.DTO.v1.Identity;

namespace BLL.App.Services
{
    public class AccountService : BaseEntityService<IAccountRepository, IAppUnitOfWork, DAL.App.DTO.Identity.AppUser,
            BLL.App.DTO.Identity.AppUser>,
        IAccountService
    {
        private readonly IConfiguration _configuration;
        private readonly UserManager<AppUser> _userManager;
        private readonly SignInManager<AppUser> _signInManager;
        private RoleManager<AppRole> _roleManager;
        private IPlayerPositionService playerPositionService;

        public AccountService(IConfiguration configuration, UserManager<AppUser> userManager,
            SignInManager<AppUser> signInManager, IAppUnitOfWork unitOfWork, RoleManager<AppRole> roleManager,
            IPlayerPositionService playerPositionService)
            : base(unitOfWork, new BaseBLLMapper<DAL.App.DTO.Identity.AppUser, BLL.App.DTO.Identity.AppUser>(),
                unitOfWork.AccountRepository)
        {
            _configuration = configuration;
            _userManager = userManager;
            _signInManager = signInManager;
            _roleManager = roleManager;
            this.playerPositionService = playerPositionService;
        }

        public async Task<UserDTO> Login(LoginDTO model)
        {
            var appUser = await _userManager.FindByEmailAsync(model.Email);
            if (appUser == null)
            {
                return null;
            }

            var result = await _signInManager.CheckPasswordSignInAsync(appUser, model.Password, false);
            if (result.Succeeded)
            {
                var claimsPrincipal = await _signInManager.CreateUserPrincipalAsync(appUser);
                var jwt = await CreateJwtTokenForUser(appUser);
                var team = await ServiceUnitOfWork.TeamRepository.FindAsync(appUser.TeamId);
                var role = await _userManager.GetRolesAsync(appUser);
                var positions = await playerPositionService.GetPlayerPositions(appUser.Id);
                var positionsDtos = MapPositionToPlayerPositionDtos(positions);

                var userDto = new UserDTO
                {
                    Id = appUser.Id,
                    email = appUser.Email,
                    phoneNumber = appUser.PhoneNumber,
                    teamName = team.Name,
                    teamId = team.Id,
                    positions = positionsDtos,
                    token = jwt,
                    userName = appUser.FirstName + " " + appUser.LastName,
                    role = role[0]
                };
                return userDto;
            }

            return null;
        }

        private static List<PlayerPositionDTO> MapPositionToPlayerPositionDtos(
            List<DAL.App.DTO.PlayerPosition> positions)
        {
            var postions = new List<PlayerPositionDTO>();
            foreach (var pos in positions)
            {
                var dto = new PlayerPositionDTO()
                {
                    Id = pos.Id,
                    Position = pos.PersonPosition
                };
                postions.Add(dto);
            }

            return postions;
        }

        public async Task<List<NotificationDTO>> GetUserNewNotifications(Guid userId)
        {
            var notifications = await ServiceUnitOfWork.NotificationRepository.GetNewNotifications(userId);
            var notificationDtos = new List<NotificationDTO>();
            foreach (var not in notifications)
            {
                if (not.TrainingId != null)
                {
                    var training = await ServiceUnitOfWork.TrainingRepository.FirstOrDefaultAsync(not.TrainingId);
                    var trainingDto = new TrainingDTO
                    {
                        Id = training.Id,
                        TrainingDate = training.Start,
                        StartTime = training.StartTime,
                        Description = training.Description
                    };
                    var notDto = new NotificationDTO
                    {
                        Id = not.Id,
                        NotificationContent = not.Content,
                        Title = not.Title,
                        TrainingDto = trainingDto
                    };
                    notificationDtos.Add(notDto);
                }
                else
                {
                    var notDto = new NotificationDTO
                    {
                        Id = not.Id,
                        NotificationContent = not.Content,
                        Title = not.Title
                    };
                    notificationDtos.Add(notDto);
                }
                
               
            }

            return notificationDtos;
        }

        public async Task<List<NotificationDTO>> GetAllUserNewNotifications(Guid userId)
        {
            var notifications = await ServiceUnitOfWork.NotificationRepository.GetNewNotifications(userId);
            var notificationDtos = new List<NotificationDTO>();
            foreach (var not in notifications)
            {
                var training = await ServiceUnitOfWork.TrainingRepository.FindAsync(not.TrainingId);
                var trainingDto = new TrainingDTO
                {
                    Id = training.Id,
                    TrainingDate = training.Start,
                    StartTime = training.StartTime,
                    Description = training.Description
                };
                var notDto = new NotificationDTO
                {
                    Id = not.Id,
                    NotificationContent = not.Content,
                    Recieved = not.Recived,
                    Title = not.Title,
                    TrainingDto = trainingDto
                };
                notificationDtos.Add(notDto);
            }

            return notificationDtos;
        }

        public async Task<List<UserDTO>> GetAllUsersInTeam(Guid teamId)
        {
            var users = await ServiceRepository.GetAllInUsersInTeam(teamId);
            var result = new List<UserDTO>();
            if (users.Equals(null))
            {
                return new List<UserDTO>();
            }

            foreach (var user in users)
            {
                var positions = await playerPositionService.GetPlayerPositions(user.Id);
                var team = await ServiceUnitOfWork.TeamRepository.FirstOrDefaultAsync(user.TeamId);
                var userDto = new UserDTO
                {
                    Id = user.Id,
                    userName = user.FirstName + " " + user.LastName,
                    email = user.Email,
                    phoneNumber = user.PhoneNumber,
                    positions = MapPositionToPlayerPositionDtos(positions),
                    teamName = team.Name,
                };
                result.Add(userDto);
            }

            return result;
        }

        public async Task RemovePlayerFromTeam(UserDTO dto)
        {
            var appUserToRemove = await ServiceRepository.FirstOrDefaultAsync(dto.Id);
            appUserToRemove.Team = null;
            appUserToRemove.TeamId = null;
            ServiceRepository.Update(appUserToRemove);
            await ServiceUnitOfWork.SaveChangesAsync();
        }

        public async Task<UserDTO> Register(RegisterDTO model)
        {
            var user = CreateAppUserFromModel(model);
            var result = await _userManager.CreateAsync(user, model.Password);
            if (result.Succeeded)
            {
                AddPositionsToPlayer(model, user.Id);
                await AddAppRoleToUser(model, user);
                var jwt = await CreateJwtTokenForUser(user);
                var userDto = await MapToAppUserToUserDto(model, user, jwt);
                await ServiceUnitOfWork.SaveChangesAsync();
                return userDto;
            }

            return null;
        }

        private void AddPositionsToPlayer(RegisterDTO model, Guid userId)
        {
            foreach (var position in model.PlayerPositions)
            {
                var playerPos = new DAL.App.DTO.PlayerPosition()
                {
                    AppUserId = userId,
                    PersonPosition = position
                };
                ServiceUnitOfWork.PlayerPostionRepository.Add(playerPos);
            }
        }

        private AppUser CreateAppUserFromModel(RegisterDTO model)
        {
            var user = new AppUser
            {
                UserName = model.Email,
                FirstName = model.FirstName,
                PhoneNumber = model.PhoneNumber,
                LastName = model.LastName,
                Email = model.Email,
                TeamId = model.TeamId
            };
            return user;
        }

        private async Task<UserDTO> MapToAppUserToUserDto(RegisterDTO model, AppUser user, string jwt)
        {
            var positions = await playerPositionService.GetPlayerPositions(user.Id);
            var role = await _userManager.GetRolesAsync(user);
            var team = await ServiceUnitOfWork.TeamRepository.FirstOrDefaultAsync(user.TeamId);
            var userDto = new UserDTO()
            {
                Id = user.Id,
                email = user.Email,
                phoneNumber = user.PhoneNumber,
                teamName = team.Name,
                positions = MapPositionToPlayerPositionDtos(positions),
                token = jwt,
                userName = user.FirstName + " " + user.LastName,
                role = role[0],
                teamId = user.TeamId
            };
            return userDto;
        }

        private async Task<string> CreateJwtTokenForUser(AppUser user)
        {
            var claimsPrincipal = await _signInManager.CreateUserPrincipalAsync(user); //get the User analog
            var jwt = IdentityExtensions.GenerateJwt(claimsPrincipal.Claims,
                _configuration["JWT:SigningKey"],
                _configuration["JWT:Issuer"],
                _configuration.GetValue<int>("JWT:ExpirationInDays")
            );
            return jwt;
        }

        private async Task AddAppRoleToUser(RegisterDTO model, AppUser user)
        {
            await _userManager.AddToRoleAsync(user, model.Role);
        }
    }
}