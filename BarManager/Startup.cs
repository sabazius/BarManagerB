using BarManager.BL.Interfaces;
using BarManager.BL.Services;
using BarManager.DL.Interfaces;
using BarManager.DL.Repositories.InMemoryRepos;
using BarManager.Extensions;
using FluentValidation.AspNetCore;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using Serilog;

namespace BarManager
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
            services.AddSingleton(Log.Logger);

            services.AddAutoMapper(typeof(Startup));
            
            services.AddSingleton<IShiftRepository, ShiftInMemoryRepository>();
            services.AddSingleton<IOrderItemRepository, OrderItemInMemoryRepository>();
            services.AddSingleton<IBillRepository, BillInMemoryRepository>();
            services.AddSingleton<ITagRepository, TagInMemoryRepository>();
            services.AddSingleton<IEmployeeRepository, EmployeesInMemoryRepository>();
            services.AddSingleton<IClientRepository, ClientInMemoryRepository>();
            services.AddSingleton<IProductsRepository, ProductsInMemoryRepository>();

            services.AddSingleton<IClientService, ClientService>();
            services.AddSingleton<ITagService, TagService>();
            services.AddSingleton<IOrderItemService, OrderItemService>();
            services.AddSingleton<IEmployeeService, EmployeeService>();
            services.AddSingleton<IBillService, BillService>();
            services.AddSingleton<IProductsService, ProductsService>();
            services.AddSingleton<IShiftService, ShiftService>();

            services.AddControllers().AddFluentValidation(fv => fv.RegisterValidatorsFromAssemblyContaining<Startup>());

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "BarManager", Version = "v1" });
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, ILogger logger)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "BarManager v1"));
            }

            app.ConfigureExceptionHandler(logger);

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
