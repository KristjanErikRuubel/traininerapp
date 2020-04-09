using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Contracts.BLL.App.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using DAL.App.EF;
using Domain;
using Domain.Identity;
using PublicApi.DTO.v1.Identity;

namespace WebApp.ApiControllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TeamController : ControllerBase
    {
        private ITeamService _teamService;
        private ITrainingService _trainingService;

        public TeamController(ITeamService teamService, ITrainingService trainingService)
        {
            _teamService = teamService;
            _trainingService = trainingService;
        }
        
        [HttpPost]
        public async Task<ActionResult<IEnumerable<UserDTO>>> GetPersonsInTeam([FromBody] UserDTO user)
        {
            return await _teamService.getPersonsInTeam(user.teamName);
        }
    }
}
