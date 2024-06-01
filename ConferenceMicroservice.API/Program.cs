using Microsoft.EntityFrameworkCore;

using ConferenceMicroservice.Persistence;

var builder = WebApplication.CreateBuilder(args);
var configuration = builder.Configuration;

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<ConferenceMicroserviceDbContext>(options =>
{
    options.UseSqlServer(configuration.GetConnectionString(nameof(ConferenceMicroserviceDbContext)));
});

var app = builder.Build();

app.UseSwagger();
app.UseSwaggerUI();

app.Run();
