using System;
using System.Collections.Generic;

namespace Invoices
{
    interface IRepository : IDisposable
    {
        IEnumerable<Invoice> GetAll();
        IEnumerable<Invoice> GetById(long id);
        void Add(List<Invoice> invoice);
        void Change(List<Invoice> invoice, long id);
        void Delete(long id);
        void Save();
    }
}
