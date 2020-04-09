using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Domain;
using PublicApi.DTO.v1;
using PublicApi.DTO.v1.Identity;

namespace Contracts.BLL.App.Services
{
    public interface IAccountService
    {

        public Task<UserDTO> Register(RegisterDTO model);
        public Task<UserDTO> Login(LoginDTO model);
        Task<List<NotificationDTO>> GetUserNewNotifications(UserDTO model);

        public Task<List<NotificationDTO>> GetAllUserNewNotifications(UserDTO model);
    }


}