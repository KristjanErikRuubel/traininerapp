using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Contracts.BLL.App;
using Domain;
using Domain.Identity;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PublicApi.DTO.v1;
using PublicApi.DTO.v1.Identity;

namespace WebApp.ApiControllers.Identity
{
    [ApiController]
    [Route("api/[controller]/[action]")]
    public class AccountController : ControllerBase
    {
        private IAppBLL _bll;
        private RoleManager<AppRole> _roleManager;
        public AccountController( IAppBLL bll, RoleManager<AppRole> roleManager)
        {
            _bll = bll;
            _roleManager = roleManager;
        }

        [HttpPost]
        public async Task<ActionResult<string>> Login([FromBody] LoginDTO model)
        {
            var userDto = await _bll.AccountService.Login(model);
            if (userDto == null)
            {
                return StatusCode(403);
            }

            return Ok(userDto);
        }
        
        [HttpPost]
        public async Task<ActionResult<string>> Register([FromBody] RegisterDTO model)
        {
            var userDto = await _bll.AccountService.Register(model);
            if (userDto == null)
            {
                return StatusCode(403);
            }
            return Ok(userDto);
        }
        
        [HttpGet("{id}")]
        public async Task<ActionResult<string>> GetUserNotifications(Guid id)
        {
            var notifications = await _bll.AccountService.GetUserNewNotifications(id);
            return Ok(notifications);
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<string>> GetAllUserNotifications(Guid id)
        {
            var notifications = await _bll.AccountService.GetAllUserNewNotifications(id);
            return Ok(notifications);
        }
                
        [HttpGet("{id}")]
        public async Task<ActionResult<IEnumerable<TrainingDTO>>> GetUserTrainings(Guid id)
        {
            return await _bll.TrainingService.GetUserTrainings(id);
        }

        
        [HttpGet("{id}")]
        public async Task<ActionResult<IEnumerable<UserDTO>>> GetUsersInTeam(Guid id)
        {
            return await _bll.AccountService.GetAllUsersInTeam(id);
        }

        [HttpGet]
        public async Task<List<AppRole>> GetApplicationRoles()
        {
            return await _roleManager.Roles.ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<List<PlayerPosition>> GetPlayerPositions(Guid id)
        {
            return null; //  await _bll.PlayerPositions.GetPlayerPositions(id);
        }
    }
}