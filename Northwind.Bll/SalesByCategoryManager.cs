﻿using Northwind.Bll.Base;
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
    public class SalesByCategoryManager : BllBase<SalesByCategory, DtoSalesByCategory>, ISalesByCategoryService
    {
        public readonly ISalesByCategoryRepository salesByCategoryRepository;
        public SalesByCategoryManager(IServiceProvider service) : base(service)
        {

        }

        public IQueryable SalesByCategoryReport()
        {
            return salesByCategoryRepository.SalesByCategoryReport();
        }
    }
}
