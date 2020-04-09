using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BLL.App.Services;
using Contracts.BLL.App.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using DAL.App.EF;
using Domain;
using PublicApi.DTO.v1;

namespace WebApp.ApiControllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class NotificationAnswerController : ControllerBase
    {
        private readonly AppDbContext _context;
        private INotificationAnswerService _notificationAnswerService;

        public NotificationAnswerController(AppDbContext context, INotificationAnswerService notificationAnswerService)
        {
            _context = context;
            _notificationAnswerService = notificationAnswerService;
        }

        // POST: api/NotificationAnswer
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPost]
        public async Task PostNotificationAnswer([FromBody] NotificationAnswerDTO notificationAnswer)
        {
            await _notificationAnswerService.AnswerNotification(notificationAnswer);
        }

        [HttpPost]
        [Route("/change")]
        public async Task ChangeAnswer([FromBody] NotificationAnswerDTO notificationAnswer)
        {
            await _notificationAnswerService.ChangeAnswer(notificationAnswer);
        }
    }
}
