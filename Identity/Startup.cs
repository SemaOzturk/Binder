// Copyright (c) Brock Allen & Dominick Baier. All rights reserved.
// Licensed under the Apache License, Version 2.0. See LICENSE in the project root for license information.


using System.Net;


using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Sparrow.Application.Entities.DbEntities;
using Sparrow.Application.Repositories;
using Sparrow.Application.Services;

namespace Identity
{
    public class Startup
    {
        public IWebHostEnvironment Environment { get; }

        public Startup(IWebHostEnvironment environment)
        {
            Environment = environment;
        }

        public void ConfigureServices(IServiceCollection services)
        {
            // uncomment, if you want to add an MVC-based UI
            //services.AddControllersWithViews();

            services.AddDbContext<DbContext, SparrowDbContext>(x => x.UseSqlServer("Data Source=.;Initial Catalog=Sparrow;Integrated Security=True"));
            services.AddScoped<IRepository<UserDbEntity>, BaseRepository<UserDbEntity>>();
            services.AddCors();
            var builder = services.AddIdentityServer(options =>
                    {
                        options.UserInteraction.LoginUrl = "http://192.168.10.38:3000/login";
                        options.UserInteraction.LogoutUrl = "http://192.168.10.38:3000/login";
                    })
                .AddInMemoryIdentityResources(Config.Ids)
                .AddInMemoryApiResources(Config.Apis)
                .AddInMemoryClients(Config.Clients).AddResourceOwnerValidator<PasswordValidator>().AddDeveloperSigningCredential().AddProfileService<ProfileService>();
            services.AddScoped<IUserService, UserService>();

            // not recommended for production - you need to store your key material somewhere secure
            builder.AddDeveloperSigningCredential();
        }

        public void Configure(IApplicationBuilder app)
        {
            if (Environment.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                Microsoft.IdentityModel.Logging.IdentityModelEventSource.ShowPII = true;
            }

            app.UseCors(x => x.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader());
            // uncomment if you want to add MVC
            //app.UseStaticFiles();
            //app.UseRouting();
            app.Use(((context, func) => {
                context.Response.Headers["Access-Control-Allow-Origin"] = "*";
                return func.Invoke();
            }));
            app.UseIdentityServer();

            // uncomment, if you want to add MVC
            //app.UseAuthorization();
            //app.UseEndpoints(endpoints =>
            //{
            //    endpoints.MapDefaultControllerRoute();
            //});
        }
    }
}
