using FluentValidation;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Prueba_Tecnica.Models;
using Prueba_Tecnica.Validation;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();

builder.Services.AddDbContext<EmpleadoDBContext>(options =>
options.UseSqlServer(builder.Configuration.GetConnectionString("EmpleadoConnection")));

builder.Services.AddDbContext<AuthDbContext>(opciones => opciones.UseSqlServer("name=EmpleadoConnection"));


builder.Services.AddScoped<IValidator<Empleado>, EmpleadoValidator>();

//Authotization
builder.Services.AddIdentityApiEndpoints<IdentityUser>().AddEntityFrameworkStores<AuthDbContext>();
builder.Services.AddAuthorization();

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

app.MapGroup("/Empleados").MapIdentityApi<IdentityUser>();

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
