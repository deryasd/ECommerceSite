using Ocelot.DependencyInjection;
using Ocelot.Middleware;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddAuthentication().AddJwtBearer("GatewayAuthenticationScheme", options =>
{
    options.Authority = builder.Configuration["IdentityServerURL"];
    options.Audience = "resource_gateway";
    options.RequireHttpsMetadata = false;
});

builder.Services.AddOcelot();

builder.Configuration.AddJsonFile($"configuration.{builder.Environment.EnvironmentName.ToLower()}.json");

var app = builder.Build();

app.UseAuthorization();

await app.UseOcelot();

app.Run();
