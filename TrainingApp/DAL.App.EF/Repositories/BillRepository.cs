using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Contracts.DAL.App.Repositories;
using DAL.App.EF.Mappers;
using ee.itcollege.krruub.DAL.Base.EF.Mappers;
using ee.itcollege.krruub.DAL.Base.EF.Repositories;
using Microsoft.EntityFrameworkCore;
using Bill = DAL.App.DTO.Bill;

namespace DAL.App.EF.Repositories
{
    public class BillRepository  : EFBaseRepository<AppDbContext, Domain.Bill, DAL.App.DTO.Bill>, IBillRepository
    {
        public BillRepository(AppDbContext dbContext) : base(dbContext, new BaseDALMapper<Domain.Bill, DAL.App.DTO.Bill>())
        {
        }
        public async Task<IEnumerable< DAL.App.DTO.Bill>> AllAsync(Guid? userId = null)
        {
            return (await RepoDbSet.Where(o => o.Id == userId).ToListAsync()).Select(domainBill => Mapper.Map(domainBill));
        }

        public async Task< DAL.App.DTO.Bill> FirstOrDefaultAsync(Guid id, Guid? userId = null)
        {
            var query = RepoDbSet.Where(a => a.Id == id).AsQueryable();
            if (userId != null)
            {
                query = query.Where(a => a.Id == userId);
            }

            return Mapper.Map(await query.FirstOrDefaultAsync());
        }

        public async Task<bool> ExistsAsync(Guid id, Guid? userId = null)
        {
            if (userId == null)
            {
                return await RepoDbSet.AnyAsync(a => a.Id == id);
            }

            return await RepoDbSet.AnyAsync(a => a.Id == id && a.Id == userId);
        }

        public async Task DeleteAsync(Guid id, Guid? userId = null)
        {
            var bill = await FirstOrDefaultAsync(id, userId);
            base.Remove(bill);
        }
        public Bill AddNewBill(DAL.App.DTO.Bill bill)
        {
            var domain = RepoDbSet.AddAsync( BillMapper.MapToDomain(bill)).Result.Entity;
            
            return BillMapper.Map((domain));

        }

        public async Task<IEnumerable<Bill>> GetUserBills(Guid userId)
        {
            return (await RepoDbSet.AsQueryable().Where(b => b.AppUserId.Equals(userId)).ToListAsync()).Select(domainBill => BillMapper.Map(domainBill));
        }
    }
}