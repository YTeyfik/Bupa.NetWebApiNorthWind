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
    public class ProductSalesFor1997Manager : BllBase<ProductSalesFor1997, DtoProductSalesFor1997>, IProductSalesFor1997Service
    {
        public readonly IProductSalesFor1997Repository productSalesFor1997Repository;
        public ProductSalesFor1997Manager(IServiceProvider service) : base(service)
        {

        }

        public IQueryable ProductSalesFor1997Report()
        {
            return productSalesFor1997Repository.ProductSalesFor1997Report();
        }
    }
}
