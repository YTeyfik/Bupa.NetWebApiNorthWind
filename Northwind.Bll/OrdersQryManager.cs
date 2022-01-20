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
    public class OrdersQryManager : BllBase<OrdersQry, DtoOrdersQry>, IOrdersQryService
    {
        public readonly IOrdersQryRepository OrdersQryRepository;
        public OrdersQryManager(IServiceProvider service) : base(service)
        {

        }

        public IQueryable OrdersQryReport()
        {
            return OrdersQryRepository.OrdersQryReport();
        }
    }
}
