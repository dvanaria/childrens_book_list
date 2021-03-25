using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ChildrensBookList.Data;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using Newtonsoft.Json.Serialization;

namespace ChildrensBookList
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

            services.AddDbContext<ChildrensBookListContext>(opt => opt.UseSqlServer
                (Configuration.GetConnectionString("ChildrensBookListConnection")));


            services.AddControllers().AddNewtonsoftJson(s => {
            
                // this is to support PATCH requests
                s.SerializerSettings.ContractResolver = new CamelCasePropertyNamesContractResolver();
            });
 

            services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

            // This is where the actual repository is registered.
            // So wherever the repo interface is used to access the repository,
            // the registered repo implementation will be called.
            // This is used by the Dependency Injection system.
            
            //services.AddScoped<IChildrensBookListRepo, MockChildrensBookListRepo>();
            services.AddScoped<IChildrensBookListRepo, SqlChildrensBookListRepo>();

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "ChildrensBookList", Version = "v1" });
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            // This middle-ware needs to be installed in a particular order

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "ChildrensBookList v1"));
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
