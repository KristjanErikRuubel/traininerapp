using System;

namespace PublicApi.DTO.v1
{
    public class NewFeedBackDTO
    {
        public string Feedback { get; set; }
        public Int16 Rating { get; set; }
        public Guid AppUserId { get; set; }
    }
}