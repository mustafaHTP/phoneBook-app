using Autofac;
using Autofac.Extensions.DependencyInjection;
using FluentValidation.AspNetCore;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PhoneBook.API.Filters;
using PhoneBook.API.Middlewares;
using PhoneBook.API.Modules;
using PhoneBook.Core.Repositories;
using PhoneBook.Core.Services;
using PhoneBook.Core.UnitOfWorks;
using PhoneBook.Repository;
using PhoneBook.Repository.Repositories;
using PhoneBook.Repository.UnitOfWorks;
using PhoneBook.Service.Mapping;
using PhoneBook.Service.Services;
using PhoneBook.Service.Validations;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//Memory Cache
builder.Services.AddMemoryCache();

//Validate Filter Attribute
//Add FluentValidation
builder.Services.AddControllers(options => { options.Filters.Add(new ValidateFilterAttribute()); })
    .AddFluentValidation(x => x.RegisterValidatorsFromAssemblyContaining<PhoneNumberDtoValidator>());
builder.Services.AddControllers(options => { options.Filters.Add(new ValidateFilterAttribute()); })
    .AddFluentValidation(x => x.RegisterValidatorsFromAssemblyContaining<ContactDtoValidator>());

//Suppress Default Filter to Show Validate Filter
builder.Services.Configure<ApiBehaviorOptions>(options =>
{
    options.SuppressModelStateInvalidFilter = true;
});

//Add SCOPE
builder.Services.AddScoped(typeof(NotFoundFilter<>));

//AutoMapper
builder.Services.AddAutoMapper(typeof(MapProfile));

//Sql Connection
builder.Services.AddDbContext<AppDbContext>(x =>
{
    x.UseSqlServer(builder.Configuration.GetConnectionString("SqlConnection"), options =>
    {
        //not type-safety
        //options.MigrationsAssembly("PhoneBook.Repository");
        options.MigrationsAssembly(Assembly.GetAssembly(typeof(AppDbContext)).GetName().Name);
    });
});


//Autofac
builder.Host.UseServiceProviderFactory(new AutofacServiceProviderFactory());
builder.Host.ConfigureContainer<ContainerBuilder>(containerBuilder => containerBuilder.RegisterModule(new RepoServiceModule()));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

//Exception Middleware
app.UseCustomException();

app.UseAuthorization();

app.MapControllers();

app.Run();
