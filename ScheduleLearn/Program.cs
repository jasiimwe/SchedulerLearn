using Microsoft.EntityFrameworkCore;
using ScheduleLearnApi.Models.Persistent;
using ScheduleLearnApi.Controllers;
using ScheduleLearnApi.Models.Interfaces;
using ScheduleLearnApi.Services;
using ScheduleLearnApi.Models.Interfaces.Service;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddScoped<IAccount, AccountService>();
builder.Services.AddScoped<IDirector, DirectorService>();
builder.Services.AddScoped<IHealthCenter, HealthCenterService>();
builder.Services.AddScoped<IDivision, DivisionService>();
builder.Services.AddScoped<IWard, WardService>();
builder.Services.AddScoped<IUser, UserService>();
builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();
builder.Services.AddDbContext<SchedulerContext>(opt => opt.UseSqlite(builder.Configuration.GetConnectionString("DefaultConnection")));

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

//app.MapAccountEndpoints();



app.Run();
