using AppServices.Services;
using Domain.Service.Services;
using WebService.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();

builder.Services.ConfigureSqlContext(builder.Configuration);

builder.Services.ConfigureRepositoryManager();
builder.Services.ConfigureMapping();

builder.Services.AddAuthentication();
builder.Services.ConfigureJWT(builder.Configuration);
builder.Services.ConfigureIdentity();

builder.Services.ConfigureSwagger();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseAuthentication();
app.UseAuthorization();
app.MapControllers();
app.Run();
