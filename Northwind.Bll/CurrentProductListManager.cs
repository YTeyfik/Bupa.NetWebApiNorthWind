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
    public class CurrentProductListManager : BllBase<CurrentProductList, DtoCurrentProductList>, ICurrentProductListService
    {
        public readonly ICurrentProductListRepository currentProductListRepository;
        public CurrentProductListManager(IServiceProvider service) : base(service)
        {

        }

        public IQueryable CurrentProductListReport()
        {
            return currentProductListRepository.CurrentProductListReport();
        }
    }
}
