using Contracts.DAL.App;
using Contracts.DAL.App.Repositories;
using DAL.App.EF.Repositories;
using ee.itcollege.krruub.DAL.Base;
using ee.itcollege.krruub.DAL.Base.EF;

namespace DAL.App.EF
{
    public class AppUnitOfWork : EFBaseUnitOfWork<AppDbContext>, IAppUnitOfWork
    {
        public AppUnitOfWork(AppDbContext uowDbContext) : base(uowDbContext)
        {
        }

        public IAccountRepository AccountRepository =>
            GetRepository<IAccountRepository>(() => new AccountRepository(UOWDbContext));

        public IUserInTrainingRepository UsersInTrainingRepository =>
            GetRepository<IUserInTrainingRepository>(() => new UserInTrainingRepository(UOWDbContext));

        public IPlayerPositionRepository PlayerPostionRepository =>
            GetRepository<IPlayerPositionRepository>(() => new PlayerPositionRepository(UOWDbContext));

        public ITrainingInBillRepository TrainingInBillRepository =>
            GetRepository<ITrainingInBillRepository>(() => new TrainingInBillRepository(UOWDbContext));

        public IBillRepository BillRepository =>
            GetRepository<IBillRepository>(() => new BillRepository(UOWDbContext));
        public INotificationRepository NotificationRepository =>
            GetRepository<INotificationRepository>(() => new NotificationRepository(UOWDbContext));

        public INotificationAnswerRepository NotificationAnswerRepository =>
            GetRepository<INotificationAnswerRepository>(() => new NotificationAnswerRepository(UOWDbContext));

        public ITrainingRepository TrainingRepository =>
            GetRepository<ITrainingRepository>(() => new TrainingRepository(UOWDbContext));
        public ITeamRepository TeamRepository =>
            GetRepository<ITeamRepository>(() => new TeamRepository(UOWDbContext));
        public ITrainingPlaceRepository TrainingPlaceRepository =>
            GetRepository<ITrainingPlaceRepository>(() => new TrainingPlaceRepository(UOWDbContext));
        
        

        
    }
}