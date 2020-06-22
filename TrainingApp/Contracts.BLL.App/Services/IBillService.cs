using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using PublicApi.DTO.v1;

namespace Contracts.BLL.App.Services
{
    public interface IBillService
    {
        public Task<List<BillDTO>> GetUserBills(Guid UserId);
        public Task CreatInvoice(NewBillDTO dto);

        public Task RemoveBill(Guid Id);
        
    }
}