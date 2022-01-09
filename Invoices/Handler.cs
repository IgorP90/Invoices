using CsvHelper;
using CsvHelper.Configuration;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;

namespace Invoices
{
    public class Handler : IRepository<Invoice>, IDisposable
    {
        private static string fileName = "Invoices.csv";
        private bool disposed = false;

        public IEnumerable<Invoice> GetAll()
        {

            var lines = File.ReadLines(fileName, Encoding.UTF8);

            return from line in lines
                   let fields = line.Split(";")
                   select new Invoice
                   {
                       DateCreation = DateTime.Parse(fields[0]),
                       InvoiceNumber = long.Parse(fields[1]),
                       InvoiceProcessingStatus = byte.Parse(fields[2]),
                       InvoiceAmount = double.Parse(fields[3], CultureInfo.InvariantCulture),
                       InvoicePaymentMethod = byte.Parse(fields[4])
                   };

        }

        public IEnumerable<Invoice> GetById(long id)
        {
            var lines = File.ReadLines(fileName, Encoding.UTF8);

            return from line in lines
                   let fields = line.Split(";")
                   where long.Parse(fields[1]) == id
                   select new Invoice
                   {
                       DateCreation = DateTime.Parse(fields[0]),
                       InvoiceNumber = long.Parse(fields[1]),
                       InvoiceProcessingStatus = byte.Parse(fields[2]),
                       InvoiceAmount = double.Parse(fields[3], CultureInfo.InvariantCulture),
                       InvoicePaymentMethod = byte.Parse(fields[4])
                   };
        }

        public void Add(List<Invoice> invoice)
        {
            invoice.ForEach(i => i.DateCreation = DateTime.Now) ;

            long maxId = GetAll().Max(x => x.InvoiceNumber+1);
            invoice.ForEach(i => i.InvoiceNumber = maxId);
          
            var config = new CsvConfiguration(CultureInfo.InvariantCulture)
            {
                HasHeaderRecord = false,
            };
            using (var stream = File.Open(fileName, FileMode.Append))
            using (var writer = new StreamWriter(stream))
            using (var csv = new CsvWriter(writer, config))
            {
                csv.WriteRecords(invoice);
            }
        }

        public void Change(List<Invoice> invoice, long id) // --
        {
            var records = GetById(id);
            using (var writer = new StreamWriter(fileName))
            {
                using (var csv = new CsvWriter(writer, CultureInfo.InvariantCulture))
                {
                    csv.WriteField(invoice);
                }
            }

        }

        public void Delete(long id) // --
        {
            var records = GetAll();

            using (var stream = File.Open(fileName, FileMode.Append))
            using (var writer = new StreamWriter(stream))
            using (var csv = new CsvWriter(writer, CultureInfo.InvariantCulture))
            {
                csv.WriteHeader<Invoice>();
                csv.NextRecord();
                foreach (var record in records)
                {
                    if (record.InvoiceNumber != id)
                    {
                        csv.WriteField(record);
                        csv.NextRecord();
                    }
                }
            }
        }

        private void Clean(bool clean)
        {
            if (!disposed)
            {
                if (clean)
                { 
                }
            }
            disposed = true;
        }
        public void Dispose()
        {
            GC.SuppressFinalize(this);    
        }

        ~Handler()
        {
            Clean(false);
        }
    }
}
