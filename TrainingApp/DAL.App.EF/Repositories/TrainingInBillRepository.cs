using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Contracts.DAL.App.Repositories;
using DAL.App.EF.Mappers;
using Domain;
using ee.itcollege.krruub.DAL.Base.EF.Mappers;
using ee.itcollege.krruub.DAL.Base.EF.Repositories;
using Microsoft.EntityFrameworkCore;

namespace DAL.App.EF.Repositories
{
    public class TrainingInBillRepository : EFBaseRepository<AppDbContext, Domain.TrainingInBill, DAL.App.DTO.TrainingInBill>, ITrainingInBillRepository
    {
        public TrainingInBillRepository(AppDbContext dbContext) : base(dbContext, new BaseDALMapper<TrainingInBill, DTO.TrainingInBill>())
        {
        }

        // public async Task<IEnumerable<DTO.TrainingInBill>> AllAsync(Guid? userId = null)
        // {
        //     return null;
        // }

        public Task<DTO.TrainingInBill> FirstOrDefaultAsync(Guid id, Guid? userId = null)
        {
            throw new NotImplementedException();
        }

        public Task<bool> ExistsAsync(Guid id, Guid? userId = null)
        {
            throw new NotImplementedException();
        }

        public Task DeleteAsync(Guid id, Guid? userId = null)
        {
            throw new NotImplementedException();
        }

        public async Task<List<DTO.TrainingInBill>> GetTrainingsInBill(Guid billId)
        {
            return (await RepoDbSet.AsQueryable().Where(tib => tib.BillId.Equals(billId)).ToListAsync()).Select(bill =>
                TrainingInBillMapper.MapToDAL(bill)).ToList();
        }

        public async Task AddNewTrainingInBill(DTO.TrainingInBill dto)
        {
           await RepoDbSet.AddAsync(TrainingInBillMapper.Map(dto));
        }
    }
}