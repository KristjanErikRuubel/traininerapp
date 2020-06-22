using System.Collections.Generic;

namespace DAL.App.EF.Mappers
{
    public static class AccountMapper
    {
        

        public static DTO.Identity.AppUser Map(Domain.Identity.AppUser appUser)
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
    }
}