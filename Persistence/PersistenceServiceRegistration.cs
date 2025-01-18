using Application.Services.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Persistence.Contexts;
using Persistence.Repositories;

namespace Persistence;

public static class PersistenceServiceRegistration
{
    public static IServiceCollection AddPersistenceService(this IServiceCollection service,
        IConfiguration configuration)
    {
        service.AddDbContext<BaseDbContext>(options => options.UseSqlServer(configuration.GetConnectionString("RentACarDb")));
        service.AddScoped<IBrandRepository, BrandRepository>();
        service.AddScoped<ICarRepository, CarRepository>();
        service.AddScoped<IColorRepository, ColorRepository>();
        service.AddScoped<IFuelRepository, FuelRepository>();
        service.AddScoped<IModelRepository, ModelRepository>();
        service.AddScoped<ITransmissionRepository, TransmissionRepository>();
        service.AddScoped<ITypeRepository, TypeRepository>();

        return service;
    }
}