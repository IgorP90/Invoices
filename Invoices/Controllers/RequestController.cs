using Invoices;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;

namespace TestTaskForD_Studio.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class RequestController : ControllerBase
    {
        IRepository<Invoice> db;

        public RequestController()
        {
            db = new Handler();
        }

        [HttpGet("/api/invoices")]
        public IEnumerable<Invoice> Get(string sortingParameter = "InvoiceNumber", bool isSortingDescending = false)
        {
            var n = db.GetAll();
            List<Invoice> s = n.ToList();
            return Sorting.Sort(s, sortingParameter, isSortingDescending);
        }

        [HttpGet("/api/invoices/{invoiceId}")]
        public IActionResult Get(long invoiceId)
        {
            var n = db.GetById(invoiceId);
            return new ObjectResult(db.GetById(invoiceId));
        }

        [HttpPost("/api/invoices")]
        public void Post([FromBody] List<Invoice> invoice)
        {
            db.Add(invoice);
        }

        [HttpPut("/api/invoices/{invoiceId}")]
        public void Put(long invoiceId, [FromBody] List<Invoice> invoice)
        {
            db.Change(invoice, invoiceId);
        }

        [HttpDelete("/api/invoices/{invoiceId}")]
        public void Delete(long invoiceId)
        {
            db.Delete(invoiceId);
        }
    }
}

