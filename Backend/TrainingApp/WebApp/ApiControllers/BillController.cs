using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Contracts.BLL.App;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using DAL.App.EF;
using Domain;

namespace WebApp.ApiControllers
{
    
    [Route("api/[controller]")]
    [ApiController]
    public class BillController : ControllerBase
    {
        private readonly IAppBLL _bll;

        public BillController(IAppBLL bll)
        {
            _bll = bll;
        }

        // GET: api/Bill
        [HttpGet]
        public Task<ActionResult<IEnumerable<Bill>>> GetBills()
        {
            return null;
        }

        // GET: api/Bill/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Bill>> GetBill(Guid id)
        {
            return null;
        }

        // PUT: api/Bill/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPut("{id}")]
        public Task<IActionResult> PutBill(Guid id, Bill bill)
        {
            return null;
        }

        // POST: api/Bill
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPost]
        public Task<ActionResult<Bill>> PostBill(Bill bill)
        {
            return null;
        }

        // DELETE: api/Bill/5
        [HttpDelete("{id}")]
        public  Task<ActionResult<Bill>> DeleteBill(Guid id)
        {
            return null;
        }

        private bool? BillExists(Guid id)
        {
            return null;
        }
    }
}
