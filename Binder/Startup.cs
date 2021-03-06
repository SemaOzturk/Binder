using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Binder.Application.Entities.DbEntities;
using Binder.Application.Repositories;
using Binder.Application.Services;
using Binder.Application.Services.Interfaces;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.IdentityModel.Logging;

namespace Binder
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
            services.AddDbContext<DbContext,BinderDbContext>(x=>x.UseSqlServer("Data Source=.;Initial Catalog=Binder;Integrated Security=True"));
            services.AddScoped<IRepository<UserDbEntity>, BaseRepository<UserDbEntity>>();
            services.AddScoped<IRepository<CountryDbEntity>, BaseRepository<CountryDbEntity>>();
            services.AddScoped<IRepository<CitiesDbEntity>, BaseRepository<CitiesDbEntity>>();
            services.AddScoped<IRepository<StatesDbEntity>, BaseRepository<StatesDbEntity>>();
            services.AddScoped<IUserService, UserService>();
            services.AddScoped<IAdressService, AddressService>();
            services.AddCors();
            
            services.AddAutoMapper(typeof(MapperAutoProfile));
            services.AddAuthentication("Bearer").AddJwtBearer("Bearer", options =>
            {
                options.Authority = "http://192.168.10.38:5051";
                options.RequireHttpsMetadata = false;
                options.Audience = "binderapi";
                
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                IdentityModelEventSource.ShowPII = true;
            }

            app.UseHttpsRedirection();

            app.UseRouting();
            app.UseAuthentication();
            app.UseAuthorization();
            app.UseCors(x => x.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader());

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
