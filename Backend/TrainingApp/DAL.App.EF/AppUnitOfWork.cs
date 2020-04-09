using System;
using Contracts.DAL.App;
using Contracts.DAL.App.Repositories;
using DAL.App.EF.Repositories;
using DAL.Base.EF;

namespace DAL.App.EF
{
    public class AppUnitOfWork : EFBaseUnitOfWork<AppDbContext>, IAppUnitOfWork
    {
        public AppUnitOfWork(AppDbContext uowDbContext) : base(uowDbContext)
        {
        }
        
        public IBillRepository Bills =>
            GetRepository<IBillRepository>(() => new BillRepository(UOWDbContext));
        public INotificationRepository Notifications =>
            GetRepository<INotificationRepository>(() => new NotificationRepository(UOWDbContext));

        public INotificationAnswerRepository NotificationAnswerRepository =>
            GetRepository<INotificationAnswerRepository>(() => new INotificationAnswerRepository());

        public ITrainingRepository Trainings =>
            GetRepository<ITrainingRepository>(() => new TrainingRepository(UOWDbContext));
        public ITeamRepository Teams =>
            GetRepository<ITeamRepository>(() => new TeamRepository(UOWDbContext));
        public IPersonInTrainingRepository PersonInTraining =>
            GetRepository<IPersonInTrainingRepository>(() => new PersonInTrainingRepository(UOWDbContext));
        
        public ITrainingPlaceRepository TrainingPlaces =>
            GetRepository<ITrainingPlaceRepository>(() => new TrainingPlaceRepository(UOWDbContext));
        
    }
}