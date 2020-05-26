using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Contracts.BLL.App.Services;
using Contracts.DAL.App;
using Contracts.DAL.App.Repositories;
using Domain;
using ee.itcollege.krruub.BLL.Base.Mappers;
using ee.itcollege.krruub.BLL.Base.Services;
using PublicApi.DTO.v1;
namespace BLL.App.Services
{
    public class BillService : BaseEntityService<IBillRepository, IAppUnitOfWork, DAL.App.DTO.Bill, BLL.App.DTO.Bill>, IBillService
    {
        public BillService(IAppUnitOfWork unitOfWork)
            : base(unitOfWork, new IdentityMapper< DAL.App.DTO.Bill, BLL.App.DTO.Bill>(), unitOfWork.BillRepository)
        { }

        public async Task CreatInvoice(BillDTO dto)
        {
            var user = await ServiceUnitOfWork.AccountRepository.FindAsync(dto.UserBill.Id);
            var trainings = new List<DAL.App.DTO.Training>();
            foreach (var trainingId in dto.Trainings)
            {
                var trainingInBill = new DAL.App.DTO.TrainingInBill()
                {
                    AppUserId = user.Id,
                    //TrainingId = trainingId,
                };
                ServiceUnitOfWork.TrainingInBillRepository.Add(trainingInBill);
                var training = await ServiceUnitOfWork.TrainingRepository.FindAsync(trainingId);
                trainings.Add(training);
            }
           
            var bill = new DAL.App.DTO.Bill()
            {
                AppUserId = dto.UserBill.Id,
                Deadline = dto.Deadline,
                Trainings = null,
                Total = Int16.Parse(dto.Total),
                User = user
            };
            ServiceRepository.Add(bill);
            await ServiceUnitOfWork.SaveChangesAsync();
        }

        public async Task<List<BillDTO>> GetUserBills(Guid UserId)
        {

            var bills = await ServiceRepository.GetUserBills(UserId);
            var billDtos  = new List<BillDTO>();
            foreach (var bill in bills)
            {
                var billDto = new BillDTO()
                {
                    Deadline = bill.Deadline,
                };
                billDtos.Add(billDto);
            }
            return billDtos;
        }

        private List<TrainingDTO> getTrainingsWithDetailForBill(List<Training> billTrainings)
        {
            return null;
        }
    }
}