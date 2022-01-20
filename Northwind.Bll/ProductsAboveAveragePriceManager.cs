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
    public class ProductsAboveAveragePriceManager : BllBase<ProductsAboveAveragePrice, DtoProductsAboveAvaragePrice>, IProductsAboveAveragePriceService
    {
        public readonly IProductsAboveAveragePriceRepository productsAboveAveragePriceRepository;
        public ProductsAboveAveragePriceManager(IServiceProvider service) : base(service)
        {

        }

        public IQueryable ProductsAboveAveragePriceReport()
        {
            return productsAboveAveragePriceRepository.ProductsAboveAveragePriceReport();
        }
    }
}
