using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

using ShopOfPryaniks.Domain.Entities;

namespace ShopOfPryaniks.Persistence.Data;

public static class InitialiserExtensions
{
    public static async Task InitialiseDatabaseAsync(this WebApplication app)
    {
        using IServiceScope scope = app.Services.CreateScope();

        PryanikiDbContextInitialiser initialiser = scope.ServiceProvider.GetRequiredService<PryanikiDbContextInitialiser>();

        await initialiser.InitialiseAsync();

        await initialiser.SeedAsync();
    }
}

public class PryanikiDbContextInitialiser(
    ILogger<PryanikiDbContextInitialiser> logger, PryanikiDbContext context)
{
    private readonly ILogger<PryanikiDbContextInitialiser> _logger = logger;
    private readonly PryanikiDbContext _context = context;

    public async Task InitialiseAsync()
    {
        try
        {
            await _context.Database.MigrateAsync();
        }
        catch(Exception ex)
        {
            _logger.LogError(ex, "An error occurred while initialising the database.");
            throw;
        }
    }

    public async Task SeedAsync()
    {
        try
        {
            await TrySeedAsync();
        }
        catch(Exception ex)
        {
            _logger.LogError(ex, "An error occurred while seeding the database.");
            throw;
        }
    }

    public async Task TrySeedAsync()
    {
        if(!_context.Products.Any())
        {
            #region Products initialization
            _context.Products.Add(new Product
            {
                Name = "Тульский пряник",
                Description = "Самый известный из всех русских пряников тульский пряник имеет прямоугольную форму и минималистский дизайн. Обычно на нем нанесено название города – «Тула». Но, тем не менее, его сразу узнают в магазине. Этот пряник делается с начинкой, в основном с повидлом или сгущенкой.",
                Amount = 10,
                Price = 400,
                Discount = 10
            });

            _context.Products.Add(new Product
            {
                Name = "Вяземский пряник",
                Description = "Свой возрасти популярность по сравнению с тульским оспаривает вяземский пряник. Он приготавливался из заварного теста и отличался небольшими размерами. Даже слово «Вязьма» не нем не помещалась полностью, и оставались только три буквы – ВЯЗ. Вяземский пряник стоил дороже тульского, его готовили для царского стола. Существует легенда, что вяземские пряники очень любила английская королева.",
                Amount = 2,
                Price = 260,
                Discount = 30
            });

            _context.Products.Add(new Product
            {
                Name = "Городецкий пряник",
                Description = "Городец – городок небольшой, но до революции в нем насчитывалось около 15 пряничных заведений. Принадлежали они в основном старообрядцам. В отличие от вяземских пряников городецкие отличались внушительным размером и, соответственно, весом. От тульских они отличались своим оформлением – можно сказать, что это были настоящие произведения искусства. Здесь вырезались и различные животные, и гербы, и поезда –пароходы, и городские достопримечательности, и, конечно же, надписи, причем не только название города, но и поздравления с разными событиями. Начинка городецких пряников тоже была разнообразной - фруктовая, миндальная, лимонная, сиропная.",
                Amount = 0,
                Price = 800,
            });

            _context.Products.Add(new Product
            {
                Name = "Архангельская козуля",
                Description = "На поморском диалекте слово козуля означает завиток. Этот вид пряника выпекается в Архангельской и Мурманской областях. Он имеет вид фигурки какого-либо животного и украшен цветной глазурью. Раньше козули пекли только на Рождество и украшали ими елку. Считалось, что козули защищают дом от злых духов.",
                Amount = 8,
                Price = 550,
                Discount = 5
            });

            #endregion

            await _context.SaveChangesAsync();
        }
    }
}