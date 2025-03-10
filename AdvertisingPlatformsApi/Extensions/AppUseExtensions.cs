namespace AdvertisingPlatformsApi.Extensions;

public static class AppUseExtensions
{
    public static WebApplication AddUse(this WebApplication app)
    {
        app.UseSwagger();
        app.UseSwaggerUI();

        app.UseHttpsRedirection();
        app.UseAuthorization();
        app.MapControllers();
        
        return app;
    }
}