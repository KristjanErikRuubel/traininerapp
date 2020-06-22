using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Contracts.BLL.App.Services;
using Contracts.DAL.App;
using Contracts.DAL.App.Repositories;
using Domain;
using ee.itcollege.krruub.BLL.Base.Mappers;
using ee.itcollege.krruub.BLL.Base.Services;
using PublicApi.DTO.v1;

namespace BLL.App.Services
{
    public class CommentService : BaseEntityService<ICommentRepository, IAppUnitOfWork, DAL.App.DTO.Comment, BLL.App.DTO.Comment>, ICommentService
    {
        public CommentService(IAppUnitOfWork unitOfWork)
            : base(unitOfWork, new IdentityMapper<DAL.App.DTO.Comment, BLL.App.DTO.Comment>(), unitOfWork.CommentRepository)
        {
        }

        public async Task AddNewComment(CommentDTO dto)
        {
            var dal = new DAL.App.DTO.Comment()
            {
                AppUserId = dto.UserId,
                TrainingId = dto.TrainingId,
                Content = dto.Content,
            };
            ServiceRepository.Add(dal);
            await ServiceUnitOfWork.SaveChangesAsync();
        }

        public async Task<List<CommentDTO>> GetTrainingComments(Guid TrainingId)
        {
            var comments = await ServiceRepository.GetAllByTrainingId(TrainingId);
            var res = new List<CommentDTO>();
            if (comments != null || comments.Count > 0)
            {
                foreach (var comment in comments)
                {
                    var dto = new CommentDTO()
                    {
                        Id = comment.Id,
                        Content = comment.Content,
                        TrainingId = comment.TrainingId,
                        UserId = comment.AppUserId
                    };    
                    res.Add(dto);
                }
            }
            return res;
        }

        public async void RemoveComment(Guid id)
        {
            ServiceRepository.Remove(id);
            await ServiceUnitOfWork.SaveChangesAsync();
        }
    }
}