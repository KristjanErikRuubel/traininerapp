using Contracts.DAL.App.Repositories;
using Contracts.DAL.Base;

namespace Contracts.DAL.App
{
    public interface IAppUnitOfWork : IBaseUnitOfWork
    {
        IBillRepository Bills { get; }
        
        INotificationRepository Notifications { get; }
        
        INotificationAnswerRepository NotificationAnswerRepository { get; }
        
        ITrainingRepository Trainings { get; }

        ITrainingPlaceRepository TrainingPlaces { get; }
    }
}