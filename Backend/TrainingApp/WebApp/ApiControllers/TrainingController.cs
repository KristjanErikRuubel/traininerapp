using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Contracts.BLL.App;
using Contracts.BLL.App.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using DAL.App.EF;
using Domain;
using PublicApi.DTO.v1;
using PublicApi.DTO.v1.Identity;

namespace WebApp.ApiControllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TrainingController : ControllerBase
    {
        private readonly IAppBLL _bll;

        public TrainingController(IAppBLL bll)
        {
            _bll = bll;
        }


        [HttpGet("{id}")]
        public async Task<TrainingDTO> GetTraining(Guid id)
        {

            var trainingDto = await _bll.TrainingService.GetTrainingWithDetails(id);

            return trainingDto;
        }

        [HttpPost]
        public async Task<OkObjectResult> CreateTraining([FromBody] NewTrainingDTO dto)
        {
            await _bll.TrainingService.AddNewTraining(dto);
            return Ok("Training Created");
        }

    }
}
