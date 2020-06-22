using Domain;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace DAL.App.EF.Mappers
{
    public static class BillMapper
    {
        public static DTO.Bill Map(Bill bill)
        {

            var dto = new DTO.Bill()
            {
                Id = bill.Id,
                AppUserId = bill.AppUserId,
                Deadline = bill.Deadline,
                Total =  bill.Total,
            };
            return dto;
        }

        public static Bill MapToDomain(DTO.Bill bill)
        {
            var dto = new Bill()
            {
                AppUserId = bill.AppUserId,
                Deadline = bill.Deadline,
                Total =  bill.Total,
            };
            return dto;
            
        }
    }
}