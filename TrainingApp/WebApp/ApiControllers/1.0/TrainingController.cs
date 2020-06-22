using System;
using System.Threading.Tasks;
using Contracts.BLL.App;
using Domain;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PublicApi.DTO.v1;

namespace WebApp.ApiControllers._1._0
{

    [ApiController]
    [ApiVersion( "1.0" )]
    [Route("api/v{version:apiVersion}/[controller]")]
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
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
        // DELETE: api/Training/5
        [HttpDelete("{id}")]
        public OkObjectResult DeleteTraining(Guid id)
        {
           _bll.TrainingService.RemoveTraining(id);
           return Ok("Training Deleted with id :" + id);
        }
        [HttpPost]
        public async Task<OkObjectResult> CreateTraining([FromBody] NewTrainingDTO dto)
        {
            await _bll.TrainingService.AddNewTraining(dto);
            return Ok("Training Created");
        }
        [HttpPost("/comment")]
        public async Task<OkObjectResult> CreateComment([FromBody] CommentDTO dto)
        {
            await _bll.CommentService.AddNewComment(dto);
            return Ok("Comment added");
        }
        [HttpPost("/comment/{id}")]
        public async Task<OkObjectResult> Remove(Guid id)
        {
            _bll.CommentService.RemoveComment(id);
            return Ok("Comment added");
        }

    }
}
