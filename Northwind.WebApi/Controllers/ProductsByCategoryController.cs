﻿using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Northwind.Entity.Dto;
using Northwind.Entity.Models;
using Northwind.Interface;
using Northwind.WebApi.Base;

namespace Northwind.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsByCategoryController : ApiBaseController<IProductsByCategoryService, ProductsByCategory, DtoProductsByCategory>
    {
        public ProductsByCategoryController(IProductsByCategoryService productsByCategoryService) : base(productsByCategoryService)
        {

        }
    }
}
