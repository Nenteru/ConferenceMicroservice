using ConferenceMicroservice.Application.Services;
using ConferenceMicroservice.Core.Interfaces;
using ConferenceMicroservice.Persistence;
using ConferenceMicroservice.Persistence.Repositories;
using Microsoft.EntityFrameworkCore;



var builder = WebApplication.CreateBuilder(args);
var configuration = builder.Configuration;

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<ConferenceMicroserviceDbContext>(options =>
{
    options.UseSqlServer(configuration.GetConnectionString(nameof(ConferenceMicroserviceDbContext)));
});

builder.Services.AddScoped<IUserService, UserService>();
builder.Services.AddScoped<IUsersRepository, UsersRepository>();

var app = builder.Build();

app.UseSwagger();
app.UseSwaggerUI();

app.Run();
