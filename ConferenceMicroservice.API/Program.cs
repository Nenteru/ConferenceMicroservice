using ConferenceMicroservice.Application.Services;
using ConferenceMicroservice.Core.Interfaces;
using ConferenceMicroservice.Persistence;
using ConferenceMicroservice.Persistence.Repositories;
using Microsoft.EntityFrameworkCore;



var builder = WebApplication.CreateBuilder(args);
var configuration = builder.Configuration;

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<ConferenceMicroserviceDbContext>(options =>
{
    options.UseSqlServer(configuration.GetConnectionString(nameof(ConferenceMicroserviceDbContext)));
});

builder.Services.AddScoped<IUsersService, UserService>();
builder.Services.AddScoped<IUsersRepository, UsersRepository>();
builder.Services.AddScoped<IConferencesService, ConferencesService>();
builder.Services.AddScoped<IConferencesRepository, ConferencesRepository>();


var app = builder.Build();

if(app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();

app.Run();
