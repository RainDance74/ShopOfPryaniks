using ShopOfPryaniks.Application;
using ShopOfPryaniks.Infrastructure;
using ShopOfPryaniks.Infrastructure.Data;
using ShopOfPryaniks.Infrastructure.Identity;
using ShopOfPryaniks.Web;

WebApplicationBuilder builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddInfrastructureServices(builder.Configuration);
builder.Services.AddApplicationServices();
builder.Services.AddWebServices();

WebApplication app = builder.Build();

// Configure the HTTP request pipeline.
if(app.Environment.IsDevelopment())
{
    await app.InitialiseDatabaseAsync();
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.UseExceptionHandler(opt => { });

app.Map("/", () => Results.Redirect("/api"));

app.MapGroup("/api/Users")
   .WithTags("Users")
   .MapIdentityApi<ApplicationUser>();

app.Run();
