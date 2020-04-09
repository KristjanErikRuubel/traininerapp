using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Contracts.BLL.App.Services;
using DAL.App.EF;
using Domain;
using Domain.Identity;
using Identity;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using PublicApi.DTO.v1;
using PublicApi.DTO.v1.Identity;

namespace BLL.App.Services
{
    public class AccountService : IAccountService
    {
        private readonly IConfiguration _configuration;
        private readonly UserManager<AppUser> _userManager;
        private readonly ILogger<AccountService> _logger;
        private readonly SignInManager<AppUser> _signInManager;
        private readonly AppDbContext _context;

        public AccountService(IConfiguration configuration, UserManager<AppUser> userManager,
            ILogger<AccountService> logger, SignInManager<AppUser> signInManager, AppDbContext context)
        {
            _configuration = configuration;
            _userManager = userManager;
            _logger = logger;
            _signInManager = signInManager;
            _context = context;
        }

        public async Task<UserDTO> Login(LoginDTO model)
        {
            var appUser = await _userManager.FindByEmailAsync(model.Email);
            if (appUser == null)
            {
                _logger.LogInformation($"Web-Api login. User {model.Email} not found!");
                return null;
            }

            var result = await _signInManager.CheckPasswordSignInAsync(appUser, model.Password, false);
            if (result.Succeeded)
            {
                var claimsPrincipal = await _signInManager.CreateUserPrincipalAsync(appUser);
                var jwt = IdentityExtensions.GenerateJwt(claimsPrincipal.Claims,
                    _configuration["JWT:SigningKey"],
                    _configuration["JWT:Issuer"],
                    _configuration.GetValue<int>("JWT:ExpirationInDays")
                );
                _logger.LogInformation($"Token generated for user {model.Email}");
                var team = await _context.Teams.FindAsync(appUser.TeamId);
                var pos = await _context.UserRoleInTeams.FindAsync(appUser.RoleId);
                var userDto = new UserDTO
                {
                    Id = appUser.Id,
                    email = appUser.Email,
                    phoneNumber = appUser.PhoneNumber,
                    teamName = team.Name,
                    position = pos.PersonPosition,
                    token = jwt,
                    userName = appUser.FirstName + " " + appUser.LastName
                };
                return userDto;
            }

            _logger.LogInformation($"Web-Api login. User {model.Email} attempted to log-in with bad password!");
            return null;
        }

        public async Task<List<NotificationDTO>> GetUserNewNotifications(UserDTO model)
        {
            var notifications = await _context.Notifications.AsQueryable().Where(n => n.AppUserId.Equals(model.Id) && n.Recived == false)
                .ToListAsync();
            var notificationDtos = new List<NotificationDTO>();
            foreach (var not in notifications)
            {
                var training = await _context.Trainings.FindAsync(not.TrainingId);
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
            return notificationDtos;
        }
        
        public async Task<List<NotificationDTO>> GetAllUserNewNotifications(UserDTO model)
        {
            var notifications = await _context.Notifications.AsQueryable().Where(n => n.AppUserId.Equals(model.Id))
                .ToListAsync();
            var notificationDtos = new List<NotificationDTO>();
            foreach (var not in notifications)
            {
                var training = await _context.Trainings.FindAsync(not.TrainingId);
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
                    Recideved = not.Recived,
                    Title = not.Title,
                    TrainingDto = trainingDto
                };
                notificationDtos.Add(notDto);
            }
            return notificationDtos;
        }


        public async Task<UserDTO> Register(RegisterDTO model)
        {
            var personRole = new UserRoleInTeam()
            {
                PersonPosition = model.PlayerPosition,
                Role = "Tavakasutaja"
            };
            _logger.LogInformation(model.ToString());
            var user = new AppUser
            {
                UserName = model.Email,
                FirstName = model.FirstName,
                PhoneNumber = model.PhoneNumber,
                LastName = model.LastName,
                Email = model.Email,
                Team = await _context.Teams.FindAsync(Guid.Parse(model.TeamId)),
                Role = personRole
            };
            _logger.LogInformation(user.ToString());
            var result = await _userManager.CreateAsync(user, model.Password);
            if (result.Succeeded)
            {
                var claimsPrincipal = await _signInManager.CreateUserPrincipalAsync(user); //get the User analog
                var jwt = IdentityExtensions.GenerateJwt(claimsPrincipal.Claims,
                    _configuration["JWT:SigningKey"],
                    _configuration["JWT:Issuer"],
                    _configuration.GetValue<int>("JWT:ExpirationInDays")
                );
                _logger.LogInformation($"Registerered new user with email {model.Email}");
                var userDto = new UserDTO()
                {
                    Id = user.Id,
                    email = user.Email,
                    phoneNumber = user.PhoneNumber,
                    teamName = user.Team.Name,
                    position = user.Role.PersonPosition,
                    token = jwt,
                    userName = user.FirstName + " " + user.LastName
                };
                return userDto;
            }

            return null;
        }
    }
}