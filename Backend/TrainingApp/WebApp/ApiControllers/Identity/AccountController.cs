using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using BLL.App.Services;
using Contracts.BLL.App.Services;
using DAL.App.EF;
using Domain;
using Domain.Identity;
using Identity;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using PublicApi.DTO.v1;
using PublicApi.DTO.v1.Identity;

namespace WebApp.ApiControllers.Identity
{
    [ApiController]
    [Route("api/[controller]/[action]")]
    public class AccountController : ControllerBase
    {
        private readonly IAccountService _accountService;
        private ITrainingService _trainingService;
        private IEmailSender _emailSender;

        public AccountController(IAccountService accountService, ITrainingService trainingService, IEmailSender emailSender)
        {
            _accountService = accountService;
            _trainingService = trainingService;
            _emailSender = emailSender;
        }

        [HttpPost]
        public async Task<ActionResult<string>> Login([FromBody] LoginDTO model)
        {
            var userDto = await _accountService.Login(model);
            if (userDto == null)
            {
                return StatusCode(403);
            }

            return Ok(userDto);
        }


        [HttpPost]
        public async Task<ActionResult<string>> Register([FromBody] RegisterDTO model)
        {
            var userDto = await _accountService.Register(model);
            if (userDto == null)
            {
                return StatusCode(403);
            }
            return Ok(userDto);
        }
        
        [HttpPost]
        public async Task<ActionResult<string>> GetUserNotifications([FromBody] UserDTO model)
        {
            var notifications = await _accountService.GetUserNewNotifications(model);
            return Ok(notifications);
        }
        [HttpPost]
        public async Task<ActionResult<string>> GetAllUserNotifications([FromBody] UserDTO model)
        {
            var notifications = await _accountService.GetAllUserNewNotifications(model);
            return Ok(notifications);
        }
                
        [HttpPost]
        public async Task<ActionResult<IEnumerable<TrainingDTO>>> GetUserTrainings([FromBody] UserDTO userDto)
        {
            //[FromBody] string userId
            return await _trainingService.GetUserTrainings(userDto.Id);
        }

        
        
        [HttpGet]
        public async Task test()
        {

            await _emailSender.SendEmailAsync("dsas", "sdadsads", "dsdsdad");

        }
        
    }
}