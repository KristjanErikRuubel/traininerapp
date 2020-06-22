namespace DAL.App.EF.Mappers
{
    public static class UserInTrainingMapper
    {
        public static DTO.UserInTraining Map(Domain.UserInTraining userInTraining)
        {
            var returned = new DTO.UserInTraining
            {
                Id = userInTraining.Id,
                AttendingTraining = userInTraining.AttendingTraining,
                TrainingId = userInTraining.TrainingId,
                AppUserId = userInTraining.AppUserId,
            };
            return returned;
        }

        public static Domain.UserInTraining MapToDomain(DTO.UserInTraining  userInTraining)
        {
            var returned = new Domain.UserInTraining
            {
                Id = userInTraining.Id,
                AttendingTraining = userInTraining.AttendingTraining,
                TrainingId = userInTraining.TrainingId,
                AppUserId = userInTraining.AppUserId
            };
            return returned;
        }
        
    }
}