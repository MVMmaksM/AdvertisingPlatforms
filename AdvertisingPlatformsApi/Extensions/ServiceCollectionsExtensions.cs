using Application.Interfaces;
using Application.Services;

namespace AdvertisingPlatformsApi.Extensions;

public static class ServiceCollectionsExtensions
{
    /// <summary>
    /// метод расширения для добавления сервисов
    /// </summary>
    /// <param name="builder"></param>
    /// <returns></returns>
    public static WebApplicationBuilder AddAppServices(this WebApplicationBuilder builder)
    {
        builder.Services.AddTransient<IAdveristingPlatformsService, AdveristingPlatformsService>();
        builder.Services.AddTransient<IValidatorService, ValidatorService>();
        builder.Services.AddSingleton<IStorageService, MemoryStorageService>();
        return builder;
    }
}