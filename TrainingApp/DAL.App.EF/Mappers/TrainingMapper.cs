namespace DAL.App.EF.Mappers
{
    public static class TrainingMapper
    {
        public static DTO.Training Map(Domain.Training training)
        {
            var mappedTraining = new DTO.Training
            {
                
                Id = training.Id,
                TrainingPlaceId = training.TrainingPlaceId,
                TrainingStatus = training.TrainingStatus,
                Description = training.Description,
                Start = training.Start,
                StartTime = training.StartTime,
                CreatorId = training.CreatorId,
                Duration = training.Duration
            };
            return mappedTraining;
        }
    }
}