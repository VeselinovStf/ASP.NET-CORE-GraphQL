﻿using CarvedRock.Api.GraphQL;
using CarvedRock.Data;
using CarvedRock.Data.Abstraction;
using CarvedRock.Data.Repositories;
using CarvedRock.Models;
using GraphQL;
using GraphQL.Server;
using GraphQL.Server.Ui.Playground;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace CarvedRock.Api
{
    public class Startup
    {
        private readonly IConfiguration _config;
        private readonly IWebHostEnvironment _env;

        public Startup(IConfiguration config, IWebHostEnvironment env)
        {
            _config = config;
            _env = env;
        }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc();
            services.AddDbContextPool<CarvedRockDbContext>(options =>
                options.UseSqlServer(_config["ConnectionStrings:CarvedRock"]));

            services.AddScoped<ProductRepository>();

            services.AddScoped<IDependencyResolver>(s => new FuncDependencyResolver(s.GetRequiredService));
            services.AddScoped<CarvedRockSchema>();

            services.AddGraphQL(o => { o.ExposeExceptions = true; })
                .AddGraphTypes(ServiceLifetime.Scoped)
                .AddDataLoader();

            services.AddScoped<IRepository<Product>, ProductRepository>();
            services.AddScoped<IRepository<ProductReview>, ProductReviewRepository>();
        }

        public void Configure(IApplicationBuilder app, CarvedRockDbContext dbContext)
        {
            app.UseGraphQL<CarvedRockSchema>();
            app.UseGraphQLPlayground(new GraphQLPlaygroundOptions());

            dbContext.Seed();
        }
    }
}