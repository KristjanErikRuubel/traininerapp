namespace BLL.App.Mappers
{
    public static class UserInTrainingMapper
    {
        public static DTO.UserInTraining Map(DAL.App.DTO.UserInTraining userInTraining)
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
    }
}