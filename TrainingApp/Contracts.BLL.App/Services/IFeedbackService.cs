using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using BLL.App.DTO;
using PublicApi.DTO.v1;

namespace Contracts.BLL.App.Services
{
    public interface IFeedbackService
    {

        public Task SaveUserFeedBack(NewFeedBackDTO feedbackDto);
        public Task DeleteFeedBack(Guid id);

        public Task<List<FeedbackDTO>> getAll();
    }
}