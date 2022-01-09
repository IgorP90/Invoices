using System;
using System.Collections.Generic;

namespace Invoices
{
    interface IRepository<T> : IDisposable where T : class
    {
        IEnumerable<Invoice> GetAll();
        IEnumerable<Invoice> GetById(long id);
        void Add(List<Invoice> invoice);
        void Change(List<Invoice> invoice, long id);
        void Delete(long id);
    }
}
