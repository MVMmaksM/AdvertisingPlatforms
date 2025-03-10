using AdvertisingPlatformsApi.Extensions;

var builder = WebApplication.CreateBuilder(args);
builder.AddAppServices();

var app = builder.Build();
app.AddUse();

app.Run();