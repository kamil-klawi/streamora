using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using UsersService.Domain.Repositories;
using UsersService.Infrastructure.Persistence;
using UsersService.Infrastructure.Repositories;

namespace UsersService.Infrastructure.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static void AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
        {
            var connectionString = configuration.GetConnectionString("DefaultConnection");

            services.AddDbContext<UsersDbContext>(options => options.UseNpgsql(connectionString));
            services.AddScoped<IUsersRepository, UsersRepository>();
        }
    }
}
