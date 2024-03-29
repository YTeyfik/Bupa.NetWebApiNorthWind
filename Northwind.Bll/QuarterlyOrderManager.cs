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
    public class QuarterlyOrderManager : BllBase<QuarterlyOrder, DtoQuarterlyOrder>, IQuarterlyOrderService
    {
        public readonly IQuarterlyOrderRepository quarterlyOrderRepository;
        public QuarterlyOrderManager(IServiceProvider service) : base(service)
        {

        }

        public IQueryable QuarterlyOrderReport()
        {
            return quarterlyOrderRepository.QuarterlyOrderReport();
        }
    }
}
