using Microsoft.EntityFrameworkCore;
using PhoneBook.Core.Repositories;
using PhoneBook.Core.Services;
using PhoneBook.Core.UnitOfWorks;
using PhoneBook.Repository;
using PhoneBook.Repository.Repositories;
using PhoneBook.Repository.UnitOfWorks;
using PhoneBook.Service.Mapping;
using PhoneBook.Service.Services;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//Add SCOPE
builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();
builder.Services.AddScoped<IPhoneNumberRepository, PhoneNumberRepository>();
builder.Services.AddScoped<IPhoneNumberService, PhoneNumberService>();
builder.Services.AddScoped<IContactRepository, ContactRepository>();
builder.Services.AddScoped<IContactService, ContactService>();
builder.Services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));
builder.Services.AddScoped(typeof(IGenericService<>), typeof(GenericService<>));
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

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
