using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Contracts.BLL.App.Services;
using DAL.App.EF;
using Domain;
using Domain.Identity;
using Microsoft.EntityFrameworkCore;
using PublicApi.DTO.v1.Identity;

namespace BLL.App.Services
{
    public class TeamService : ITeamService
    {
        private AppDbContext ctx { get; set; }
        public TeamService(AppDbContext context)
        {
            ctx = context;
        }
        
        public async void AddPlayerToTeam(AppUser user, string teamId)
        {
        }

        public async Task<List<UserDTO>> getPersonsInTeam(string teamName)
        {
            var query = await ctx.Users.AsQueryable().Where(
                el => el.Team.Name.Equals(teamName)
            ).ToListAsync();
            var result = new List<UserDTO>();
            foreach (var user in query)
            {
                var personRole = await ctx.UserRoleInTeams.FindAsync(user.RoleId);
                var team = await ctx.Teams.FindAsync(user.TeamId);
                var userDto = new UserDTO
                 {
                     userName = user.FirstName + " " + user.LastName,
                     email = user.Email,
                     Id = user.Id,
                     phoneNumber = user.PhoneNumber,
                     position = personRole.PersonPosition,
                     teamName = team.Name
                 };
                 result.Add(userDto);
            }
            return result;
        }
        public async Task removePlayerFromTeam(string userId)
        {
            var user = await ctx.Users.FindAsync(Guid.Parse(userId));
            user.Team = null;
            user.TeamId = Guid.Empty;
            await ctx.SaveChangesAsync();
        }
    }
}
