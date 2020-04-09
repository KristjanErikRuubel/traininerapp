﻿using System.Collections.Generic;
using System.Threading.Tasks;
using Domain.Identity;
using PublicApi.DTO.v1.Identity;

namespace Contracts.BLL.App.Services
{
    public interface ITeamService
    {
        public Task<List<UserDTO>> getPersonsInTeam(string TeamId);

    }
}