using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using PublicApi.DTO.v1;

namespace Contracts.BLL.App.Services
{
    public interface ICommentService
    {
        public Task AddNewComment(CommentDTO dto);
        public Task<List<CommentDTO>> GetTrainingComments(Guid TrainingId);
        public void RemoveComment(Guid id);
    }
}