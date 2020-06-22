
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Contracts.BLL.App;
using Microsoft.AspNetCore.Mvc;
using PublicApi.DTO.v1;

namespace WebApp.ApiControllers._1._0
{
    [Route("api/[controller]")]
    [ApiController]
    [ApiVersion( "1.0" )]
    [Route("api/v{version:apiVersion}/[controller]")]
    public class FeedbackController : ControllerBase
    {

        protected readonly IAppBLL _bll;
        
        public FeedbackController(IAppBLL bll)
        {
            _bll = bll;
        }
        [HttpGet]
        public async Task<List<FeedbackDTO>> getFeedback()
        {
            return await _bll.FeedbackService.getAll();
        }
        
        [HttpPost]
        public OkObjectResult PostFeedback(NewFeedBackDTO feedBackDto)
        {
            _bll.FeedbackService.SaveUserFeedBack(feedBackDto);
            return Ok("Feedback saved!");
        }

    }
}