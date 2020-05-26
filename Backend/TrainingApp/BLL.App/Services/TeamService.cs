
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
    public class TeamService : BaseEntityService<ITeamRepository, IAppUnitOfWork, DAL.App.DTO.Team, BLL.App.DTO.Team>, ITeamService
    {
        public IAccountService _accountService;
        public TeamService(IAppUnitOfWork unitOfWork, IAccountService accountService)
            : base(unitOfWork, new IdentityMapper<DAL.App.DTO.Team, BLL.App.DTO.Team>(), unitOfWork.TeamRepository)
        {
            _accountService = accountService;
        }

        public async Task<IEnumerable<DAL.App.DTO.Team>> getPersonsInTeam(string teamName)
        {
            return await ServiceRepository.AllAsync(Guid.NewGuid());
        }

        public async Task<TeamDTO> getTeamDetails(Guid teamId, Guid userId)
        {
            var team = await ServiceRepository.FirstOrDefaultAsync(teamId);
            var usersInTeam = await _accountService.GetAllUsersInTeam(teamId);

            var teamDto = new TeamDTO()
            {
                Id = team.Id,
                Description = team.Description,
                Name = team.Name,
                Users = usersInTeam
            };
            return teamDto;
        }

        public async Task<List<TeamDTO>> GetTeams()
        {
            var teams = await ServiceRepository.AllAsync();
            
            var res = new List<TeamDTO>();
            foreach (var team in teams)
            {
                var playersInTeam = await _accountService.GetAllUsersInTeam(team.Id);
                
                var teamDto = new TeamDTO()
                {
                    Id = team.Id,
                    Description = team.Description,
                    Name = team.Name,
                    Users = playersInTeam
                };
                res.Add(teamDto);
            }
            return res;
        }

        public async Task AddTeam(NewTeamDTO dto)
        {
            var team = new DAL.App.DTO.Team();
            team.Description = dto.Description;
            team.Name = dto.Name;
            ServiceRepository.Add(team);
            await ServiceUnitOfWork.SaveChangesAsync();
        }
    }
}
