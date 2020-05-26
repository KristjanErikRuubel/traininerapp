using System.Collections.Generic;
using AutoMapper;
using Domain;

namespace DAL.App.EF.Mappers
{
    public class AccountMapper
    {
        

        public static DAL.App.DTO.Identity.AppUser MapDomainAppUserToDALDTO(Domain.Identity.AppUser appUser)
        {
            var positionDtos = new List<DAL.App.DTO.PlayerPosition>();
            foreach (var position in appUser.PlayerPositions)
            {
                var posDto = new DAL.App.DTO.PlayerPosition()
                {
                    PersonPosition = position.PersonPosition
                };
                positionDtos.Add(posDto);
            }
            
            var AppUser = new DAL.App.DTO.Identity.AppUser()
            {
                AppRoleId = appUser.AppRoleId,
                Id = appUser.Id,
                Email = appUser.Email,
                FirstName = appUser.FirstName,
                LastName = appUser.LastName,
                TeamId = appUser.TeamId,
                PhoneNumber = appUser.PhoneNumber,
                PlayerPositions = positionDtos,
            };
            return AppUser;
        }
    }
}