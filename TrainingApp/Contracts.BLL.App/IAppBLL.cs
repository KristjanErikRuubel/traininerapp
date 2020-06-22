using Contracts.BLL.App.Services;
using ee.itcollege.krruub.Contracts.BLL.Base;

namespace Contracts.BLL.App
{
    public interface IAppBLL : IBaseBLL
    {
        public IBillService BillService { get; }
        public IAccountService AccountService { get; }
        public INotificationService NotificationService { get; }
        public ITrainingService TrainingService { get; }
        public INotificationAnswerService NotificationAnswerService { get; }

        public ITrainingPlaceService TrainingPlaceService { get; }
        public ITeamService TeamService { get; }

        public IPlayerPositionService PlayerPositions { get; }
        public IFeedbackService FeedbackService { get; }
        public ICommentService CommentService { get; }
    }
}