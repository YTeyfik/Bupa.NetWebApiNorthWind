using Northwind.Bll.Base;
using Northwind.Dal.Abstract;
using Northwind.Entity.Dto;
using Northwind.Entity.Models;
using Northwind.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Northwind.Bll
{
    public class InvoiceManager : BllBase<Invoice, DtoInvoice>, IInvoiceService
    {
        public readonly IInvoiceRepository InvoiceRepository;
        public InvoiceManager(IServiceProvider service) : base(service)
        {

        }

        public IQueryable InvoiceReport()
        {
            return InvoiceRepository.InvoiceReport();
        }
    }
}
