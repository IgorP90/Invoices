using System;

namespace Invoices
{
    public class Invoice
    {
        public DateTime DateCreation { get; set; }
        public long InvoiceNumber { get; set; }
        public byte InvoiceProcessingStatus { get; set; }
        public double InvoiceAmount { get; set; }
        public byte InvoicePaymentMethod { get; set; }
    }
}
