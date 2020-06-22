using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Contracts.BLL.App;
using DAL.App.DTO;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using PublicApi.DTO.v1;

namespace WebApp.ApiControllers._1._0
{
    [ApiController]
    [ApiVersion( "1.0" )]
    [Route("api/v{version:apiVersion}/[controller]")]
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    public class TrainingPlaceController : ControllerBase
    {
        private readonly IAppBLL _bll;

        public TrainingPlaceController(IAppBLL bll)
        {
            _bll = bll;
        }

        // GET: api/TrainingPlace
        [HttpGet]
        public async Task<List<TrainingPlaceDTO>> GetTrainingPlaces()
        {
            return await _bll.TrainingPlaceService.GetAllTrainingPlaces();
        }
        // GET: api/TrainingPlace
        // [HttpGet("{id}")]
        // public async Task<TrainingPlaceDTO> GetTrainingPlace(Guid id)
        // {
        //     // return await _bll.TrainingPlaceService.GetTrainingPlace(id);
        // }
        [HttpPost]
        public async Task<OkObjectResult> AddTrainingPlace(TrainingPlaceDTO dto)
        {
            await _bll.TrainingPlaceService.AddTrainingPlace(dto);
            return Ok("Training place added");
        }
        
        [HttpPut]
        public async Task<OkObjectResult> Edit(TrainingPlaceDTO dto)
        {
            await _bll.TrainingPlaceService.AddTrainingPlace(dto);
            return Ok("Training place added");
        }
        
        [HttpDelete("{id}")]
        public async Task<OkObjectResult> Delete(Guid id)
        {
            await _bll.TrainingPlaceService.RemoveTrainingPlace(id);
            return Ok("Training place removed");
        }
        
    }
}
