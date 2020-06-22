using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Contracts.DAL.App.Repositories;
using DAL.App.DTO;
using ee.itcollege.krruub.DAL.Base.EF.Mappers;
using ee.itcollege.krruub.DAL.Base.EF.Repositories;
using Microsoft.EntityFrameworkCore;

namespace DAL.App.EF.Repositories
{
    public class CommentRepository: EFBaseRepository<AppDbContext, Domain.Comment, DAL.App.DTO.Comment>, ICommentRepository
    {
        public CommentRepository(AppDbContext dbContext) : base(dbContext, new BaseDALMapper<Domain.Comment, DAL.App.DTO.Comment>())
        {
        }

        public Task<IEnumerable<Comment>> AllAsync(Guid? userId = null)
        {
            throw new NotImplementedException();
        }

        public Task<Comment> FirstOrDefaultAsync(Guid id, Guid? userId = null)
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

        public async Task<List<Comment>> GetAllByTrainingId(Guid trainingId)
        {
            return (await RepoDbSet.AsQueryable().Where(c => c.TrainingId == trainingId).ToListAsync()).Select(c => Mapper.Map(c)).ToList();
        }
    }
}