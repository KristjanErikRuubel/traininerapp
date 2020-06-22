using System;

namespace PublicApi.DTO.v1
{
    public class FeedbackDTO
    {
        public string Feedback { get; set; }
        public Int16 Rating { get; set; }
        public string AppUser { get; set; }
    }
}