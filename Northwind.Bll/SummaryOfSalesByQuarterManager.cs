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
    public class SummaryOfSalesByQuarterManager : BllBase<SummaryOfSalesByQuarter, DtoSummaryOfSalesByQuarter>, ISummaryOfSalesByQuarterService
    {
        public readonly ISummaryOfSalesByQuarterRepository summaryOfSalesByQuarterRepository;
        public SummaryOfSalesByQuarterManager(IServiceProvider service) : base(service)
        {

        }

        public IQueryable SummaryOfSalesByQuarterReport()
        {
            return summaryOfSalesByQuarterRepository.SummaryOfSalesByQuarterReport();
        }
    }
}
