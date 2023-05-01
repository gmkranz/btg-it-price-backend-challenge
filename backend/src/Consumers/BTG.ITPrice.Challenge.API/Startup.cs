

using Application;
using Application.Services.Contracts;
using Application.Services.Impl;
using Data;
using Data.Data.GithubReposRepository.Impl;
using Domain.Ports;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Options;
using Microsoft.OpenApi.Models;
using Refit;
using System;

namespace BTG.ITPrice.Challenge.API
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {

            services.AddControllers();
            services.AddScoped<IGithubReposService, GithubReposService>();
            services.AddScoped<IGithubReposRepository, GithubReposRepository>();

            services.AddDbContext<DatabaseContext>(
                options => options.UseNpgsql(Configuration.GetConnectionString("DefaultConnection"))
    );


            services.AddRefitClient<IGithubAPIRepository>().ConfigureHttpClient(c =>
            {
                c.BaseAddress = new Uri("https://api.github.com/");
            });

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "Btg-It-Price", Version = "v1" });
            });
        }
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "Btg-It-Price v1"));
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
