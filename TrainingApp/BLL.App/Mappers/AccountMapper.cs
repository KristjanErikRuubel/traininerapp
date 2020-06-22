using System.Collections.Generic;
using PublicApi.DTO.v1.Identity;

namespace BLL.App.Mappers
{
    public static class AccountMapper
    {
        public static DTO.Identity.AppUser Map(DTO.Identity.AppUser appUser)
        {
            var positionDtos = new List<DTO.PlayerPosition>();
            if (appUser.PlayerPositions != null)
            {
                 foreach (var position in appUser.PlayerPositions)
                 {
                     var posDto = new DTO.PlayerPosition
                     {
                         PersonPosition = position.PersonPosition
                     };
                     positionDtos.Add(posDto);
                 }
            }
            var dto = new DTO.Identity.AppUser
            {
                Id = appUser.Id,
                Email = appUser.Email,
                FirstName = appUser.FirstName,
                LastName = appUser.LastName,
                TeamId = appUser.TeamId,
                PhoneNumber = appUser.PhoneNumber,
                PlayerPositions = positionDtos,
            };
            return dto;
        }

        public static UserDTO MapAppUserToUserDto(DTO.Identity.AppUser user)
        {
            var userDto = new UserDTO()
            {
                Id = user.Id,
                email = user.Email,
                phoneNumber = user.PhoneNumber,
                userName = user.FirstName + " " + user.LastName,
                teamId = user.TeamId
            };
            return userDto;
        }
    }
}