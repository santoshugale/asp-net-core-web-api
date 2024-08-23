using Data.DatabaseContext;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace Data
{
    public static class ServiceCollectionExtentions
    {
        public static void RegisterDbContext(this IServiceCollection serviceCollection)
        {
            serviceCollection.AddDbContext<MoviesContext>(options =>
            {
                options.UseInMemoryDatabase("MoviesDatabase");
            });
        }
    }
}
