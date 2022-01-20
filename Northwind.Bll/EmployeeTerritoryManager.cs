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
    public class EmployeeTerritoryManager : BllBase<EmployeeTerritory, DtoEmployeeTerritory>, IEmployeeTerritoryService
    {
        public readonly IEmployeeTerritoryRepository EmployeeTerritoryRepository;
        public EmployeeTerritoryManager(IServiceProvider service) : base(service)
        {

        }

        public IQueryable EmployeeTerritoryReport()
        {
            return EmployeeTerritoryRepository.EmployeeTerritoryReport();
        }
    }
}
