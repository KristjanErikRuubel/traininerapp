using BLL.App.Services;
using Contracts.BLL.App;
using Contracts.BLL.App.Services;
using Contracts.DAL.App;
using Domain.Identity;
using ee.itcollege.krruub.BLL.Base;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.Extensions.Configuration;

namespace BLL.App
{
    public class AppBLL : BaseBLL<IAppUnitOfWork>, IAppBLL
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly SignInManager<AppUser> _signInManager;
        private RoleManager<AppRole> _roleManager;
        private IPlayerPositionService PlayerPositionService;

        private IEmailSender Sender { get; set; }
        private readonly IConfiguration _configuration;
        public AppBLL(IAppUnitOfWork unitOfWork, UserManager<AppUser> userManager, 
            SignInManager<AppUser> signInManager, RoleManager<AppRole> roleManager, IConfiguration configuration, IPlayerPositionService playerPositionService) : base(unitOfWork)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _roleManager = roleManager;
            _configuration = configuration;
            PlayerPositionService = playerPositionService;
        }

        public INotificationAnswerService NotificationAnswerService =>
            GetService<INotificationAnswerService>(() => new NotificationAnswerService(UnitOfWork));

        public ITrainingPlaceService TrainingPlaceService =>
            GetService<ITrainingPlaceService>(() => new TrainingPlaceService(UnitOfWork));
        public ITeamService TeamService => GetService<ITeamService>(() => new TeamService(UnitOfWork, AccountService));

        public IPlayerPositionService PlayerPositions =>
            GetService<IPlayerPositionService>(() => new PlayerPositionService(UnitOfWork));

        public IBillService BillService =>
            GetService<IBillService>(() => new BillService(UnitOfWork));
        public IAccountService AccountService => GetService<IAccountService>(() => new AccountService(_configuration, _userManager, _signInManager, UnitOfWork, _roleManager, PlayerPositionService));

        public INotificationService NotificationService =>
            GetService<INotificationService>(() => new NotificationService(UnitOfWork, Sender));

        public ITrainingService TrainingService =>
            GetService<ITrainingService>(() => new TrainingService(NotificationService, UnitOfWork));
        
    }
}
