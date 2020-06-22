namespace BLL.App.Mappers
{
    public static class TrainingMapper
    {
        public static DAL.App.DTO.Training Map(Domain.Training training)
        {
            var mappedTraining = new DAL.App.DTO.Training
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