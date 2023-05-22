using App.Application;
using App.Application.Features.Tasks.CQRS.Handlers;
using App.Application.Profiles;
using App.Persistence;
using MediatR;
using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddAutoMapper(typeof(Program));
builder.Services.AddAutoMapper(typeof(MappingProfile));
builder.Services.AddMediatR(typeof(Program));
builder.Services.AddMediatR(typeof(GetUserTaskListQueryHandler).Assembly);

// Add services to the container.
builder.Services.AddControllers();
builder.Services.ConfigurePersistenceServices(builder.Configuration);

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

// app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();