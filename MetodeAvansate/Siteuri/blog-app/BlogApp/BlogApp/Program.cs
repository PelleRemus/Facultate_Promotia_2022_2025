﻿using BlogApp.Models;
using BlogApp.Repositories;
using BlogApp.Services;
using BlogApp.Validations;
using FluentValidation;
using Microsoft.EntityFrameworkCore;

namespace BlogApp
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            string policyName = "localhostPolicy";
            builder.Services.AddCors(options =>
            {
                options.AddPolicy(name: policyName,
                                    policy =>
                                    {
                                        policy.WithOrigins("http://localhost:4200");
                                        policy.WithMethods("GET", "POST", "PUT", "DELETE", "HEAD", "OPTIONS");
                                        policy.WithHeaders("Access-Control-Allow-Headers", "Origin", "Accept", "X-Requested-With", "Content-Type", "Access-Control-Request-Method", "Access-Control-Request-Headers");
                                    }
                                 );
            });

            builder.Services.AddDbContext<DatabaseContext>(options =>
            // Daca nu va merge SQL Server
            //    options.UseInMemoryDatabase("blogDatabase"));
                options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnectionString")));

            // Add services to the container.
            builder.Services.AddScoped<IArticlesRepository, ArticlesRepository>();
            builder.Services.AddScoped<IUsersRepository, UsersRepository>();
            builder.Services.AddScoped<IArticlesService, ArticlesService>();
            builder.Services.AddScoped<IUsersService, UsersService>();
            builder.Services.AddScoped<AbstractValidator<User>, UserValidator>();

            builder.Services.AddControllers()
                .AddNewtonsoftJson(options =>
                    options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore
                );
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();
            app.UseCors(policyName);

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}