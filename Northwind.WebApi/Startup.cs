using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using Northwind.Bll;
using Northwind.Dal.Abstract;
using Northwind.Dal.Concrete.EntityFramework.Context;
using Northwind.Dal.Concrete.EntityFramework.Repositorry;
using Northwind.Dal.Concrete.EntityFramework.UnitOfWork;
using Northwind.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Northwind.WebApi
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            #region JwtTokenService
            //JwtSecurityTokenHandler
            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme).AddJwtBearer(cfg =>
            {
                cfg.SaveToken = true;
                cfg.RequireHttpsMetadata = false;

                cfg.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuer = true,
                    RoleClaimType = "Roles",
                    ClockSkew = TimeSpan.FromMinutes(5),
                    ValidateLifetime = true,
                    ValidIssuer = Configuration["Tokens:Issuer"],
                    ValidateAudience = true,
                    ValidAudience = Configuration["Tokens:Issuer"],//Configuration["Tokens:Audience"] bende token service ile token clientler ayný olduðundan Issuer key'ini kullandým
                    RequireSignedTokens = true,
                    RequireExpirationTime = true,
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(Configuration["Tokens:Key"]))
                };
            });
            #endregion

            #region ApplicationContext
            //db baðlantý birinci yöntem için geçerli 
            //services.AddDbContext<NORTHWNDContext>();
            //services.AddScoped<DbContext, NORTHWNDContext>();

            //db baðlantý 2. yöntem
            services.AddScoped<DbContext, NORTHWNDContext>();
            services.AddDbContext<NORTHWNDContext>(options => 
            {
                options.UseSqlServer(Configuration.GetConnectionString("SqlServer"), sqlOpt =>
                {
                    sqlOpt.MigrationsAssembly("Northwind.Dal");
                });
            });
            #endregion

            #region ServiceSection
            services.AddScoped<IOrderService, OrderManager>();
            services.AddScoped<ICustomerService, CustomerManager>();
            services.AddScoped<IUserService, UserManager>();
            services.AddScoped<IAlphabeticalListOfProductService, AlphabeticalListOfProductManager>();
            services.AddScoped<ICategoryService, CategoryManager>();
            services.AddScoped<ICategorySalesFor1997Service, CategorySalesFor1997Manager>();
            services.AddScoped<ICurrentProductListService, CurrentProductListManager>();
            services.AddScoped<ICustomerAndSuppliersByCityService, CustomerAndSuppliersByCityManager>();
            services.AddScoped<ICustomerCustomerDemoService, CustomerCustomerDemoManager>();
            services.AddScoped<ICustomerDemographicService, CustomerDemographicManager>();
            services.AddScoped<IEmployeeService, EmployeeManager>();
            services.AddScoped<IEmployeeTerritoryService, EmployeeTerritoryManager>();
            services.AddScoped<IInvoiceService, InvoiceManager>();
            services.AddScoped<IOrderDetailService, OrderDetailManager>();
            services.AddScoped<IOrderDetailsExtendedService, OrderDetailsExtendedManager>();
            services.AddScoped<IOrdersQryService, OrdersQryManager>();
            services.AddScoped<IOrderSubtotalService, OrderSubtotalManager>();
            services.AddScoped<IProductService, ProductManager>();
            services.AddScoped<IProductsAboveAveragePriceService, ProductsAboveAveragePriceManager>();
            services.AddScoped<IProductSalesFor1997Service, ProductSalesFor1997Manager>();
            services.AddScoped<IProductsByCategoryService, ProductsByCategoryManager>();
            services.AddScoped<IQuarterlyOrderService, QuarterlyOrderManager>();
            services.AddScoped<IRegionService, RegionManager>();
            services.AddScoped<ISalesByCategoryService, SalesByCategoryManager>();
            services.AddScoped<ISalesTotalsByAmountService, SalesTotalsByAmountManager>();
            services.AddScoped<IShipperService, ShipperManager>();
            services.AddScoped<ISummaryOfSalesByQuarterService, SummaryOfSalesByQuarterManager>();
            services.AddScoped<ISummaryOfSalesByYearService, SummaryOfSalesByYearManager>();
            services.AddScoped<ISupplierService, SupplierManager>();
            services.AddScoped<ITerritoryService, TerritoryManager>();
            #endregion

            #region RepositorySection
            services.AddScoped<IOrderRepository, OrderRepository>();
            services.AddScoped<ICustomerRepository, CustomerRepository>();
            services.AddScoped<IUserRepository,UserRepository>();
            services.AddScoped<IAlphabeticalListOfProductRepository, AlphabeticalListOfProductRepository>();
            services.AddScoped<ICategoryRepository, CategoryRepository>();
            services.AddScoped<ICategorySalesFor1997Repository, CategorySalesFor1997Repository>();
            services.AddScoped<ICurrentProductListRepository, CurrentProductListRepository>();
            services.AddScoped<ICustomerAndSuppliersByCityRepository, CustomerAndSuppliersByCityRepository>();
            services.AddScoped<ICustomerCustomerDemoRepository, CustomerCustomerDemoRepository>();
            services.AddScoped<ICustomerDemographicRepository, CustomerDemographicRepository>();
            services.AddScoped<IEmployeeRepository, EmployeeRepository>();
            services.AddScoped<IEmployeeTerritoryRepository, EmployeeTerritoryRepository>();
            services.AddScoped<IInvoiceRepository, InvoiceRepository>();
            services.AddScoped<IOrderDetailRepository, OrderDetailRepository>();
            services.AddScoped<IOrderDetailsExtendedRepository, OrderDetailsExtendedRepository>();
            services.AddScoped<IOrdersQryRepository, OrdersQryRepository>();
            services.AddScoped<IOrderSubtotalRepository, OrderSubtotalRepository>();
            services.AddScoped<IProductRepository, ProductRepository>();
            services.AddScoped<IProductsAboveAveragePriceRepository, ProductsAboveAveragePriceRepository>();
            services.AddScoped<IProductSalesFor1997Repository, ProductSalesFor1997Repository>();
            services.AddScoped<IProductsByCategoryRepository, ProductsByCategoryRepository>();
            services.AddScoped<IQuarterlyOrderRepository, QuarterlyOrderRepository>();
            services.AddScoped<IRegionRepository, RegionRepository>();
            services.AddScoped<ISalesByCategoryRepository, SalesByCategoryRepository>();
            services.AddScoped<ISalesTotalsByAmountRepository, SalesTotalsByAmountRepository>();
            services.AddScoped<IShipperRepository, ShipperRepository>();
            services.AddScoped<ISummaryOfSalesByQuarterRepository, SummaryOfSalesByQuarterRepository>();
            services.AddScoped<ISummaryOfSalesByYearRepository, SummaryOfSalesByYearRepository>();
            services.AddScoped<ISupplierRepository, SupplierRepository>();
            services.AddScoped<ITerritoryRepository, TerritoryRepository>();
            #endregion

            #region UnitOfWork
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            #endregion

            #region Cores Settings
            //services.AddCors(opt=> {
            //    opt.AddPolicy("CorsPlicy", 
            //        builder=> builder
            //        //.WithOrigins("www.api.com")
            //        .AllowAnyOrigin()
            //        //.WithMethods("GET","POST")
            //        .AllowAnyMethod()
            //        //.WithHeaders("accept","content-type")
            //        .AllowAnyHeader()
            //        //.AllowCredentials()
            //    );
            //});
            #endregion

            services.AddControllers();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "Northwind.WebApi", Version = "v1" });
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "Northwind.WebApi v1"));
            }

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
