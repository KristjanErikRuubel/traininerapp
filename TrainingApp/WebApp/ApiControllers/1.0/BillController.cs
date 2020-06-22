using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Contracts.BLL.App;
using Domain;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PublicApi.DTO.v1;

namespace WebApp.ApiControllers._1._0
{
    
    [ApiVersion( "1.0" )]
    [Route("api/v{version:apiVersion}/[controller]")]
    [ApiController]
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    public class BillController : ControllerBase
    {
        private readonly IAppBLL _bll;

        public BillController(IAppBLL bll)
        {
            _bll = bll;
        }

        // GET: api/Bill/5
        [HttpGet("{id}")]
        public async Task<List<BillDTO>> GetBills(Guid id)
        {
            return await _bll.BillService.GetUserBills(id);
        }



        // POST: api/Bill
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPost]
        public Task PostBill(NewBillDTO bill)
        {
            return _bll.BillService.CreatInvoice(bill);
        }

        // DELETE: api/Bill/5
        [HttpDelete("{id}")]
        public  Task DeleteBill(Guid id)
        {
            return _bll.BillService.RemoveBill(id);
        }

    }
}
