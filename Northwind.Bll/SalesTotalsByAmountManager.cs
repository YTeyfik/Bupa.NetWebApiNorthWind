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
    public class SalesTotalsByAmountManager : BllBase<SalesTotalsByAmount, DtoSalesTotalsByAmount>, ISalesTotalsByAmountService
    {
        public readonly ISalesTotalsByAmountRepository salesTotalsByAmountRepository;
        public SalesTotalsByAmountManager(IServiceProvider service) : base(service)
        {

        }

        public IQueryable SalesTotalsByAmountReport()
        {
            return salesTotalsByAmountRepository.SalesTotalsByAmountReport();
        }
    }
}
