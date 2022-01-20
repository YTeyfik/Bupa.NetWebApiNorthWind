using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Northwind.Entity.Dto;
using Northwind.Entity.Models;
using Northwind.Interface;
using Northwind.WebApi.Base;

namespace Northwind.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductSalesFor1997Controller : ApiBaseController<IProductSalesFor1997Service, ProductSalesFor1997, DtoProductSalesFor1997>
    {
        public ProductSalesFor1997Controller(IProductSalesFor1997Service productSalesFor1997Service) : base(productSalesFor1997Service)
        {

        }
    }
}
