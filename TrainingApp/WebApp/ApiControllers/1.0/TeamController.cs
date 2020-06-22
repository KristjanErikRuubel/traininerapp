using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Contracts.BLL.App;
using Microsoft.AspNetCore.Mvc;
using PublicApi.DTO.v1;
using PublicApi.DTO.v1.Identity;

namespace WebApp.ApiControllers._1._0
{
    [ApiController]
    [ApiVersion( "1.0" )]
    [Route("api/v{version:apiVersion}/[controller]")]
    // [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    public class TeamController : ControllerBase
    {
        private IAppBLL _bll;

        public TeamController(IAppBLL bll)
        {
            _bll = bll;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<TeamDTO>>> GetTeams()
        {
            return await _bll.TeamService.GetTeams();
        }

        [HttpPost]
        public async Task CreateTeam([FromBody] NewTeamDTO dto)
        {
            await _bll.TeamService.AddTeam(dto);
        }
        
        [HttpPut]
        public async Task Edit([FromBody] NewTeamDTO dto)
        {
            await _bll.TeamService.AddTeam(dto);
        }
        
        [Route("removePlayer")]
        [HttpPost]
        public async Task RemovePlayerFromTeam([FromBody] UserDTO dto)
        {
            await _bll.AccountService.RemovePlayerFromTeam(dto);
        }
        
        [HttpDelete("{id}")]
        public OkObjectResult RemoveTeam(Guid id)
        {
            _bll.TeamService.RemoveTeam(id);
            return Ok("Team deleted");
        }
    }
}
