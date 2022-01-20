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
    public class CategorySalesFor1997Controller : ApiBaseController<ICategorySalesFor1997Service, CategorySalesFor1997, DtoCategorySalesFor1997>
    {
        public CategorySalesFor1997Controller(ICategorySalesFor1997Service categorySalesFor1997Service) : base(categorySalesFor1997Service)
        {

        }
    }
}
