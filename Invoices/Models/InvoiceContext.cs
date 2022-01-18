using System.Data.Entity;

namespace Invoices.Models
{
    public class InvoiceContext : DbContext
    {
        public InvoiceContext() : base("DefaultConnection")
        { }

        public DbSet<Invoice> Invoices { get; set; }
    }
}
