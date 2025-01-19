using Application;
using Core.CrossCuttingConcerns.Exceptions.Extensions;
using Persistence;
using Scalar.AspNetCore;

var builder = WebApplication.CreateBuilder(args);


builder.Services.AddControllers();
builder.Services.AddApplicationServices();
builder.Services.AddPersistenceService(builder.Configuration);
//builder.Services.AddDistributedMemoryCache();
builder.Services.AddStackExchangeRedisCache(opt => opt.Configuration = "localhost:6379");
builder.Services.AddOpenApi();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
    app.MapScalarApiReference(options =>
    {
        options
            .WithTitle("RentACar")
            .WithTheme(ScalarTheme.Mars);
    });
}

//if (app.Environment.IsProduction())
    app.ConfigureCustomExceptionMiddleware();



app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
