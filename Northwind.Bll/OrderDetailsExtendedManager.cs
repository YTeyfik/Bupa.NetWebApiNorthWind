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
    public class OrderDetailsExtendedManager : BllBase<OrderDetailsExtended, DtoOrderDetailsExtended>, IOrderDetailsExtendedService
    {
        public readonly IOrderDetailsExtendedRepository OrderDetailsExtendedRepository;
        public OrderDetailsExtendedManager(IServiceProvider service) : base(service)
        {

        }

        public IQueryable OrderDetailsExtendedReport()
        {
            return OrderDetailsExtendedRepository.OrderDetailsExtendedReport();
        }
    }
}
