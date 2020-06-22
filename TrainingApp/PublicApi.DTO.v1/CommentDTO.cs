using System;

namespace PublicApi.DTO.v1
{
    public class CommentDTO
    {
        public string Content { get; set; }
        public Guid? TrainingId { get; set; }
        public Guid? UserId { get; set; }
        public Guid? Id { get; set; }
    }
}