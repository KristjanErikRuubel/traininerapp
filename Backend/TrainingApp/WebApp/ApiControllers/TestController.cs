using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using BLL.App.Services;
using Contracts.BLL.App.Services;
using DAL.App.EF;
using Domain;
using Domain.Identity;
using Microsoft.AspNetCore.Mvc;
using PublicApi.DTO.v1;

namespace WebApp.ApiControllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TestController
    {
        private ITeamService _teamService;
        private ITrainingService _trainingService;

        public TestController(ITeamService teamService, ITrainingService trainingService)
        {
            _teamService = teamService;
            _trainingService = trainingService;
        }


        [HttpPost]
        public async Task CreateTraining([FromBody] NewTrainingDTO newTrainingDto)
        {
            Console.WriteLine(newTrainingDto.ToString());
            await _trainingService.AddNewTraining(newTrainingDto);

        }
    }
}