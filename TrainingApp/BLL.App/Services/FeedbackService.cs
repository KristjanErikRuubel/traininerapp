using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BLL.App.Mappers;
using Contracts.BLL.App.Services;
using Contracts.DAL.App;
using Contracts.DAL.App.Repositories;
using DAL.App.DTO;
using ee.itcollege.krruub.BLL.Base.Mappers;
using ee.itcollege.krruub.BLL.Base.Services;
using PublicApi.DTO.v1;

namespace BLL.App.Services
{
    public class FeedbackService : BaseEntityService<IFeedBackRepository, IAppUnitOfWork, DAL.App.DTO.Feedback, BLL.App.DTO.Feedback>,
        IFeedbackService
    {
        public FeedbackService(IAppUnitOfWork unitOfWork) 
            : base(unitOfWork, new BaseBLLMapper<DAL.App.DTO.Feedback, BLL.App.DTO.Feedback>(), unitOfWork.FeedBackRepository)
        {
        }

        public async Task SaveUserFeedBack(NewFeedBackDTO feedbackDto)
        {    
            var feedbackDalDto = new Feedback()
            {
                AppUserId = feedbackDto.AppUserId,
                Content = feedbackDto.Feedback,
                Rating = feedbackDto.Rating

            };
            await ServiceRepository.AddNewFeedback(feedbackDalDto);
            await ServiceUnitOfWork.SaveChangesAsync();
        }
        public async Task DeleteFeedBack(Guid id)
        {
            ServiceRepository.Remove(id);
            await ServiceUnitOfWork.SaveChangesAsync();
        }

        public async Task<List<FeedbackDTO>> getAll()
        {
            var Feedbacks = await ServiceRepository.AllAsync();
            var result = new List<FeedbackDTO>();
            foreach (var feedback in Feedbacks)
            {
                var user = await ServiceUnitOfWork.AccountRepository.FirstOrDefaultAsync(feedback.AppUserId);
                var dto = new FeedbackDTO
                {
                    Feedback = feedback.Content,
                    Rating = feedback.Rating,
                    AppUser = user.FirstName + " " + user.LastName
                };
                result.Add(dto);
                
            }
            return result;
        }
    }
}