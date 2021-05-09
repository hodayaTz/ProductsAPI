using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using ProductList.BL;
using ProductList.DAL;
using ProductList.DAL.Models;
using Microsoft.EntityFrameworkCore;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProductsAPI
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
            services.AddControllers();

            // ��� ��� ������ ��� ���� ��� ������ 
            // ����� ��� ���� connection string 

            services.AddDbContext<ProductContext>(options => options.UseSqlServer(
             Configuration.GetSection("ConnectionStrings")["ProductConnection"]));

            services.AddScoped<IProductBL, ProductBL>(); 
            services.AddScoped<IProductDL,ProductDL>();

            // singlton ���� ���� ��� ����� �� ��� ��������� 
            // ��� ����� ���� ����� �� ���� ����� 
          //  services.AddSingleton<IDI, DI>();

            // ���� ���� ���� �� ���� 
            services.AddScoped<IDI, DI>();

          //  services.AddTransient<IDI, DI>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

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
