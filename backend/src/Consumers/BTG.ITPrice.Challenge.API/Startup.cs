

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
using Refit;
using System;
using System.Text.Json.Serialization;

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

            services.AddEndpointsApiExplorer();
            services.AddSwaggerGen();
            services.AddControllersWithViews()
                .AddJsonOptions(options =>
                    {
                        options.JsonSerializerOptions.Converters.Add(new JsonStringEnumConverter());
                    });

            services.AddScoped<IGithubReposService, GithubReposService>();
            services.AddScoped<IGithubReposRepository, GithubReposRepository>();

            var server = Configuration["DatabaseServer"] ?? "";
            var port = Configuration["DatabasePort"] ?? "";
            var user = Configuration["DatabaseUser"] ?? "";
            var password = Configuration["DatabasePassword"] ?? "";
            var databaseName = Configuration["DatabaseName"] ?? "";

            var connectionString = Configuration.GetConnectionString("Main");

            if (!string.IsNullOrEmpty(server) &&
                !string.IsNullOrEmpty(port) &&
                !string.IsNullOrEmpty(user) &&
                !string.IsNullOrEmpty(password) &&
                !string.IsNullOrEmpty(databaseName))
            {
                connectionString = $"Server={server};Database={databaseName};Port={port};User Id={user};Password={password}";
            }
    
            services.AddDbContext<DatabaseContext>(
                options => options.UseNpgsql(connectionString)
            );

            services.AddRefitClient<IGithubAPIRepository>().ConfigureHttpClient(c =>
            {
                c.BaseAddress = new Uri("https://api.github.com/");
            });

        }
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();

                app.UseSwagger();

                app.UseSwaggerUI();
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
