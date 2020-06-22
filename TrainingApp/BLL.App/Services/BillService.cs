using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Contracts.BLL.App.Services;
using Contracts.DAL.App;
using Contracts.DAL.App.Repositories;
using Domain;
using ee.itcollege.krruub.BLL.Base.Mappers;
using ee.itcollege.krruub.BLL.Base.Services;
using Microsoft.AspNetCore.Mvc;
using PublicApi.DTO.v1;
using Bill = DAL.App.DTO.Bill;
using TrainingInBill = DAL.App.DTO.TrainingInBill;

namespace BLL.App.Services
{
    public class BillService : BaseEntityService<IBillRepository, IAppUnitOfWork, DAL.App.DTO.Bill, BLL.App.DTO.Bill>, IBillService
    {
        public BillService(IAppUnitOfWork unitOfWork)
            : base(unitOfWork, new IdentityMapper< DAL.App.DTO.Bill, BLL.App.DTO.Bill>(), unitOfWork.BillRepository)
        { }

        public async Task CreatInvoice(NewBillDTO dto)
        {
            var user = await ServiceUnitOfWork.AccountRepository.FindAsync(dto.UserBill.Id);
            var trainings = new List<DAL.App.DTO.Training>();          
            var bill = new Bill()
             {
                 AppUserId = dto.UserBill.Id,
                 Deadline = dto.Deadline,
                 Total = dto.Total,
             };
             bill = ServiceRepository.AddNewBill(bill);
             await ServiceUnitOfWork.SaveChangesAsync();
            foreach (var trainingdto in dto.Trainings)
            {
                var trainingInBill = new TrainingInBill()
                {
                    BillId = bill.Id,
                    TrainingId = trainingdto.Id
                };
                await ServiceUnitOfWork.TrainingInBillRepository.AddNewTrainingInBill(trainingInBill);
                var training = await ServiceUnitOfWork.TrainingRepository.FindAsync(trainingdto.Id);
                trainings.Add(training);
            }
           
  
            await ServiceUnitOfWork.SaveChangesAsync();
        }

        public async Task<List<BillDTO>> GetUserBills(Guid UserId)
        {

            var bills = await ServiceRepository.GetUserBills(UserId);
            var billDtos  = new List<BillDTO>();



            foreach (var bill in bills)
            {  
                var trainingsInBills =  await ServiceUnitOfWork.TrainingInBillRepository.GetTrainingsInBill(bill.Id);
                var trainings = new List<TrainingDTO>();
                foreach (var trainingInBill in trainingsInBills)
                {
                    var training = await ServiceUnitOfWork.TrainingRepository.FirstOrDefaultAsync(trainingInBill.TrainingId);
                    var trainingDTO = new TrainingDTO()
                    {
                        TrainingDate = training.Start,
                        Description = training.Description
                    };
                    trainings.Add(trainingDTO);
                }
                
                var billDto = new BillDTO()
                {
                    Total = bill.Total,
                    Deadline = bill.Deadline,
                    Trainings = trainings
                };
                billDtos.Add(billDto);
            }
            return billDtos;
        }

        private List<TrainingDTO> getTrainingsWithDetailForBill(List<Training> billTrainings)
        {
            return null;
        }

        public async Task RemoveBill(Guid Id)
        {
            ServiceRepository.Remove(Id);
            await ServiceUnitOfWork.SaveChangesAsync();
        }
    }
}