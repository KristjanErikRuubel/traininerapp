using Contracts.DAL.App.Repositories;
using ee.itcollege.krruub.Contracts.DAL.Base;

namespace Contracts.DAL.App
{
    public interface IAppUnitOfWork : IBaseUnitOfWork
    {
        IBillRepository BillRepository { get; }
        
        INotificationRepository NotificationRepository { get; }
        
        INotificationAnswerRepository NotificationAnswerRepository { get; }
        
        ITrainingRepository TrainingRepository { get; }
        
        ITeamRepository TeamRepository { get; }

        ITrainingPlaceRepository TrainingPlaceRepository { get; }
        IAccountRepository AccountRepository { get; }
        IUserInTrainingRepository UsersInTrainingRepository { get; }
        
        IPlayerPositionRepository PlayerPostionRepository { get; }
        
        ITrainingInBillRepository TrainingInBillRepository { get;  }
        IFeedBackRepository FeedBackRepository { get; }
        
        ICommentRepository CommentRepository { get; }
        ITrainingTeamRepository TrainingTeamRepository { get; }
        IUserInTrainingTeamRepository UserInTrainingTeamRepository { get; }
        
    }
}