using System.Collections.Generic;
using System.Linq;

namespace Invoices
{
    public class Sorting
    {

        public static IEnumerable<Invoice> Sort(List<Invoice> invoices, string sortingParameter = "InvoiceNumber", bool isSortingDescending = false)
        {
            List<Invoice> ls = new List<Invoice>();

            if (isSortingDescending == false) //Ascending ^
            {
                if (sortingParameter == "DateCreation")
                {
                    ls = invoices.OrderBy(i => i.DateCreation).ToList();
                }
                else if (sortingParameter == "InvoiceNumber")
                {
                    ls = invoices.OrderBy(i => i.InvoiceNumber).ToList();
                }
                else if (sortingParameter == "InvoiceProcessingStatus")
                {
                    ls = invoices.OrderBy(i => i.InvoiceProcessingStatus).ToList();
                }
                else if (sortingParameter == "InvoiceAmount")
                {
                    ls = invoices.OrderBy(i => i.InvoiceAmount).ToList();
                }
                else if (sortingParameter == "InvoicePaymentMethod")
                {
                    ls = invoices.OrderBy(i => i.InvoicePaymentMethod).ToList();
                }
            }
            else if (isSortingDescending == true) //Descending v
            {
                if (sortingParameter == "DateCreation")
                {
                    ls = invoices.OrderByDescending(i => i.DateCreation).ToList();
                }
                else if (sortingParameter == "InvoiceNumber")
                {
                    ls = invoices.OrderByDescending(i => i.InvoiceNumber).ToList();
                }
                else if (sortingParameter == "InvoiceProcessingStatus")
                {
                    ls = invoices.OrderByDescending(i => i.InvoiceProcessingStatus).ToList();
                }
                else if (sortingParameter == "InvoiceAmount")
                {
                    ls = invoices.OrderByDescending(i => i.InvoiceAmount).ToList();
                }
                else if (sortingParameter == "InvoicePaymentMethod")
                {
                    ls = invoices.OrderByDescending(i => i.InvoicePaymentMethod).ToList();
                }
            }
            return ls;       
        }
    }
}
