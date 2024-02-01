using ShopOfPryaniks.Application;
using ShopOfPryaniks.Infrastructure;
using ShopOfPryaniks.Infrastructure.Identity;
using ShopOfPryaniks.Persistence;
using ShopOfPryaniks.Persistence.Data;
using ShopOfPryaniks.Web;

WebApplicationBuilder builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddInfrastructureServices(builder.Configuration);
builder.Services.AddApplicationServices();
builder.Services.AddPersistenceServices(builder.Configuration);
builder.Services.AddWebServices();

WebApplication app = builder.Build();

// Configure the HTTP request pipeline.
if(app.Environment.IsDevelopment())
{
    await app.InitialiseIdentityDatabaseAsync();
    await app.InitialiseDatabaseAsync();
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.MapGroup("/api/Users")
   .WithTags("Users")
   .MapIdentityApi<ApplicationUser>();

app.Run();
