using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Contracts.BLL.App;
using Microsoft.AspNetCore.Mvc;
using Domain;
using PublicApi.DTO.v1;

namespace WebApp.ApiControllers
{
    [Route("api/[controller]")]
    [ApiController]
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

        // [HttpGet]
        // public async Task<TrainingPlaceDTO> GetTrainingPlaceDetails(Guid id)
        // {
        //     return null;
        // }
    }
}
