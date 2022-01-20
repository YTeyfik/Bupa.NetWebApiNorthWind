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
    public class CustomerAndSuppliersByCityManager : BllBase<CustomerAndSuppliersByCity, DtoCustomerAndSuppliersByCity>, ICustomerAndSuppliersByCityService
    {
        public readonly ICustomerAndSuppliersByCityRepository CustomerAndSuppliersByCityRepository;
        public CustomerAndSuppliersByCityManager(IServiceProvider service) : base(service)
        {

        }

        public IQueryable CustomerReport()
        {
            return CustomerAndSuppliersByCityRepository.CustomerAndSuppliersByCityReport();
        }
    }
}
