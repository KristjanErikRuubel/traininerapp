namespace DAL.App.EF.Mappers
{
    public static class TrainingInBillMapper
    {
        public static Domain.TrainingInBill Map(DTO.TrainingInBill tib)
        {
            var domain = new Domain.TrainingInBill
            {
                TrainingId = tib.TrainingId,
                BillId = tib.BillId,
            };
            
            return domain;
        }
        public static DTO.TrainingInBill MapToDAL(Domain.TrainingInBill tib)
        {
            var domain = new DTO.TrainingInBill
            {
                TrainingId = tib.TrainingId,
                BillId = tib.BillId,
            };
            
            return domain;
        }
    }
}